using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NutritionInfo.DataSources;

namespace NutritionInfo
{
    // Class NutritionDataHandler
    // This class should be accessed to load nutrition data into the dataset
    class NutritionDataHandler
    {
        DataSet _nutritionDS;
        IDataSource _dataSource = null;

        #region Constructors
        public NutritionDataHandler(byte datasourceType, string args)
        {
            if (datasourceType == (byte)DataSourceTypes.DataSourceType.CSV)
            {
                _dataSource = new CSVDataSource(args);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The dataset containing nutrition data
        /// </summary>
        public DataSet CurrentDataset
        {
            get { return _nutritionDS; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads data from the previously selected datasource.
        /// </summary>
        /// <returns>Returns true if the load was successful or false if it was not.</returns>
        public bool LoadData()
        {
            if (_dataSource == null)
            {
                return false;
            }
            else
            {
                _nutritionDS = _dataSource.Load();
                // Validate dataset meets all requirements
                return ValidateDataset();
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates the dataset contained in this class.
        /// </summary>
        /// <returns>Returns a bool indicating whether or not the dataset passed validation.</returns>
        private bool ValidateDataset()
        {
            string message = string.Empty;
            bool success = true;

            try {
                if (_nutritionDS == null)
                {
                    message += "Dataset is null" + Environment.NewLine;
                    success = false;
                }
                else
                {
                    if (_nutritionDS.DataSetName != "Nutrition")
                    {
                        message += "Dataset name invalid" + Environment.NewLine;
                        success = false;
                    }
                    if (_nutritionDS.Tables.Count < 1)
                    {
                        message += "No tables loaded" + Environment.NewLine;
                        success = false;
                    }
                    if (_nutritionDS.Tables[0].TableName != "Food")
                    {
                        message += "Food table not found" + Environment.NewLine;
                        success = false;
                    }

                    // Ensure all tables have an entry for each food
                    int rowCount = _nutritionDS.Tables[0].Rows.Count;
                    foreach (DataTable dt in _nutritionDS.Tables)
                    {
                        if (dt.Rows.Count != rowCount)
                        {
                            message += "Invalid row count for " + dt.TableName + ", is " + dt.Rows.Count + ", should be " + rowCount + Environment.NewLine;
                            success = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                message += "Exception encountered: " + ex.Message + Environment.NewLine;
                success = false;
            }

            if (!success)
            {
                Logger.LogHandler.Log("Error encountered when validating dataset: " + message + Environment.NewLine);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
