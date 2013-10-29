using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FP.DAL.Gateway.Interface;
using FP.DAL.Gateway;
using FP.Algorithm;
namespace FP
{
    
    class Program
    {
        static void Main(string[] args)
        {
            IInputDatabaseHelper inDatabaseHelper = new FileInputDatabaseHelper("mushroom");
            IOutputDatabaseHelper outDatabaseHelper = new FileOutputDatabaseHelper(@"D:\Data_Mining_Assignment\FPGrowth\Result\");
            FPGrowth fpGrowth = new FPGrowth();
            fpGrowth.CreateFPTreeAndGenerateFrequentItemsets(
                inDatabaseHelper,outDatabaseHelper,0.74f);
            
        }
    }
}
