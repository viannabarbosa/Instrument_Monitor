using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SimulationGUI
{
    class ClientWriter
    {
        private StreamWriter _writer;

        public void PersistWriter(TcpClient tcpWriter)
        {
            _writer = new StreamWriter(tcpWriter.GetStream());
        }

        public void SendMessage(string msg)
        {
            try
            {
                _writer.WriteLine(msg);
                _writer.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            };
        }
    }
}
