#region Copyright
// #####################################################
//
// Copyright (c) 2016 Oliver Dorn
//
// This file is part of MWPC Service.
//
// MWPC Service is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MWPC Service is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MWPC Service.  If not, see <http://www.gnu.org/licenses/>.
//
// #####################################################
#endregion

using MWPC_Server;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceProcess;

namespace MWPC_Service
{
    public partial class MWPCService : ServiceBase
    {
        private Configuration mConfiguration;
        private List<PerformanceCounterSelection> mPCSelections = new List<PerformanceCounterSelection>();
        private MWPCServer mMWPCServer;

        public MWPCService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            mConfiguration = XmlHelper.LoadConfig();
            if (mConfiguration != null)
            {
                mPCSelections = XmlHelper.LoadPCSelections();
                if (mPCSelections != null)
                {
                    IPAddress ipaddress = IPAddress.Any;
                    IPAddress.TryParse(mConfiguration.BindAddress, out ipaddress);
                    mMWPCServer = new MWPCServer(ipaddress, mConfiguration.Port, mPCSelections, false);
                    mMWPCServer.StartServer();
                }
                else
                {
                    EventLogger eventLogger = new EventLogger();
                    eventLogger.Log("Error reading file \"configuration.xml\"!", System.Diagnostics.EventLogEntryType.Error, 1);
                    Environment.Exit(1);
                }
            }
            else
            {
                EventLogger eventLogger = new EventLogger();
                eventLogger.Log("Error reading file \"configuration.xml\"!", System.Diagnostics.EventLogEntryType.Error, 1);
                Environment.Exit(1);
            }
        }

        protected override void OnStop()
        {
            mMWPCServer.StopServer();
            mMWPCServer = null;
        }
    }
}
