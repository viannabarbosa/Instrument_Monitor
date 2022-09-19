using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGUI
{
    class ClientReader
    {
        public event EventHandler<QuoteEventArgs> NewQuote;
        public event EventHandler<QuoteEventArgs> NewSubscription;
        public event EventHandler<QuoteEventArgs> NewUnsubscription;
        public event EventHandler<QuoteEventArgs> NewInstrument;
        public event EventHandler<ErrorEventArgs> Error;

        public async Task<bool> ReadAsync(TcpClient tcpClient)
        {
            await Task.Run(() =>
            {
                using (NetworkStream stream = tcpClient.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (true)
                    {
                        var line = string.Empty;
                        try
                        {
                            line = reader.ReadLine();
                        }catch(Exception e)
                        {
                            var msg = $"Error reading from server. Terminating application.\n" +
                                $" Details:\n{e}";
                            OnError(new ErrorEventArgs() { ErrorMsg = msg, Fatal = true });
                            return;
                        }                        
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        var tokens = line.Split(',');
                        var command = tokens[0];
                        switch (command.ToLower())
                        {
                            case "error":
                                OnError(new ErrorEventArgs() { ErrorMsg = line, Fatal = false });
                                break;
                            case "subscribe":
                                OnNewSubscription(new QuoteEventArgs { Ticker = tokens[1], Price = 0.00m });
                                break;
                            case "unsubscribe":
                                OnNewUnsubscription(new QuoteEventArgs { Ticker = tokens[1], Price = 0.00m });
                                break;
                            case "quote":
                                OnNewQuote(new QuoteEventArgs { Ticker = tokens[1],
                                    Price = Convert.ToDecimal(tokens[2]) });
                                break;
                            case "instrument":
                                OnNewInstrument(new QuoteEventArgs
                                {
                                    Ticker = tokens[1]
                                });
                                break;
                        }
                    }
                }
            });
            return true;
        }

        protected virtual void OnNewQuote(QuoteEventArgs e)
        {
            NewQuote?.Invoke(this, e);
        }
        protected virtual void OnNewSubscription(QuoteEventArgs e)
        {
            NewSubscription?.Invoke(this, e);
        }
        protected virtual void OnNewUnsubscription(QuoteEventArgs e)
        {
            NewUnsubscription?.Invoke(this, e);
        }
        protected virtual void OnNewInstrument(QuoteEventArgs e)
        {
            NewInstrument?.Invoke(this, e);
        }
        protected virtual void OnError(ErrorEventArgs e)
        {
            Error?.Invoke(this, e);
        }
    }

    class QuoteEventArgs : EventArgs
    {
        public string Ticker { get; set; }
        public decimal Price { get; set; }
    }

    class ErrorEventArgs : EventArgs
    {
        public string ErrorMsg{ get; set; }
        public bool Fatal { get; set; }
    }
}
