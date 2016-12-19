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

using System;

namespace MWPC_Server
{
    public class PerformanceCounterSelection : IEquatable<PerformanceCounterSelection>
    {
        public PerformanceCounterSelection() { }

        public PerformanceCounterSelection(string id, string category, string instances, string counter)
        {
            Id = id;
            PerformanceCounterCategory = category;
            PerformanceCounterInstances = instances;
            PerformanceCounterName = counter;
            Title = counter;
            YLabel = "";
            Category = category;
            Base = "1000";
            Multiplicator = 1;
            LowerLimit = "";
            UpperLimit = "";
            Draw = "LINE";
            Type = "GAUGE";
            Scale = true;
            Warning = "";
            Critical = "";
        }

        public string Id { get; set; }
        public string PerformanceCounterCategory { get; set; }
        public string PerformanceCounterInstances { get; set; }
        public string PerformanceCounterName { get; set; }
        public string Title { get; set; }
        public string YLabel { get; set; }
        public string Category { get; set; }
        public string Base { get; set; }
        public double Multiplicator { get; set; }
        public string LowerLimit { get; set; }
        public string UpperLimit { get; set; }
        public string Draw { get; set; }
        public string Type { get; set; }
        public bool Scale { get; set; }
        public string Warning { get; set; }
        public string Critical { get; set; }

        public bool Equals(PerformanceCounterSelection other)
        {
            return PerformanceCounterCategory.Equals(other.PerformanceCounterCategory) &&
                    PerformanceCounterInstances.Equals(other.PerformanceCounterInstances) &&
                    PerformanceCounterName.Equals(other.PerformanceCounterName);
        }
    }
}
