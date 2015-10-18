using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.DAL
{
    public class PostRepo
    {
        //Id of the post is added to the object after insertion
        public async Task<bool> CreatePost(Post post)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            //get or create table
            var posts = db.GetCollection<Post>("Posts");

            try
            {
                await posts.InsertOneAsync(post);
            }
            catch (Exception e)
            {
                //Log exception
                return false;
            }

            return true; //Success
        }

        public async Task<Post> GetPost(string id)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            var posts = db.GetCollection<Post>("Posts");
            return await posts.Find(blogPost => blogPost.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            return await db.GetCollection<Post>("Posts").Find(post => true).ToListAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            var posts = db.GetCollection<Post>("Posts");

            var postToBeUpdated = await GetPost(post.Id);

            if (postToBeUpdated == null)
            {
                return false;   //Can't find post so bail out
            }

            postToBeUpdated.Author = post.Author;
            postToBeUpdated.Title = post.Title;
            postToBeUpdated.Body = post.Body;
            postToBeUpdated.LastEdited = DateTime.Now;
            

            try
            {
                await posts.ReplaceOneAsync(x => x.Id == post.Id, postToBeUpdated);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePost(string id)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            var posts = db.GetCollection<Post>("Posts");
            try
            {
                await posts.DeleteOneAsync(post => post.Id == id);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        
    }
}
