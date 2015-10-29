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

    public class PostController : ApiController
    {
        private PostService postService = new PostService();

        public PostController()
        {
            
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> CreatePost(JournalEntry journalEntry)
        {
            var success = await postService.CreatePost(journalEntry);
            if (!success)
            {
                return Conflict();
            }

            return Ok();
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetEntry(string id)
        {
            var post = await postService.GetEntry(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetEntry()
        {
            var entries = await postService.GetEntries();

            if (!entries.Any())
            {
                return NotFound();
            }

            return Ok(entries);
        }

        
        [System.Web.Http.HttpPut]
        public async Task<IHttpActionResult> UpdateEntry(JournalEntry journalEntry)
        {
            var success = await postService.UpdateEntry(journalEntry);
            if (!success)
            {
                return NotFound();
            }

            return Ok("Post was updated successfully");

        }

        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteEntry(string id)
        {
            var success = await postService.DeleteEntry(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok("Post was deleted successfully");

        }
    }
}
