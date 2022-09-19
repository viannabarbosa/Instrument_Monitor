using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SimulationEngine
{
    class Program
    {
        private static readonly SimulationEngine simulationEngine_ = new SimulationEngine();

        static void Main(string[] args)
        {
            TcpReaderTask();
            simulationEngine_.AddWriter(TcpWriterTask());
            simulationEngine_.InstrumentList();
            Console.ReadLine();
        }

        static void TcpReaderTask()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 20000);
            tcpListener.Start();
            new Task(() =>
            {
                try
                {
                    var client = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Reader - TCP Connection Accepted");
                    using (client)
                    using (var stream = client.GetStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var command = string.Empty;
                        do
                        {
                            var line = reader.ReadLine();
                            if (line is null)
                            {
                                //this means client closed
                                break;
                            }
                            Console.WriteLine($"Reader - Received: {line}");
                            var tokens = line.Split(',');
                            command = tokens[0];
                            switch (command.ToLower())
                            {
                                case "start":
                                    simulationEngine_.Start();
                                    break;
                                case "stop":
                                    simulationEngine_.Stop();
                                    break;
                                case "subscribe":
                                    simulationEngine_.Subscribe(tokens[1]);
                                    break;
                                case "unsubscribe":
                                    simulationEngine_.Unsubscribe(tokens[1]);
                                    break;
                            }
                        } while (command.ToLower() != "quit");
                    }
                    tcpListener.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }).Start();
        }

        static TcpClient TcpWriterTask()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 20001);
            tcpListener.Start();
            var client = tcpListener.AcceptTcpClient();
            Console.WriteLine("Writer - TCP Connection Accepted");
            return client;
        }
    }


}
