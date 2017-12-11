using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEncoding
{
    public class Books
    {
        public string PublishDate { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public static List<Books> GetRows(string filepath)
        {
            var reader = new StreamReader(filepath);

            List<Books> bookRows = new List<Books>();
            while (!reader.EndOfStream)
            {
                Books book = new Books();

                var line = reader.ReadLine();
                var values = line.Split(',');

                book.PublishDate = values[0];
                book.Title = values[1];
                book.Author = values[2];

                bookRows.Add(book);
            }
            return bookRows;
        }

        public static List<Books> Truncate (List<Books> rows, int widthOne, int widthTwo, int widthThree)
        {
            foreach (var row in rows)
            {
                if (row.PublishDate.Length > widthOne)
                {
                    if (widthOne < 3)
                        row.PublishDate = (new string('.', widthOne));
                    else
                        row.PublishDate = (row.PublishDate.Substring(0, widthOne - 3)) + "...";

                }
                if (row.Title.Length > widthTwo)
                {
                    if (widthOne < 3)
                        row.PublishDate = (new string('.', widthTwo));
                    else
                        row.Title = (row.Title.Substring(0, widthTwo - 3)) + "...";

                }
                if (row.Author.Length > widthThree)
                {
                    if (widthOne < 3)
                        row.PublishDate = (new string('.', widthThree));
                    else
                        row.Author = (row.Author.Substring(0, widthThree - 3)) + "...";

                }
            }

            return rows;
        }
    }
}
