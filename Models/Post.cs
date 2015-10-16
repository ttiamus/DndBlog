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

        public DateTime Created { get; set; }

        public DateTime? LastEdited { get; set; }

        public string Author { get; set; }


        public Post()
        {

        }

        public Post(string body, DateTime creationDate, string author)
        {
            this.Body = body;
            this.Created = creationDate;
            this.Author = author;
        }

        public Post(ObjectId id, string body, DateTime creationDate, string author)
        {
            this.Id = id;
            this.Body = body;
            this.Created = creationDate;
            this.Author = author;
        }
    }
}
