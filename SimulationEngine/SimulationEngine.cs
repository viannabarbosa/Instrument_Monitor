using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationEngine
{
    class SimulationEngine
    {
        private StreamWriter writer_;
        private CancellationTokenSource tokenSource_;
        //no concurrent hashset, using concurrentDictionary as an alternative
        private ConcurrentDictionary<string, byte> _subscriptions = new ConcurrentDictionary<string, byte>();
        private QuoteGenerator _quoteGenerator = new QuoteGenerator();


        public void AddWriter(TcpClient tcpClient)
        {
            writer_ = new StreamWriter(tcpClient.GetStream());
        }

        public void Start()
        {
            if(tokenSource_ != null && !tokenSource_.IsCancellationRequested){
                return;
            }
            tokenSource_ = new CancellationTokenSource();
            var cancellationToken = tokenSource_.Token;

            var task = Task.Run(() =>
            {
                var random = new Random();
                while (!cancellationToken.IsCancellationRequested)
                {
                    var quotes = _quoteGenerator.GetQuotes();
                    foreach(var quote in quotes)
                    {
                        if (!_subscriptions.ContainsKey(quote.Ticker))
                        {
                            continue;
                        }
                        SendMessage(quote.ToString());
                    }                    
                }
            }, cancellationToken);
        }

        public void InstrumentList()
        {
            foreach (var ticker in _quoteGenerator.GetInstrumentList())
            {
                var msg = "Instrument," + ticker;
                SendMessage(msg);
            }
        }

        public void Stop()
        {
            if (tokenSource_ != null)
            {
                tokenSource_.Cancel();
            }
        }

        public void Subscribe(string ticker)
        {
            string msg;
            if (_quoteGenerator.GetInstrumentList().Contains(ticker))
            {
                if (_subscriptions.TryAdd(ticker, 0))
                {
                    msg = $"Subscribe,{ticker}";
                }
                else
                {
                    msg = $"Error,{ticker} already subscribed";
                }
            }
            else
            {
                msg = $"Error,{ticker} does not exist";
            }
            SendMessage(msg);
        }

        public void Unsubscribe(string ticker)
        {
            string msg;
            if (_subscriptions.TryRemove(ticker, out _))
            {
                msg = $"Unsubscribe,{ticker}";
            }
            else
            {
                msg = $"Error,{ticker} was not subscribed";
            }
            SendMessage(msg);
        }

        private void SendMessage(string msg)
        {
            try
            {
                writer_.WriteLine(msg);
                writer_.Flush();
                Console.WriteLine($"Writer - Sent: {msg}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            };
        }

        
    }
}
