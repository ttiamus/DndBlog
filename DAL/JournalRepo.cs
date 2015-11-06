using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Blog.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace Blog.DAL
{
    public class JournalRepo
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase Db { get; set; }
        public IMongoCollection<JournalEntry> Entries { get; set; }

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
        private readonly string journalDatabase = ConfigurationManager.AppSettings["JournalDatabase"];
        private readonly string entryCollection = ConfigurationManager.AppSettings["EntryCollection"];

        public JournalRepo()
        {
            //initlaize connection
            Client = new MongoClient(connectionString);
            //get db you are working with
            Db = Client.GetDatabase(journalDatabase);
            //get or create table
            Entries = Db.GetCollection<JournalEntry>(entryCollection);
        }


        //Id of the post is added to the object after insertion
        public async Task<bool> CreateEntry(JournalEntry journalEntry)
        {
            try
            {
                await Entries.InsertOneAsync(journalEntry);
            }
            catch (Exception e)
            {
                //Log exception
                return false;
            }

            return true; //Success
        }

        public async Task<JournalEntry> GetEntry(string id)
        {
            return await Entries.Find(blogPost => blogPost.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<JournalEntry>> GetEntries()
        {
            return await Entries.Find(entry => true).ToListAsync();
        }

        public async Task<IEnumerable<JournalEntry>> GetEntries(string character, int startingIndex)
        {
            //For some reason this wasn't working right with string compare
            return await Entries.Find(entry => entry.Character.ToLower() == character.ToLower()).SortByDescending(entry => entry.Created).Skip(startingIndex).Limit(5).ToListAsync();
        }

        public async Task<bool> UpdateEntry(JournalEntry journalEntry)
        {
            var entryToBeUpdated = await GetEntry(journalEntry.Id);

            if (entryToBeUpdated == null)
            {
                return false;   //Can't find post so bail out
            }

            entryToBeUpdated.Character = journalEntry.Character;
            entryToBeUpdated.Title = journalEntry.Title;
            entryToBeUpdated.Body = journalEntry.Body;
            entryToBeUpdated.LastEdited = DateTime.Now;
            

            try
            {
                await Entries.ReplaceOneAsync(x => x.Id == journalEntry.Id, entryToBeUpdated);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteEntry(string id)
        {
            try
            {
                await Entries.DeleteOneAsync(post => post.Id == id);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        
    }
}
