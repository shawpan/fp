using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FP.DAL.Gateway.Interface
{
    public interface IOutputDatabaseHelper
    {
        string DatabaseType //indicates database type (TEXTFILE,SQL etc.)
        {
            get;
        }
        string DatabasePath //indicates database type (TEXTFILE,SQL etc.)
        {
            get;
        }
        //write final metrics to output
        void WriteAggregatedResult(string dbName,float minimumSupport,int totalFrequentItemSets, double totalRunningTime_ms);
    }
}
