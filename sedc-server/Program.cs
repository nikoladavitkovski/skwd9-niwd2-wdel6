using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Books books = new Books();
            Type type = new Type("Poem");
            type.GetType();
        }
        class Books
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Author { get; set; }

            public int BookId { get; set; }
        }
        class Type : Books
        {
            public Type(string genre)
            {
                Genre = genre;
            }
            public string Genre { get => base.Title; set => base.Title = value; }
        }
    }
}