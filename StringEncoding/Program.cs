using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace StringEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            int authorWidth = 30;
            int titleWidth = 20;
            int publishWidth = 20;

            int totalTableWidth = publishWidth + titleWidth + authorWidth + 4;

            var rows = Books.GetRows(@"C:\Development\StringEncoding\SampleText.txt");
            var truncatedRows = Books.Truncate(rows, publishWidth, titleWidth, authorWidth);

            Console.WriteLine($"|{truncatedRows[0].PublishDate.PadRight(publishWidth)}|{truncatedRows[0].Title.PadLeft(titleWidth)}{truncatedRows[0].Author.PadRight(authorWidth)}");
            Console.WriteLine("|" + (new string('=', totalTableWidth - 2)) + "|");

            for (int i = 1; i < truncatedRows.Count; i++)
            {
                Console.WriteLine($"|{truncatedRows[i].PublishDate.PadRight(publishWidth)}|{truncatedRows[i].Title.PadLeft(titleWidth)}|{truncatedRows[i].Author.PadRight(authorWidth)}|");
            }


            Console.ReadLine();
        }
    }
}
