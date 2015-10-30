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

        /// <summary>
        /// Calls repo to save a new post after generating an Id and createDate
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        public async Task<bool> CreateEntry(JournalEntry journalEntry)
        {
            //TODO: Make an Equals overload method for Post that will check everything but the Id to see if an identical post has been made already. Check for that before insertion
            journalEntry.Id = ObjectId.GenerateNewId().ToString();
            //journalEntry.Character = "Atyr";            //TODO: Make sure this is the signed in user if we can't pass it from the UI
            journalEntry.Created = DateTime.Now;

            return await journalRepo.CreateEntry(journalEntry);
        }

        /// <summary>
        /// Calls the repo to get the entry with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JournalEntry> GetEntry(string id)
        {
            return await journalRepo.GetEntry(id);
        }

        /// <summary>
        /// Calls the repo to get all of the entries in the db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<JournalEntry>> GetEntries()
        {
            return await journalRepo.GetEntries();
        }

        /// <summary>
        /// Calls the repo to get the next 5 entries for a given character after the given index
        /// </summary>
        /// <param name="character"></param>
        /// <param name="startingIndex"></param>
        /// <returns></returns>
        public async Task<IEnumerable<JournalEntry>> GetEntries(string character, int startingIndex)
        {
            //TODO: Make the date prettier somehow
            return await journalRepo.GetEntries(character, startingIndex);
        }

        /// <summary>
        /// Calls the repo to update the given entry with its new values
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        public async Task<bool> UpdateEntry(JournalEntry journalEntry)
        {
            journalEntry.LastEdited = DateTime.Now;

            return await journalRepo.UpdateEntry(journalEntry);
        }

        /// <summary>
        /// Calls the repo to Delete entry with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEntry(string id)
        {
            return await journalRepo.DeleteEntry(id);
        }
    }
}