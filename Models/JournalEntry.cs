using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class JournalEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //Makes it so it is saved to the db as an ObjectId, but is manipulated as a string
        public string Id { get; set; }

        public string Character { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Created { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? LastEdited { get; set; }

        public JournalEntry()
        {

        }

        public JournalEntry(string character, string title, string body)
        {
            this.Character = character;
            this.Title = title;
            this.Body = body;
            this.Created = DateTime.Now;
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
