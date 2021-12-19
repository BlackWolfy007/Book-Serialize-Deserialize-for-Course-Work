using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Sem_3_Course_Work_C_Sharp
{
    [Serializable]
    public class Chapter
    {
        public int ChapterId { get; set; }

        public string ChapterText { get; set; }

        public Dictionary<string, int> ChapterVariants { get; set; }

    }

    [Serializable]
    public class Book
    {
        public string BookAuthor { get; set; }

        public string BookTitle { get; set; }

        public Chapter[] Chapters { get; set; }

    }

    static class Program
    {
        static async Task Main (string[] args)
        {
            StreamWriter FileWriter = new StreamWriter("TestBook.ibr", true);
            
            Chapter chapter_begin = new Chapter(){ChapterId = 0, ChapterText = "Chapter 0 Text", ChapterVariants = new Dictionary<string, int>(10){{ "Begining: leads to chapter 1" , 1}, { "Begining: leads to chapter 2", 2 }, { "Begining: leads to chapter 3", 3 } }};

            string[] test = chapter_begin.ChapterVariants.Keys.ToArray();

            Console.WriteLine(test[0]);
            Console.WriteLine(test[1]);
            Console.WriteLine(test[2]);
            
            Chapter chapter1 = new Chapter(){ChapterId = 1, ChapterText = "Chapter 1 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 1: leads to chapter 4", 4 } } };
            
            Chapter chapter2 = new Chapter(){ChapterId = 2, ChapterText = "Chapter 2 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 2: leads to chapter 4", 4 } }};
            
            Chapter chapter3 = new Chapter(){ChapterId = 3, ChapterText = "Chapter 3 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 3: leads to chapter 4", 4 } } };
            
            Chapter chapter4 = new Chapter(){ChapterId = 4, ChapterText = "Chapter 4 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 4: leads to chapter 5", 5 }, { "Chapter 4: leads to chapter 6", 6 }, { "Chapter 4: leads to chapter 7", 7 } }};
            
            Chapter chapter5 = new Chapter(){ChapterId = 5, ChapterText = "Chapter 5 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 5: leads to chapter 8", 8 } }};
            
            Chapter chapter6 = new Chapter(){ChapterId = 6, ChapterText = "Chapter 6 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 6: leads to chapter 8", 8 } }};
            
            Chapter chapter7 = new Chapter(){ChapterId = 7, ChapterText = "Chapter 7 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 7: leads to chapter 8", 8 } }};
            
            Chapter chapter8 = new Chapter(){ChapterId = 8, ChapterText = "Chapter 8 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 8: leads to chapter 9", 9 }, { "Chapter 8: leads to chapter 10", 10 }, { "Chapter 8: leads to chapter 11", 11 } }};
            
            Chapter chapter9 = new Chapter(){ChapterId = 9, ChapterText = "Chapter 9 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 9: the end of the story", -1 } }};
            
            Chapter chapter10 = new Chapter(){ChapterId = 9, ChapterText = "Chapter 10 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 10: the end of the story", -1 } }};
            
            Chapter chapter11 = new Chapter(){ChapterId = 9, ChapterText = "Chapter 11 Text", ChapterVariants = new Dictionary<string, int>(10){ { "Chapter 11: the end of the story", -1 } }};
            
            Chapter chapter_end = new Chapter(){ChapterId = -1, ChapterText = "End of the book", ChapterVariants = new Dictionary<string, int>(10){ { "End of the book", -1 } }};

            Chapter[] ch_array = new Chapter[]{chapter_begin,chapter1,chapter2,chapter3,chapter4,chapter5,chapter6,chapter7,chapter8,chapter9,chapter10,chapter11,chapter_end};

            Book CoolBook = new Book(){BookAuthor = "Cool Author", BookTitle = "Cool Book Not For Kids", Chapters = ch_array};

            FileWriter.WriteLine(JsonSerializer.Serialize(CoolBook));

            FileWriter.Close();

            Book restored_book = new Book();

            StreamReader FileReader = new StreamReader("TestBook.ibr");

            restored_book = JsonSerializer.Deserialize<Book>(FileReader.ReadLine());

            FileReader.Close();
            
        }
    }
}
