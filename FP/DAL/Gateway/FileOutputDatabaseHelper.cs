using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FP.DAL.DAO;
using FP.DAL.Gateway.Interface;
using System.IO;
namespace FP.DAL.Gateway
{
    public class FileOutputDatabaseHelper : IOutputDatabaseHelper
    {
        private string dbType; // database type
        string outputFilePath;

        public string DatabasePath
        {
            get { return outputFilePath; }
        }

        public string DatabaseType
        {
            get { return dbType; }
        }

        public FileOutputDatabaseHelper(string _outputFilePath) //e.g. _outpoutFilePath = @"C:\Result\"
        {
            dbType = "File";
            outputFilePath = _outputFilePath;
        }


        public void WriteAggregatedResult(string dbName, float minimumSupport, int totalFrequentItemSets, double totalRunningTime_ms)
        {
            System.IO.StreamWriter file;
            try
            {
                string fileName = outputFilePath + dbName+"_"+minimumSupport.ToString()+"_aggregated.txt";
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                file = new System.IO.StreamWriter(fileName);//open file for streaming
                file.WriteLine("MinSup Itemset_NO Time(s)");
                file.WriteLine(minimumSupport.ToString()+" "+totalFrequentItemSets.ToString()+" "+(totalRunningTime_ms/1000f).ToString());
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return;
            }
        }
    }
}
