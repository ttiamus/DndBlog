using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Post
    {
        [BsonId]
        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastEdited { get; set; }

        public Post()
        {

        }

        public Post(string author, string title, string body)
        {
            this.Author = author;
            this.Title = title;
            this.Body = body;
            this.Created = DateTime.Now;
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
