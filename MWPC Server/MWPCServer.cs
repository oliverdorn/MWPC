using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace MWPC_Server
{
    public class MWPCServer
    {
        private const string NEWLINE = "\n";
        private EventLogger mEventLogger;
        private TcpListener mTCPListener;
        private List<PerformanceCounterSelection> mPCSelections;
        private Dictionary<string, PerformanceCounter> mPerformanceCounters;
        private bool mDebug;
        private bool mStopServer;
        private Thread mServerThread;

        public MWPCServer(IPAddress ipaddress, int port, List<PerformanceCounterSelection> pcselections, bool debug)
        {
            try
            {
                mDebug = debug;
                mEventLogger = new EventLogger();
                mTCPListener = new TcpListener(ipaddress, port);
                mPCSelections = pcselections;
                mPerformanceCounters = new Dictionary<string, PerformanceCounter>();
                if (mPCSelections.Count != 0)
                {
                    foreach (PerformanceCounterSelection pcSelection in mPCSelections)
                    {
                        string[] instances = pcSelection.PerformanceCounterInstances.Split(';');
                        foreach (string instance in instances)
                        {
                            PerformanceCounter performanceCounter = new PerformanceCounter();
                            performanceCounter.CategoryName = pcSelection.PerformanceCounterCategory;
                            performanceCounter.InstanceName = instance;
                            performanceCounter.CounterName = pcSelection.PerformanceCounterName;
                            mPerformanceCounters.Add(pcSelection.Id + "_" + instance, performanceCounter);
                        }
                    }
                }
                else
                {
                    Dbg("No Performance Counters have been selected. Please use MWPC Selector!", true);
                    Evt("No Performance Counters have been selected. Please use MWPC Selector!", EventLogEntryType.Warning, 2);
                }
                
            }
            catch (Exception e)
            {
                Evt("An error occured :" + e.Message, EventLogEntryType.Error, 1001);
                mTCPListener = null;
            }
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public void StartServer()
        {
            if (mTCPListener != null && mPerformanceCounters.Count != 0)
            {
                Dbg("Server started", false);
                mStopServer = false;
                InitializePerformanceCounters();
                mTCPListener.Start();
                mServerThread = new Thread(new ThreadStart(ServerWorker));
                mServerThread.Start();
            }
            else
                Environment.Exit(1);
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public void StopServer()
        {
            if (mTCPListener != null)
            {
                Dbg("Server stopped", false);
                mStopServer = true;
                mTCPListener.Stop();
                mServerThread.Join(1000);
                if (mServerThread.IsAlive)
                {
                    mServerThread.Abort();
                }
                mServerThread = null;
                mTCPListener = null;
            }
        }

        /// <summary>
        /// Initialize Performance Counter values.
        /// </summary>
        private void InitializePerformanceCounters()
        {
            foreach (KeyValuePair<string, PerformanceCounter> kvPair in mPerformanceCounters)
            {
                kvPair.Value.NextValue();
            }
        }

        /// <summary>
        /// Function for debugging (verbose information in MWPC Debug console application).
        /// </summary>
        /// <param name="message">The message to display.</param>
        private void Dbg(string message, bool wait)
        {
            if (mDebug) Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " - " + message);
            if (wait)
                Console.ReadLine();
        }

        /// <summary>
        /// Function for debugging (verbose information in Eventlog for MWPC Service).
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="type">The type of message (info, error, warning...).</param>
        /// <param name="eventid">An event id.</param>
        private void Evt(string message, EventLogEntryType type, int eventid)
        {
            if (!mDebug) mEventLogger.Log(message, type, eventid);
        }

        /// <summary>
        /// The server worker thread (main-loop).
        /// </summary>
        private void ServerWorker()
        {
            Thread.Sleep(1000);
            while (!mStopServer)
            {
                try
                {
                    Dbg("Waiting for Client...", false);
                    TcpClient tcpClient = mTCPListener.AcceptTcpClient();
                    Dbg("Client connected: " + ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString(), false);
                    Evt("Client connected: " + ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString(), EventLogEntryType.Information, 101);
                    NetworkStream netStream = tcpClient.GetStream();
                    StreamWriter streamWriter = new StreamWriter(netStream, Encoding.GetEncoding("iso-8859-1")) { AutoFlush = true };
                    StreamReader streamReader = new StreamReader(netStream, Encoding.GetEncoding("iso-8859-1"));
                    streamWriter.Write("# munin node at " + Environment.MachineName + NEWLINE);
                    bool connected = true;
                    while (connected)
                    {
                        string command = string.Empty;
                        string pluginId = string.Empty;
                        string inputLine = streamReader.ReadLine();
                        if (inputLine == null)
                            break;
                        string[] input = inputLine.ToLower().Split(' ');
                        command = input[0];
                        if (input.Length > 1)
                        {
                            pluginId = input[1];
                        }
                        Dbg("Client requested: " + inputLine, false);
                        // command: list
                        if (command.Equals("list"))
                        {
                            string pluginList = string.Empty;
                            foreach (PerformanceCounterSelection pcSelection in mPCSelections)
                            {
                                pluginList += pcSelection.Id + " ";
                            }
                            streamWriter.Write(pluginList + NEWLINE);
                            Dbg("Server responded: " + pluginList, false);
                        }
                        // command: nodes
                        else if (command.Equals("nodes"))
                        {
                            streamWriter.Write(Environment.MachineName + NEWLINE);
                            streamWriter.Write("." + NEWLINE);
                            Dbg("Server responded: " + Environment.MachineName, false);
                        }
                        // command: config <pluginId>
                        else if (command.Equals("config"))
                        {
                            if (!pluginId.Equals(string.Empty))
                            {
                                string config = string.Empty;
                                PerformanceCounterSelection pcSelection = mPCSelections.Find(pcSel => pcSel.Id == pluginId);
                                if (pcSelection != null)
                                {
                                    config += "graph_title " + pcSelection.Title + NEWLINE;
                                    if (!pcSelection.YLabel.Equals(string.Empty))
                                        config += "graph_vlabel " + pcSelection.YLabel + NEWLINE;
                                    int i = 0;
                                    string[] instances = pcSelection.PerformanceCounterInstances.Split(';');
                                    foreach (string instance in instances)
                                    {
                                        if (!instance.Equals(string.Empty))
                                            config += pluginId + "_" + i.ToString() + ".label " + instance + NEWLINE;
                                        else
                                            config += pluginId + "_" + i.ToString() + ".label " + pcSelection.PerformanceCounterName + NEWLINE;
                                        if (!pcSelection.Draw.Equals(string.Empty))
                                            config += pluginId + "_" + i.ToString() + ".draw " + pcSelection.Draw + NEWLINE;
                                        if (!pcSelection.Type.Equals(string.Empty))
                                            config += pluginId + "_" + i.ToString() + ".type " + pcSelection.Type + NEWLINE;
                                        if (!pcSelection.Warning.Equals(string.Empty))
                                            config += pluginId + "_" + i.ToString() + ".warning " + pcSelection.Warning + NEWLINE;
                                        if (!pcSelection.Critical.Equals(string.Empty))
                                            config += pluginId + "_" + i.ToString() + ".critical " + pcSelection.Critical + NEWLINE;
                                        i++;
                                    }
                                    config += "graph_args --base " + pcSelection.Base;
                                    if (!pcSelection.LowerLimit.Equals(string.Empty))
                                        config += " --lower-limit " + pcSelection.LowerLimit;
                                    if (!pcSelection.UpperLimit.Equals(string.Empty))
                                        config += " --upper-limit " + pcSelection.UpperLimit;
                                    config += NEWLINE;
                                    if (pcSelection.Scale)
                                    {
                                        config += "graph_scale yes" + NEWLINE;
                                    }
                                    else
                                    {
                                        config += "graph_scale no" + NEWLINE;
                                    }
                                    config += "graph_category " + pcSelection.Category + NEWLINE;
                                    streamWriter.Write(config);
                                    streamWriter.Write("." + NEWLINE);
                                    Dbg("Server responded: " + NEWLINE + config, false);
                                }
                            }
                            else
                            {
                                streamWriter.Write("# Unknown service" + NEWLINE);
                                streamWriter.Write("." + NEWLINE);
                                Dbg("Server responded: # Unknown service", false);
                            }
                        }
                        // command: fetch <pluginId>
                        else if (command.Equals("fetch"))
                        {
                            if (!pluginId.Equals(string.Empty))
                            {
                                string values = string.Empty;
                                PerformanceCounterSelection pcSelection = mPCSelections.Find(pcSel => pcSel.Id == pluginId);
                                if (pcSelection != null)
                                {
                                    int i = 0;
                                    string[] instances = pcSelection.PerformanceCounterInstances.Split(';');
                                    foreach (string instance in instances)
                                    {
                                        PerformanceCounter performanceCounter = mPerformanceCounters[pluginId + "_" + instance];
                                        values += pluginId + "_" + i.ToString() + ".value " + (performanceCounter.NextValue() * pcSelection.Multiplicator).ToString("0.000", CultureInfo.InvariantCulture) + NEWLINE;
                                        i++;
                                    }
                                    streamWriter.Write(values);
                                    streamWriter.Write("." + NEWLINE);
                                    Dbg("Server responded: " + NEWLINE + values, false);
                                }
                                else
                                {
                                    streamWriter.Write("# Unknown service" + NEWLINE);
                                    streamWriter.Write("." + NEWLINE);
                                    Dbg("Server responded: # Unknown service", false);
                                }
                            }
                            else
                            {
                                streamWriter.Write("# Unknown service" + NEWLINE);
                                streamWriter.Write("." + NEWLINE);
                                Dbg("Server responded: # Unknown service", false);
                            }
                        }
                        // command: version
                        else if (command.Equals("version"))
                        {
                            streamWriter.Write("munin node on " + Environment.MachineName + " version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + NEWLINE);
                        }
                        // command: quit
                        else if (command.Equals("quit") || command.Equals("."))
                        {
                            connected = false;
                            tcpClient.Client.Disconnect(true);
                            tcpClient.Close();
                        }
                        // command unknown
                        else
                        {
                            streamWriter.Write("# Unknown command. Try list, nodes, config, fetch, version or quit" + NEWLINE);
                        }
                    }
                    Dbg("Client disconnected", false);
                    Evt("Client disconnected", EventLogEntryType.Information, 102);
                }
                catch (Exception e)
                {
                    Evt("An error occured: " + e.Message, EventLogEntryType.Error, 1002);
                    mStopServer = true;
                    Environment.Exit(1);
                }
            }
        }
    }
}