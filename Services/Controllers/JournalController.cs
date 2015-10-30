using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Blog.DAL;
using Blog.Models;
using Blog.Services.Services;

namespace Blog.Services.Controllers
{
    //TODO: Consider moving creation of status message into service. This will allow to change the message based on what happens
    //TODO: Look into JSONP format POSt to get around cross domain issues
    //Status code descriptions http://www.restapitutorial.com/lessons/httpmethods.html

    public class JournalController : ApiController
    {
        private readonly JournalService journalService = new JournalService();

        /// <summary>
        /// Create a new journal entry
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> CreateEntry(JournalEntry journalEntry)
        {
            var success = await journalService.CreateEntry(journalEntry);
            if (!success)
            {
                return Conflict();
            }

            return Ok();
        }


        /// <summary>
        /// Get a journal entry by unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetEntry(string id)
        {
            var post = await journalService.GetEntry(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        /// <summary>
        /// Get the 5 entries after startingIndex for a given character
        /// </summary>
        /// <param name="character"></param>
        /// <param name="startingIndex"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetEntries(string character, int startingIndex)
        {
            var entries = await journalService.GetEntries(character, startingIndex);

            if (!entries.Any())
            {
                return NotFound();
            }

            return Ok(entries);
        }

        /// <summary>
        /// Get all entries
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetEntries()
        {
            var entries = await journalService.GetEntries();

            if (!entries.Any())
            {
                return NotFound();
            }

            return Ok(entries);
        }

        /// <summary>
        /// Updates an entry with the given id
        /// </summary>
        /// <param name="journalEntry"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public async Task<IHttpActionResult> UpdateEntry(JournalEntry journalEntry)
        {
            var success = await journalService.UpdateEntry(journalEntry);
            if (!success)
            {
                return NotFound();
            }

            return Ok("Post was updated successfully");

        }

        /// <summary>
        /// Deletes an entry with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteEntry(string id)
        {
            var success = await journalService.DeleteEntry(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok("Post was deleted successfully");

        }
    }
}
