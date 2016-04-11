using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NutritionInfo.DataSources;
using NutritionInfo.Logger;

namespace NutritionInfo
{
    /* The purpose of this form is to easily view the contents of a nutrition data file and to ensure they laod into memory correctly.
        Data sources are totally dynamic and can hold any information about a food */
    public partial class NutritionData : Form
    {
        NutritionDataHandler dataHandler = null;
        FlowLayoutPanel dataPanel = null;
        // Pixel offset of data panel
        readonly int dataPanelOffset = 25;

        public NutritionData()
        {
            InitializeComponent();
            // Initialize data sources and loggers.
            // TODO: Take out hard coded CSV data source, move to factory method or some other means of selecting data source type, move file path to config file or something in the UI
            dataHandler = new NutritionDataHandler((byte)DataSourceTypes.DataSourceType.CSV, @"C:\NutritionData\Nutrition Dataset.csv");
            LogHandler.CreateLogger(txtConsole);
        }

        /// <summary>
        /// Executes when the button click event happens on the Load Data button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataHandler.LoadData() && dataHandler.CurrentDataset != null)
            {
                var foods = dataHandler.CurrentDataset.Tables[0].Select();

                // Add the name of all foods to the select box on the UI
                foreach (DataRow d in foods)
                {
                    NutritionSelect.Items.Add(d.Field<string>("Data"));
                }

                // Create panel to hold a label and text box for all data per food
                if (dataPanel != null) { dataPanel.Dispose(); }
                dataPanel = new FlowLayoutPanel();
                dataPanel.Width = groupBoxNutritionInfo.Width - (dataPanelOffset * 2);
                dataPanel.Height = groupBoxNutritionInfo.Height - (dataPanelOffset * 2);
                dataPanel.Location = new Point(dataPanelOffset, dataPanelOffset);
                dataPanel.AutoScroll = true;

                groupBoxNutritionInfo.Controls.Add(dataPanel);

                // Creates a label and textbox for each data member to display its information in the UI
                foreach (DataTable t in dataHandler.CurrentDataset.Tables)
                {
                    Label l = new Label();
                    l.Name = "lbl" + t.TableName;
                    l.Text = t.TableName;
                    l.Width = (dataPanel.Width / 4) - (dataPanelOffset / 2);
                    l.TextAlign = ContentAlignment.MiddleLeft;

                    TextBox txt = new TextBox();
                    txt.Name = t.TableName;
                    txt.Width = (dataPanel.Width / 4) - (dataPanelOffset / 2);
                    txt.ReadOnly = true;

                    dataPanel.Controls.Add(l);
                    dataPanel.Controls.Add(txt);
                    l.Visible = true;
                    txt.Visible = true;
                }
                NutritionSelect.SelectedIndex = 0;
                LogHandler.Log("Data loaded successfully.");
            }
        }

        /// <summary>
        /// Loads all data for the selected food item when the Select Index changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NutritionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dataHandler.CurrentDataset != null)
            {
                foreach(Control c in groupBoxNutritionInfo.Controls)
                {
                    if (c is FlowLayoutPanel)
                    {
                        foreach (Control innerc in c.Controls)
                        {
                            if (innerc is TextBox)
                            {
                                innerc.Text = dataHandler.CurrentDataset.Tables[innerc.Name].Rows[NutritionSelect.SelectedIndex].Field<string>("Data");
                            }
                        }
                    }
                }
            }
        }
    }
}
