using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NutritionInfo.DataSources
{
    /// <summary>
    /// Interface should be implemented for any type of data source for nutrition data files
    /// </summary>
    interface IDataSource
    {
        DataSet Load();
    }
}
