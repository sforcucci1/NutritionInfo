using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using NutritionInfo.Logger;

namespace NutritionInfo.DataSources
{
    /// <summary>
    /// Handles data stored in .CSV files for nutrition data
    /// </summary>
    class CSVDataSource : IDataSource
    {
        // File path of the .csv file
        string _filePath = string.Empty;

        #region Constructors
        /// <summary>
        /// Creates a CSV data source
        /// </summary>
        /// <param name="filePath">The file path of the .csv file</param>
        public CSVDataSource(string filePath)
        {
            _filePath = filePath;
        }
        #endregion

        /// <summary>
        /// Loads the CSV data into memory
        /// TODO: Re-examine the final data structure used in the dataset pending more concrete determination of functionality
        /// </summary>
        /// <returns>A dataset of the nutrition data</returns>
        public DataSet Load()
        {
            DataSet nutritionDS = new DataSet("Nutrition");
            try
            {
                // The starting character in a string for a substring
                int subStart = 0;
                // Current line number
                int lineNum = 0;
                // Counter for the nuumber of items read in from the current line of data
                int itemNum = 0;
                var reader = new StreamReader(File.OpenRead(_filePath));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    // Determines whether the item is encapsulated by double quotes, this occurs when an actual comma appears in CSV
                    bool encapsulated = false;
                    // Used because encapsulated items will end on the actual comma, but unencapsulated items will end one character after
                    bool ignoreNextComma = false;

                    for (int i = 0; i < line.Length; i++)
                    {
                        // Handles encapsulation
                        if (line[i] == '"')
                        {
                            if (!encapsulated)
                            {
                                encapsulated = true;
                                subStart = i + 1;
                            }
                            else
                            {
                                AddData(line.Substring(subStart, i - subStart), itemNum, lineNum, nutritionDS);
                                itemNum++;
                                encapsulated = false;
                                subStart = i + 1;
                                ignoreNextComma = true;

                            }
                        }
                        else if (line[i] == ',' && !encapsulated)
                        {
                            // Handles basic use case with items seperated by commas
                            if (!ignoreNextComma)
                            {
                                AddData(line.Substring(subStart, i - subStart), itemNum, lineNum, nutritionDS);
                                itemNum++;
                                subStart = i + 1;
                            }
                            else
                            {
                                subStart = i + 1;
                                ignoreNextComma = false;
                            }
                        }
                    }
                    // Handles last item in encapsulated cases
                    if (line.Length - subStart > 0)
                    {
                        AddData(line.Substring(subStart, line.Length - subStart), itemNum, lineNum, nutritionDS);
                    }
                    lineNum++; itemNum = 0; subStart = 0;
                }
            }
            catch (Exception ex)
            {
                LogHandler.LogException(ex.Message, ex.StackTrace);
                return null;
            }
            return nutritionDS;
        }

        /// <summary>
        /// Adds data string to the dataset.
        /// TODO: Remove special handling of first dataset depending on how database sources look, apply unit logic (like converting g into a unit that can easily be converted into mg, Mg, micrograms, etc)
        /// </summary>
        /// <param name="data">String containing the data</param>
        /// <param name="rowNum">Row number in data, also referred to as item number</param>
        /// <param name="colNum">Column number in data</param>
        /// <param name="ds">Dataset to add to</param>
        private void AddData(string data, int rowNum, int colNum, DataSet ds)
        {
            if (colNum == 0)
            {
                // Table containing all the food names is specially created
                if (!ds.Tables.Contains("Food"))
                {
                    ds.Tables.Add(new DataTable("Food"));
                    ds.Tables[0].Columns.Add("Data");
                }
                else
                {
                    ds.Tables[0].Rows.Add(data);
                }
            }
            else
            {
                if (ds.Tables.Count <= colNum)
                {
                    ds.Tables.Add(new DataTable(data));
                    ds.Tables[colNum].Columns.Add("Data", typeof(string));
                }
                else
                {
                    ds.Tables[colNum].Rows.Add(data);
                }
            }
        }
    }
}
