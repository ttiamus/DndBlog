using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Blog.DAL;
using Blog.Models;
using MongoDB.Bson;

namespace Blog.Services.Services
{
    public class PostService
    {
        private JournalRepo postRepo = new JournalRepo();

        public PostService()
        {
            
        }

        public async Task<bool> CreatePost(JournalEntry journalEntry)
        {
            //TODO: Make an Equals overload method for Post that will check everything but the Id to see if an identical post has been made already. Check for that before insertion
            journalEntry.Id = ObjectId.GenerateNewId().ToString();
            journalEntry.Character = "Atyr";            //TODO: Make this pull the current signed in user
            journalEntry.Created = DateTime.Now;

            return await postRepo.CreateEntry(journalEntry);
        }

        public async Task<JournalEntry> GetEntry(string id)
        {
            return await postRepo.GetEntry(id);
        }

        public async Task<IEnumerable<JournalEntry>> GetEntries()
        {
            return await postRepo.GetPosts();
        }

        public async Task<bool> UpdateEntry(JournalEntry journalEntry)
        {
            journalEntry.LastEdited = DateTime.Now;

            return await postRepo.UpdateEntry(journalEntry);
        }

        public async Task<bool> DeleteEntry(string id)
        {
            return await postRepo.DeleteEntry(id);
        }
    }
}