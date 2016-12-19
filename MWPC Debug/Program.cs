#region Copyright
// #####################################################
//
// Copyright (c) 2016 Oliver Dorn
//
// This file is part of MWPC Debug.
//
// MWPC Debug is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MWPC Debug is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MWPC Debug.  If not, see <http://www.gnu.org/licenses/>.
//
// #####################################################
#endregion

using MWPC_Server;
using System;
using System.Collections.Generic;
using System.Net;

namespace MWPC_Debug
{
    class Program
    {
        private static Configuration mConfiguration;
        private static List<PerformanceCounterSelection> mPCSelections = new List<PerformanceCounterSelection>();
        private static MWPCServer mMWPCServer;

        static void Main(string[] args)
        {
            mConfiguration = XmlHelper.LoadConfig();
            if (mConfiguration != null)
            {
                mPCSelections = XmlHelper.LoadPCSelections();
                if (mPCSelections != null)
                {
                    IPAddress ipaddress = IPAddress.Any;
                    IPAddress.TryParse(mConfiguration.BindAddress, out ipaddress);
                    mMWPCServer = new MWPCServer(ipaddress, mConfiguration.Port, mPCSelections, true);
                    mMWPCServer.StartServer();
                }
                else
                {
                    Console.WriteLine("Error reading file \"configuration.xml\"!");
                }
            }
            else
            {
                Console.WriteLine("Error reading file \"configuration.xml\"!");
            }
        }
    }
}
