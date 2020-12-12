using APIRestNetFramework.Models;
using Swashbuckle.Examples;
using System.Collections.Generic;

namespace APIRestNetFramework.Swagger
{
    public class BookExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Book()
            {
                Id = 1,
                Name = "Elantris",
                Category = "Fantasía",
                Price = 15.0M
            };
        }
    }

    public class BooksExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Name = "Elantris",
                    Category = "Fantasía",
                    Price = 15.0M
                }
            };
        }
    }
}