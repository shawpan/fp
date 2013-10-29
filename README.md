FP-Growth
=======

FP-Growth using FP-Tree(frequent pattern mining from databases without candidate generation) algorithm implementation in C# .Net

For inputs and outputs File System is used here. Other kind of databases can be used by implementing IInputDatabaseHelper.cs and IOutputDatabaseHelper.cs interfaces.


Path for input file is given in App.config file (change this value for other input files)

Path for output file is given in FileOutputDatabaseHelper constructor (change this value for other output paths)

Program.cs file shows a sample usage

Sample Usage

```
static void Main(string[] args)
        {
            IInputDatabaseHelper inDatabaseHelper = new FileInputDatabaseHelper("mushroom");
            IOutputDatabaseHelper outDatabaseHelper = new FileOutputDatabaseHelper(@"D:\Data_Mining_Assignment\FPGrowth\Result\");
            FPGrowth fpGrowth = new FPGrowth();
            fpGrowth.CreateFPTreeAndGenerateFrequentItemsets(
                inDatabaseHelper,outDatabaseHelper,0.74f);
            
        }        

```
Unit Test Project

Unit Test Project FPTests is also included with a few unit tests implemented.


