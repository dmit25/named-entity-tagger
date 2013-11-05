using NammedEntityTagger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for ParserTest and is intended
    ///to contain all ParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParserTest
    {

        private const string INPUT_FILE = "data/text.txt";
        private const string OUTPUT_FILE = "data/output.txt";

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


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Argument cannot be null.")]
        public void ParseTestNull()
        {
            Parser.Parse(null);
        }

        [TestMethod()]
        public void ParseTestCorrectInput()
        {
            String test1 = "a b.c,d";
            String[] res1 = Parser.Parse(test1);
            string[] expRes = { "a", "b", "c", "d" };
            Assert.AreEqual(expRes.ToString(), res1.ToString());
        }

        [TestMethod()]
        public void ParseTestIncorrectInput()
        {
            String test = "a-b. c,d";
            String[] res1 = Parser.Parse(test);

            string[] expRes = { "a-b", "", "c", "d" };
            Assert.AreEqual(expRes.ToString(), res1.ToString());

            String[] res2 = Parser.Parse("");
            Assert.AreEqual("", res2[0]);
        }

        [TestMethod()]
        public void CountWordsTestCorrectInput()
        {

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Argument cannot be null.")]
        public void CountWordsTestNull()
        {
            Parser.CountWords(null, null);
            Parser.CountWords(null, OUTPUT_FILE);
            Parser.CountWords(INPUT_FILE, null);
        }
    }
}
