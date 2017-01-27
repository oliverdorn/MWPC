#region Copyright
// #####################################################
//
// Copyright (c) 2016 Oliver Dorn
//
// This file is part of MWPC Selector.
//
// MWPC Selector is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MWPC Selector is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MWPC Selector.  If not, see <http://www.gnu.org/licenses/>.
//
// #####################################################
#endregion

using MWPC_Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;

namespace MWPC_Selector
{
    public partial class MainForm : Form
    {
        private const string PREFIX = "pc_";
        private Configuration mConfiguration;
        private List<PerformanceCounterCategory> mPCCategories = new List<PerformanceCounterCategory>();
        private List<string> mPCInstances = new List<string>();
        private List<PerformanceCounter> mPCCounters = new List<PerformanceCounter>();
        private BindingList<PerformanceCounterSelection> mPCSelections = new BindingList<PerformanceCounterSelection>();

        public MainForm()
        {
            InitializeComponent();
            mPCCategories = PerformanceCounterCategory.GetCategories().OrderBy(pcCategory => pcCategory.CategoryName).ToList();
            lb_PerformanceCounterCategories.DataSource = mPCCategories;
            lb_PerformanceCounterCategories.DisplayMember = "CategoryName";
            lb_PerformanceCounterInstances.DataSource = mPCInstances;
            lb_PerformanceCounters.DataSource = mPCCounters;
            lb_PerformanceCounters.DisplayMember = "CounterName";
            dgv_SelectedPerformanceCounters.DataSource = mPCSelections;
            // Check if service installed and enable/disable controls
            if (ServiceAvailable())
            {
                serviceToolStripMenuItem.Enabled = true;
            }
            else
            {
                serviceToolStripMenuItem.Enabled = false;
            }
            UpdateServiceStatusLabel();
        }

        /// <summary>
        /// Instances (and Counters) are filtered for the selected Category.
        /// </summary>
        private void lb_PerformanceCounterCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            object pcCategorySelection = lb_PerformanceCounterCategories.SelectedItem;
            if (pcCategorySelection != null)
            {
                mPCCounters = new List<PerformanceCounter>();
                lb_PerformanceCounters.DataSource = mPCCounters;
                lb_PerformanceCounters.DisplayMember = "CounterName";
                PerformanceCounterCategory pcCategory = (PerformanceCounterCategory)pcCategorySelection;
                mPCInstances = pcCategory.GetInstanceNames().OrderBy(pcInstance => pcInstance).ToList();
                lb_PerformanceCounterInstances.DataSource = mPCInstances;
                if (mPCInstances.Count() == 0)
                {
                    mPCCounters = pcCategory.GetCounters().OrderBy(pcCounter => pcCounter.CounterName).ToList();
                    lb_PerformanceCounters.DataSource = mPCCounters;
                    lb_PerformanceCounters.DisplayMember = "CounterName";
                }
            }
        }

        /// <summary>
        /// Counters are filtered for the selected Instance.
        /// </summary>
        private void lb_PerformanceCounterInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            object pcCategorySelection = lb_PerformanceCounterCategories.SelectedItem;
            object pcInstanceSelection = lb_PerformanceCounterInstances.SelectedItem;
            if (pcCategorySelection != null && pcInstanceSelection != null)
            {
                PerformanceCounterCategory pcCategory = (PerformanceCounterCategory)pcCategorySelection;
                string pcInstance = (string)lb_PerformanceCounterInstances.SelectedItem;
                mPCCounters = pcCategory.GetCounters(pcInstance).OrderBy(pcCounter => pcCounter.CounterName).ToList();
                lb_PerformanceCounters.DataSource = mPCCounters;
                lb_PerformanceCounters.DisplayMember = "CounterName";
            }
        }

        /// <summary>
        /// A description for the selected Counter is displayed if available.
        /// </summary>
        private void lb_PerformanceCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            object pcCounterSelection = lb_PerformanceCounters.SelectedItem;
            if (pcCounterSelection != null)
            {
                PerformanceCounter pcCounter = (PerformanceCounter)pcCounterSelection;
                try
                {
                    tb_CounterDescription.Text = pcCounter.CounterHelp;
                }
                catch
                {
                    tb_CounterDescription.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// The selected Counter is added to the DataGridView-DataSource.
        /// </summary>
        private void btn_AddCounter_Click(object sender, EventArgs e)
        {
            string id = PREFIX;
            string category = string.Empty;
            string instances = string.Empty;
            string counter = string.Empty;
            object pcCategorySelection = lb_PerformanceCounterCategories.SelectedItem;
            ListBox.SelectedObjectCollection pcInstanceSelections = lb_PerformanceCounterInstances.SelectedItems;
            object pcCounterSelection = lb_PerformanceCounters.SelectedItem;
            // Create Plugin ID: c(ategory)<index>i(ndizes)<base2indexsum>c(ounter)<index>
            id += "c" + lb_PerformanceCounterCategories.SelectedIndex.ToString();
            int[] indizes = lb_PerformanceCounterInstances.SelectedIndices.Cast<int>().ToArray();
            int sum = 0;
            foreach (int index in indizes)
            {
                sum += (1 << index);
            }
            id += "i" + sum.ToString();
            id += "c" + lb_PerformanceCounters.SelectedIndex.ToString();
            if (pcCategorySelection != null)
                category = ((PerformanceCounterCategory)pcCategorySelection).CategoryName;
            if (pcInstanceSelections.Count > 0)
            {
                instances = string.Join(";", pcInstanceSelections.Cast<string>().ToArray());
            }
            if (pcCounterSelection != null)
                counter = ((PerformanceCounter)pcCounterSelection).CounterName;
            PerformanceCounterSelection pcSelection = new PerformanceCounterSelection(id, category, instances, counter);
            // Check for duplicates
            if (!mPCSelections.Contains(pcSelection))
                mPCSelections.Add(pcSelection);
            // Change selection to newly added row
            dgv_SelectedPerformanceCounters.CurrentCell = dgv_SelectedPerformanceCounters.Rows[dgv_SelectedPerformanceCounters.RowCount - 1].Cells[0];
            dgv_SelectedPerformanceCounters.Rows[dgv_SelectedPerformanceCounters.RowCount - 1].Selected = true;
        }

        /// <summary>
        /// The selected row is deleted from the DataGridView-DataSource.
        /// </summary>
        private void btn_RemoveCounter_Click(object sender, EventArgs e)
        {
            mPCSelections.RemoveAt(dgv_SelectedPerformanceCounters.CurrentCell.RowIndex);
        }

        /// <summary>
        /// Loads the configuration.xml file.
        /// </summary>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mConfiguration = XmlHelper.LoadConfig();
            if (mConfiguration != null)
            {
                List<PerformanceCounterSelection> pcSelections = XmlHelper.LoadPCSelections();
                if (pcSelections != null)
                {
                    mPCSelections = new BindingList<PerformanceCounterSelection>(pcSelections);
                    dgv_SelectedPerformanceCounters.DataSource = mPCSelections;
                }
            }
        }

        /// <summary>
        /// Saves the configuration.xml file.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mConfiguration == null)
            {
                mConfiguration = XmlHelper.LoadConfig();
            }
            if (mConfiguration != null)
            {
                if (XmlHelper.SaveConfigAndPCSelections(mConfiguration, mPCSelections.ToList()))
                {
                    MessageBox.Show("File saved successfully!\nPlease restart the service!", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Unable to load default settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Starts the service.
        /// </summary>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartService();
        }

        /// <summary>
        /// Stops the service.
        /// </summary>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopService();
        }

        /// <summary>
        /// Restarts the service.
        /// </summary>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartService();
        }

        /// <summary>
        /// Shows some information about this application.
        /// </summary>
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + "\nVersion " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\nCopyright © Oliver Dorn 2016", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Checks if the MWPC-Service is installed and available.
        /// </summary>
        /// <returns>true if the service is installed and available, false otherwise.</returns>
        private bool ServiceAvailable()
        {
            ServiceController serviceController = ServiceController.GetServices().FirstOrDefault(service => service.ServiceName.Equals("MWPC Service"));
            return !(serviceController == null);
        }

        /// <summary>
        /// Checks if the MWPC-Service is running.
        /// </summary>
        /// <returns>true if the service is running, false otherwise.</returns>
        private bool ServiceRunning()
        {
            if (ServiceAvailable())
            {
                ServiceController serviceController = new ServiceController("MWPC Service");
                return (serviceController.Status == ServiceControllerStatus.Running);
            }
            return false;
        }

        /// <summary>
        /// Starts the service.
        /// </summary>
        private void StartService()
        {
            try
            {
                // If service is not running start it
                if (!ServiceRunning())
                {
                    lbl_ServiceStatus.Text = "Starting...";
                    lbl_ServiceStatus.ForeColor = System.Drawing.Color.Black;
                    Thread startServiceThread = new Thread(new ThreadStart(StartingThread));
                    startServiceThread.Start();
                }
                else
                {
                    MessageBox.Show("The service is running!", "Service running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thread for starting the service.
        /// </summary>
        private void StartingThread()
        {
            ServiceController serviceController = new ServiceController("MWPC Service");
            try
            {
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(10000));
            }
            catch (Exception e)
            {
                Invoke(new Action(() => { MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
            }
            finally
            {
                Invoke(new Action(() => { UpdateServiceStatusLabel(); }));
            }
        }

        /// <summary>
        /// Stops the service.
        /// </summary>
        private void StopService()
        {
            try
            {
                // If service is running stop it
                if (ServiceRunning())
                {
                    lbl_ServiceStatus.Text = "Stopping...";
                    lbl_ServiceStatus.ForeColor = System.Drawing.Color.Black;
                    Thread stopServiceThread = new Thread(new ThreadStart(StoppingThread));
                    stopServiceThread.Start();
                }
                else
                {
                    MessageBox.Show("The service is not running!", "Service stopped", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thread for stopping the service.
        /// </summary>
        private void StoppingThread()
        {
            ServiceController serviceController = new ServiceController("MWPC Service");
            try
            {
                serviceController.Stop();
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(10000));
            }
            catch (Exception e)
            {
                Invoke(new Action(() => { MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
            }
            finally
            {
                Invoke(new Action(() => { UpdateServiceStatusLabel(); }));
            }
        }

        /// <summary>
        /// Restarts the service.
        /// </summary>
        private void RestartService()
        {
            try
            {
                // If service is running restart it
                if (ServiceRunning())
                {
                    lbl_ServiceStatus.Text = "Restarting...";
                    lbl_ServiceStatus.ForeColor = System.Drawing.Color.Black;
                    Thread restartServiceThread = new Thread(new ThreadStart(RestartingThread));
                    restartServiceThread.Start();
                }
                // If service is not running start it
                else
                {
                    lbl_ServiceStatus.Text = "Starting...";
                    lbl_ServiceStatus.ForeColor = System.Drawing.Color.Black;
                    Thread startServiceThread = new Thread(new ThreadStart(StartingThread));
                    startServiceThread.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thread for restarting the service.
        /// </summary>
        private void RestartingThread()
        {
            ServiceController serviceController = new ServiceController("MWPC Service");
            try
            {
                serviceController.Stop();
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(10000));
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(10000));
            }
            catch (Exception e)
            {
                Invoke(new Action(() => { MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
            }
            finally
            {
                Invoke(new Action(() => { UpdateServiceStatusLabel(); }));
            }
        }

        /// <summary>
        /// Updates the service status indicator.
        /// </summary>
        private void UpdateServiceStatusLabel()
        {
            if (ServiceRunning())
            {
                lbl_ServiceStatus.Text = "Running";
                lbl_ServiceStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lbl_ServiceStatus.Text = "Stopped";
                lbl_ServiceStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Ensures that only decimals can be entered in Multiplicator column.
        /// </summary>
        private void dgv_SelectedPerformanceCounters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Multiplicator_KeyPress);
            if (dgv_SelectedPerformanceCounters.CurrentCell.ColumnIndex == dgv_SelectedPerformanceCounters.Columns.IndexOf(dgc_Multiplicator))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                    tb.KeyPress += Multiplicator_KeyPress;
            }
        }

        /// <summary>
        /// Checks if the pressed key belongs to a decimal.
        /// </summary>
        private void Multiplicator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
