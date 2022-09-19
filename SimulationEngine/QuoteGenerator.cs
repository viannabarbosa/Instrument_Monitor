using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine
{
    class QuoteGenerator
    {
        private readonly List<string> _tickers = new List<string> { "TICKER1", "TICKER2", "TICKER3", "TICKER4", "TICKER5" };
        private List<Quote> _quotes = new List<Quote>();

        Random _random = new Random();

        public QuoteGenerator()
        {
            foreach(var ticker in _tickers)
            {
                _quotes.Add(new Quote() { Ticker = ticker, PriceInCents = 10000 });
            }
        }

        public List<Quote> GetQuotes()
        {
            //can fluctuate anywhere between -2 dollars and +2 dollars
            foreach(var quote in _quotes)
            {
                quote.PriceInCents += _random.Next(-200, 200);
                Task.Delay(300).Wait();
            }

            return _quotes;
        }

        internal List<string> GetInstrumentList()
        {
            return _tickers;
        }
    }

    class Quote
    {
        public string Ticker { get; set; }
        public int PriceInCents { get; set; }
        public decimal Price {
            get { return Convert.ToDecimal(PriceInCents/100.0); }
        }
        public override string ToString()
        {
            return $"Quote,{Ticker},{Price}";
        }
    }

    class CustomQuote : Quote
    {
        public string Ticker1 { get; set; }
        public double Weight1 { get; set; }
        public string Ticker2 { get; set; }
        public double Weight2 { get; set; }

    }
}
