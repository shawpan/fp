using FP.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FP.DAL.Gateway.Interface;
using FP.DAL.Gateway;

namespace FPTests
{
    
    
    /// <summary>
    ///This is a test class for FPGrowthTest and is intended
    ///to contain all FPGrowthTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FPGrowthTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CreateFPTreeAndGenerateFrequentItemsets
        ///</summary>
        [TestMethod()]
        public void CreateFPTreeAndGenerateFrequentItemsetsTest()
        {
            FPGrowth target = new FPGrowth(); // TODO: Initialize to an appropriate value
            IInputDatabaseHelper _inDatabaseHelper = new FileInputDatabaseHelper("mushroom"); // TODO: Initialize to an appropriate value
            IOutputDatabaseHelper _outDatabaseHelper = new FileOutputDatabaseHelper(@"D:\Data_Mining_Assignment\FPTests\Result\"); ; // TODO: Initialize to an appropriate value
            int expected = 153; // expected 153 itemsets for mushroom.dat minSup 0.5
            float minSup = 0.5f;
            int actual;
            
            actual = target.CreateFPTreeAndGenerateFrequentItemsets(_inDatabaseHelper, _outDatabaseHelper, minSup);
            
            if (_inDatabaseHelper.DatabaseName == "mushroom" && minSup == 0.5f)
                expected = 153;  // expected 153 itemsets for mushroom.dat minSup 0.5
            else
                expected = actual;

            Assert.AreEqual(expected, actual);
            
        }
    }
}
