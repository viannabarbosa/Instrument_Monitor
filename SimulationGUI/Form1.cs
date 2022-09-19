using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationGUI
{
    public partial class Form1 : Form
    {
        private BindingList<Quote> _quoteList = new BindingList<Quote>();
        private HashSet<string> _instruments = new HashSet<string>();
        private ClientReader _clientReader = new ClientReader();
        private ClientWriter _clientWriter = new ClientWriter();

        public Form1()
        {
            InitializeComponent();
            //small delay to make sure that the server is up and running
            Task.Delay(500).Wait();
            InitializeTCPConnections();

            _clientReader.NewQuote += ClientReader_NewQuote;
            _clientReader.NewSubscription += ClientReader_NewSubscription;
            _clientReader.NewUnsubscription += ClientReader_NewUnsubscription;
            _clientReader.NewInstrument += ClientReader_NewInstrument;
            _clientReader.Error += _clientReader_Error;

            dataGridViewSubscriptions.DataSource = _quoteList;
            dataGridViewSubscriptions.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewSubscriptions.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewSubscriptions.Columns[1].ReadOnly = true;
            dataGridViewSubscriptions.Columns[2].ReadOnly = true;
        }

        private void InitializeTCPConnections()
        {
            try
            {
                //Writer
                var tcpWriter = new TcpClient("127.0.0.1", 20000);
                _clientWriter.PersistWriter(tcpWriter);

                //Reader
                 var tcpReader = new TcpClient("127.0.0.1", 20001);
                _ = _clientReader.ReadAsync(tcpReader);
            }
            catch(Exception e)
            {
                var msg = $"Error connecting to server. Shutting down application. \n" +
                    $"Make sure that the server is up and running. Details:\n{e}";
                FlexibleMessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }           
        }

        private void _clientReader_Error(object sender, ErrorEventArgs e)
        {
            FlexibleMessageBox.Show(e.ErrorMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (e.Fatal)
            {
                Environment.Exit(0);
            }
        }

        private void ClientReader_NewInstrument(object sender, QuoteEventArgs e)
        {
            _instruments.Add(e.Ticker);
        }

        private void ClientReader_NewUnsubscription(object sender, QuoteEventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                var quote = _quoteList.FirstOrDefault(quote => quote.Ticker == e.Ticker);
                if (quote != null)
                {
                    _quoteList.Remove(quote);
                }
            }));            
        }

        private void ClientReader_NewSubscription(object sender, QuoteEventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                _quoteList.Add(new Quote() { Ticker = e.Ticker, Price = e.Price });
            }));
        }

        private void ClientReader_NewQuote(object sender, QuoteEventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                var quote = _quoteList.FirstOrDefault(quote => quote.Ticker == e.Ticker);
                if (quote != null)
                {
                    quote.Price = e.Price;
                }
                //this could be done on a timer
                dataGridViewSubscriptions.Refresh();
            }));
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _clientWriter.SendMessage("Start");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _clientWriter.SendMessage("Stop");
        }

        private void buttonSubscribe_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSubscribe.Text))
            {
                _clientWriter.SendMessage($"Subscribe,{textBoxSubscribe.Text}");
                textBoxSubscribe.Clear();
            }            
        }

        private void buttonUnsubscribe_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSubscriptions.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    _clientWriter.SendMessage($"Unsubscribe,{row.Cells[1].Value}");
                }
            }
        }

        private void textBoxSubscribe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                //avoid "ding" sound
                e.Handled = true;
                buttonSubscribe.PerformClick();
            }
        }

        private void buttonInstruments_Click(object sender, EventArgs e)
        {
            var message = string.Empty;
            foreach (var instrument in _instruments)
            {
                message += $"{instrument},\n";
            }
            FlexibleMessageBox.Show(message, "Available Instruments", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class Quote
    {
        public string Ticker { get; set; }
        public decimal Price { get; set; }
    }

}
