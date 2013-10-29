using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using FP.DAL.DAO;
using FP.DAL.Gateway.Interface;
using System.IO;
namespace FP.DAL.Gateway
{
    public class FileInputDatabaseHelper : IInputDatabaseHelper
    {
        private string dbType; // database type
        private string dbName; // database type
        private int totalTransactionNumber;
        private StreamReader inputFilePointer; 
        public int TotalTransactionNumber
        {
          get { return totalTransactionNumber; }
        }
        public string DatabaseType
        {
            get { return dbType; }           
        }
        public string DatabaseName
        {
            get { return dbName; }
        }

        public void OpenDatabaseConnection()
        {
            try
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FileDB"];
                inputFilePointer = new System.IO.StreamReader(settings.ConnectionString);//open file for streaming
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void CloseDatabaseConnection()
        {
            try
            {
                inputFilePointer.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
       public List<string> GetNextTransaction()
        {
            List<string> transaction = new List<string>();
            string line=""; 
           try
            {
                if ((line = inputFilePointer.ReadLine()) != null)
                {
                    transaction = new List<string>(line.Trim().Split(' '));
                    transaction = transaction.Select(s => s.Trim()).ToList();
                }
                else
                {
                    return transaction;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return transaction;
            }
            return transaction;
        }

        //constructor 
        public FileInputDatabaseHelper(string _databaseName)
        {
            dbType = ConfigurationManager.AppSettings["DataBaseType"];
            dbName = _databaseName;
            totalTransactionNumber = 0;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FileDB"]; // get connection settings for File Type Database
            List<Item> items = new List<Item>();
            IDictionary<string, int> dictionary = new Dictionary<string, int>(); // temporary associative array for counting frequency of items
            string line;
            if (settings != null)
            {
                System.IO.StreamReader file;
                try
                {
                    file = new System.IO.StreamReader(settings.ConnectionString);//open file for streaming

                    while ((line = file.ReadLine()) != null) totalTransactionNumber++;

                    file.Close(); // close file
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        //get support count of all items
        public List<Item> CalculateFrequencyAllItems()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FileDB"]; // get connection settings for File Type Database
            List<Item> items = new List<Item>();
            IDictionary<string, int> dictionary = new Dictionary<string, int>(); // temporary associative array for counting frequency of items
            string line;
            if (settings != null)
            {
                System.IO.StreamReader file ;
                try
                {
                    file = new System.IO.StreamReader(settings.ConnectionString);//open file for streaming
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] tempItems = line.Split(' ');
                        foreach(string tempItem in tempItems)
                        {
                            string item = tempItem.Trim();
                            if (item.Length == 0) continue;
                            if (dictionary.ContainsKey(item))
                                dictionary[item]++; // increase frequency of item
                            else
                                dictionary[item] = 1; //set initial frequency
                        }
                    }

                    file.Close(); // close file
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                //insert all the item, frequency pair in items list
                foreach (KeyValuePair<string, int> pair in dictionary)
                {
                    Item anItem = new Item(pair.Key, pair.Value);
                    items.Add(anItem);
                }
            }
            
            return items;
        }

        //get frequency of an item set
        public int GetFrequency(ItemSet itemSet)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FileDB"]; // get connection settings for File Type Database
            int frequency = 0;
            IDictionary<string, int> dictionary = new Dictionary<string, int>(); // temporary associative array for counting frequency of items
            string line;
            if (settings != null)
            {
                System.IO.StreamReader file;
                try
                {
                    file = new System.IO.StreamReader(settings.ConnectionString);//open file for streaming
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] tempItems = line.Split(' ');
                        dictionary.Clear();
                        foreach (string tempItem in tempItems)
                        {
                            string item = tempItem.Trim();
                            dictionary[item] = 1; //set dictionary for this item
                        }

                        bool itemSetExist = true; //indicates if this transaction contains itemset 
                        for(int i=0; i<itemSet.GetLength(); ++i)
                        {
                            Item item = itemSet.GetItem(i);
                            if(!dictionary.ContainsKey(item.Symbol))
                            {
                                itemSetExist = false;
                                break;
                            }
                        }
                        if(itemSetExist)
                        {
                            frequency++;
                        }
                    }

                    file.Close(); // close file
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
                
            }
            itemSet.SupportCount = frequency;
            return frequency;
        }

    }
}
