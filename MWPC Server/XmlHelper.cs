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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace MWPC_Server
{
    public class XmlHelper
    {
        private const int XMLVERSION = 1;
        private static string CONFIGFILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MWPC", "configuration.xml");

        /// <summary>
        /// Loads config from configuration.xml.
        /// </summary>
        /// <returns>A Configuration Object containing the config.</returns>
        public static Configuration LoadConfig()
        {
            Configuration configuration = new Configuration("0.0.0.0", 4949);
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(CONFIGFILE);
                XmlNode xmlMWPC = xmlDoc.DocumentElement;
                XmlNode xmlConfiguration = xmlMWPC["Configuration"];
                configuration.BindAddress = xmlConfiguration["BindAddress"].InnerText;
                int port = 4949;
                int.TryParse(xmlConfiguration["Port"].InnerText, out port);
                configuration.Port = port;
            }
            catch
            {
                return null;
            }
            return configuration;
        }

        /// <summary>
        /// Loads the selected Performance Counters from configuration.xml.
        /// </summary>
        /// <returns>A List<PerformanceCountersSelection> containing the selected Performance Counters.</returns>
        public static List<PerformanceCounterSelection> LoadPCSelections()
        {
            List<PerformanceCounterSelection> pcSelections = new List<PerformanceCounterSelection>();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(CONFIGFILE);
                XmlNode xmlMWPC = xmlDoc.DocumentElement;
                XmlNode xmlConfiguration = xmlMWPC["Configuration"];
                if (xmlConfiguration["Version"].InnerText.Equals(XMLVERSION.ToString()))
                {
                    XmlNode xmlPCSelections = xmlMWPC["PCSelections"];
                    foreach (XmlNode xmlPCSelection in xmlPCSelections)
                    {
                        PerformanceCounterSelection pcSelection = new PerformanceCounterSelection();
                        pcSelection.Id = xmlPCSelection["Id"].InnerText;
                        pcSelection.PerformanceCounterCategory = xmlPCSelection["PCCategory"].InnerText;
                        pcSelection.PerformanceCounterInstances = xmlPCSelection["PCInstances"].InnerText;
                        pcSelection.PerformanceCounterName = xmlPCSelection["PCCounter"].InnerText;
                        pcSelection.Title = xmlPCSelection["Title"].InnerText;
                        pcSelection.YLabel = xmlPCSelection["YLabel"].InnerText;
                        pcSelection.Category = xmlPCSelection["Category"].InnerText;
                        pcSelection.Base = xmlPCSelection["Base"].InnerText;
                        double multiplicator = 1;
                        double.TryParse(xmlPCSelection["Multiplicator"].InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out multiplicator);
                        pcSelection.Multiplicator = multiplicator;
                        pcSelection.LowerLimit = xmlPCSelection["LowerLimit"].InnerText;
                        pcSelection.UpperLimit = xmlPCSelection["UpperLimit"].InnerText;
                        pcSelection.Draw = xmlPCSelection["Draw"].InnerText;
                        pcSelection.Type = xmlPCSelection["Type"].InnerText;
                        if (xmlPCSelection["Scale"].InnerText == "0")
                            pcSelection.Scale = false;
                        else
                            pcSelection.Scale = true;
                        pcSelection.Warning = xmlPCSelection["Warning"].InnerText;
                        pcSelection.Critical = xmlPCSelection["Critical"].InnerText;
                        pcSelections.Add(pcSelection);
                    }
                }
            }
            catch
            {
                return null;
            }
            return pcSelections;
        }

        /// <summary>
        /// Saves the selected Performance Counters to configuration.xml.
        /// </summary>
        /// <param name="pcselections">A List<PerformanceCountersSelection> containing the selected Performance Counters.</param>
        /// <returns>true on success, false otherwise.</returns>
        public static bool SaveConfigAndPCSelections(Configuration config, List<PerformanceCounterSelection> pcselections)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode xmlMWPC = xmlDoc.CreateElement("MWPC");
                xmlDoc.AppendChild(xmlMWPC);
                XmlNode xmlConfiguration = xmlDoc.CreateElement("Configuration");
                xmlConfiguration.AppendChild(xmlDoc.CreateElement("Version")).InnerText = XMLVERSION.ToString();
                xmlConfiguration.AppendChild(xmlDoc.CreateElement("BindAddress")).InnerText = config.BindAddress;
                xmlConfiguration.AppendChild(xmlDoc.CreateElement("Port")).InnerText = config.Port.ToString();
                xmlMWPC.AppendChild(xmlConfiguration);
                XmlNode xmlPCSelections = xmlDoc.CreateElement("PCSelections");
                foreach (PerformanceCounterSelection pcSelection in pcselections)
                {
                    XmlNode xmlPCSelection = xmlDoc.CreateElement("PCSelection");
                    if (!pcSelection.Id.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Id")).InnerText = pcSelection.Id;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Id"));
                    if (!pcSelection.PerformanceCounterCategory.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("PCCategory")).InnerText = pcSelection.PerformanceCounterCategory;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("PCCategory"));
                    if (!pcSelection.PerformanceCounterInstances.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("PCInstances")).InnerText = pcSelection.PerformanceCounterInstances;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("PCInstances"));
                    if (!pcSelection.PerformanceCounterName.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("PCCounter")).InnerText = pcSelection.PerformanceCounterName;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("PCCounter"));
                    if (!pcSelection.Title.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Title")).InnerText = pcSelection.Title;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Title"));
                    if (!pcSelection.YLabel.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("YLabel")).InnerText = pcSelection.YLabel;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("YLabel"));
                    if (!pcSelection.Category.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Category")).InnerText = pcSelection.Category;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Category"));
                    if (!pcSelection.Base.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Base")).InnerText = pcSelection.Base;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Base"));
                    xmlPCSelection.AppendChild(xmlDoc.CreateElement("Multiplicator")).InnerText = pcSelection.Multiplicator.ToString(CultureInfo.InvariantCulture);
                    if (!pcSelection.LowerLimit.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("LowerLimit")).InnerText = pcSelection.LowerLimit;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("LowerLimit"));
                    if (!pcSelection.UpperLimit.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("UpperLimit")).InnerText = pcSelection.UpperLimit;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("UpperLimit"));
                    if (!pcSelection.Draw.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Draw")).InnerText = pcSelection.Draw;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Draw"));
                    if (!pcSelection.Type.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Type")).InnerText = pcSelection.Type;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Type"));
                    if (pcSelection.Scale)
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Scale")).InnerText = "1";
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Scale")).InnerText = "0";
                    if (!pcSelection.Warning.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Warning")).InnerText = pcSelection.Warning;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Warning"));
                    if (!pcSelection.Critical.Equals(string.Empty))
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Critical")).InnerText = pcSelection.Critical;
                    else
                        xmlPCSelection.AppendChild(xmlDoc.CreateElement("Critical"));
                    xmlPCSelections.AppendChild(xmlPCSelection);
                }
                xmlMWPC.AppendChild(xmlPCSelections);
                xmlDoc.Save(CONFIGFILE);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
