using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringEncoding;


namespace StringTest

{
    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void GetRowsTest()
        {
            var rows = Books.GetRows(@"C:\Development\StringEncoding\SampleText.txt");
            Assert.AreEqual(rows.Count, 4);
        }

        [TestMethod()]
        public void TruncateTest()
        {
            //Arrange
            List<Books> booksFromCsvFile = new List<Books>();
            booksFromCsvFile.Add

               (new Books{PublishDate = "10-2-15", Title = "TEST TEST 12345678910111213141516", Author = "Aarron the Baron"});

            var truncatePubCol = Books.Truncate(booksFromCsvFile, 2, 50, 50);
            var truncateTitleCol = Books.Truncate(booksFromCsvFile, 50, 10, 50);
            var truncateAuthorCol = Books.Truncate(booksFromCsvFile, 50, 50, 6);

            Assert.AreEqual(truncatePubCol[0].PublishDate, "..");
            Assert.AreEqual(truncateTitleCol[0].Title, "TEST TES...");
            Assert.AreEqual(truncateAuthorCol[0].Author, "Aar...");
        }
    }
}