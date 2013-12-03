using NamedEntityTagger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for TaggerTest and is intended
    ///to contain all TaggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TaggerTest
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
        ///A test for byGazeteer
        ///</summary>
        [TestMethod()]
        public void byGazeteerTest()
        {
            Tagger test = new Tagger();
            test.Corpus = new Hashtable();
            test.Corpus.Add("file1","( سال و محل تولد : 726 ه. ق - شيراز , سال و محل وفات : 791 ه. ق - شيراز ) ");

            List<string> words = new List<string>();
            words.Add("شيراز");

            test.byGazeteer(words, "CITY");

            Assert.AreEqual("( سال و محل تولد : 726 ه. ق - <[CITY:شيراز]> , سال و محل وفات : 791 ه. ق - <[CITY:شيراز]> ) ",
                test.Corpus["file1"]);
        }

        /// <summary>
        ///A test for byRegular
        ///</summary>
        [TestMethod()]
        public void byRegularTest()
        {
            Tagger test = new Tagger();
            test.Corpus = new Hashtable();
            test.Corpus.Add("file1", "( سال و محل تولد : 726 ه. ق - شيراز , سال و محل وفات : 791 ه. ق - شيراز ) ");

            List<string> words = new List<string>();
            words.Add("\\d+");

            test.byRegular(words, "DIGIT");

            Assert.AreEqual("( سال و محل تولد :  <[DIGIT:726]>  ه. ق - شيراز , سال و محل وفات :  <[DIGIT:791]>  ه. ق - شيراز ) ",
                test.Corpus["file1"]);
        }
    }
}
