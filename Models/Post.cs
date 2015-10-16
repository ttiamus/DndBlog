using System;
using MongoDB.Bson;

namespace Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Post
    {
        public ObjectId Id { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }


        public Post()
        {
            
        }

        public Post(int id , string body, DateTime date, string author)
        {
            this.Id = ObjectId.Parse(id.ToString());
            this.Body = body;
            this.Date = date;
            this.Author = author;
        }
    }
}
