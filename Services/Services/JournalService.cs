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
    public class JournalService
    {
        private readonly JournalRepo journalRepo = new JournalRepo();

        public JournalService()
        {
            
        }

        public async Task<bool> CreateEntry(JournalEntry journalEntry)
        {
            //TODO: Make an Equals overload method for Post that will check everything but the Id to see if an identical post has been made already. Check for that before insertion
            journalEntry.Id = ObjectId.GenerateNewId().ToString();
            journalEntry.Character = "Atyr";            //TODO: Make this pull the current signed in user
            journalEntry.Created = DateTime.Now;

            return await journalRepo.CreateEntry(journalEntry);
        }

        public async Task<JournalEntry> GetEntry(string id)
        {
            return await journalRepo.GetEntry(id);
        }

        public async Task<IEnumerable<JournalEntry>> GetEntries()
        {
            return await journalRepo.GetEntries();
        }

        public async Task<IEnumerable<JournalEntry>> GetEntries(string character, int startingIndex)
        {
            return await journalRepo.GetEntries(character, startingIndex);
        }

        public async Task<bool> UpdateEntry(JournalEntry journalEntry)
        {
            journalEntry.LastEdited = DateTime.Now;

            return await journalRepo.UpdateEntry(journalEntry);
        }

        public async Task<bool> DeleteEntry(string id)
        {
            return await journalRepo.DeleteEntry(id);
        }
    }
}