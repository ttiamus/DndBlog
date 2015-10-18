using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Blog.DAL;
using Models;
using MongoDB.Bson;

namespace Blog.Services.Services
{
    public class PostService
    {
        private PostRepo postRepo = new PostRepo();

        public PostService()
        {
            
        }

        public async Task<bool> CreatePost(Post post)
        {
            //TODO: Make an Equals overload method for Post that will check everything but the Id to see if an identical post has been made already. Check for that before insertion
            post.Id = ObjectId.GenerateNewId().ToString();
            post.Created = DateTime.Now;

            return await postRepo.CreatePost(post);
        }

        public async Task<Post> GetPost(string id)
        {
            //return await GetPost(ObjectId.Parse(id));
            return await postRepo.GetPost(id);
        }

        /*public async Task<Post> GetPost(ObjectId id)
        {
            return await postRepo.GetPost(id);
        }*/

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await postRepo.GetPosts();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            post.LastEdited = DateTime.Now;

            return await postRepo.UpdatePost(post);
        }

        public async Task<bool> DeletePost(string id)
        {
            //return await DeletePost(ObjectId.Parse(id));
            return await postRepo.DeletePost(id);
        }

        /*public async Task<bool> DeletePost(ObjectId id)
        {
            return await postRepo.DeletePost(id);
        }*/
    }
}