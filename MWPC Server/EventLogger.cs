#region Copyright
// #####################################################
//
// Copyright (c) 2016 Oliver Dorn
//
// This file is part of MWPC Server.
//
// MWPC Server is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MWPC Server is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MWPC Server.  If not, see <http://www.gnu.org/licenses/>.
//
// #####################################################
#endregion

using System.Diagnostics;

namespace MWPC_Server
{
    public class EventLogger
    {
        private const string EVENTSOURCE = "MWPCService";
        private const string LOG = "Application";

        public EventLogger()
        {
            if (!EventLog.SourceExists(EVENTSOURCE))
                EventLog.CreateEventSource(EVENTSOURCE, LOG);
        }

        public void Log(string message, EventLogEntryType type, int eventid)
        {
            EventLog.WriteEntry(EVENTSOURCE, message, type, eventid);
        }
    }
}
