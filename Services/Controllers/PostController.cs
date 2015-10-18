using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Blog.DAL;
using Blog.Services.Services;
using Models;

namespace Blog.Services.Controllers
{
    //TODO: Consider moving creation of status message into service. This will allow to change the message based on what happens
    //Status code descriptions http://www.restapitutorial.com/lessons/httpmethods.html

    public class PostController : ApiController
    {
        private PostService postService = new PostService();

        public PostController()
        {
            
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> CreatePost(Post post)
        {
            var success = await postService.CreatePost(post);
            if (!success)
            {
                return Conflict();
            }

            return Ok();
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetPost(string id)
        {
            var post = await postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetPosts()
        {
            var posts = await postService.GetPosts();

            if (!posts.Any())
            {
                return NotFound();
            }

            return Ok(posts);
        }

        
        [System.Web.Http.HttpPut]
        public async Task<IHttpActionResult> UpdatePost(Post post)
        {
            var success = await postService.UpdatePost(post);
            if (!success)
            {
                return NotFound();
            }

            return Ok("Post was updated successfully");

        }

        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeletePost(string id)
        {
            var success = await postService.DeletePost(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok("Post was deleted successfully");

        }
    }
}
