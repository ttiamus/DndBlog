using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.DAL
{
    public class PostRepo
    {
        //Id of the post is added to the object after insertion
        public async Task CreatePost(Post post)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            //get or create table
            var posts = db.GetCollection<Post>("Posts");
            await posts.InsertOneAsync(post);
            
        }

        public async Task<List<Post>> GetPosts()
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            return await db.GetCollection<Post>("Posts").Find(post => true).ToListAsync();
        }

        public async Task<Post> GetPost(ObjectId id)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            var posts = db.GetCollection<Post>("Posts");
            return await posts.Find(blogPost => blogPost.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdatePost(Post post)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            var posts = db.GetCollection<Post>("Posts");

            var postToBeUpdated = GetPost(post.Id).Result;

            postToBeUpdated.Author = post.Author;
            postToBeUpdated.LastEdited = DateTime.Now;
            postToBeUpdated.Body = post.Body;

            await posts.ReplaceOneAsync(x => x.Id == post.Id, postToBeUpdated);
        }

        public async Task DeletePost(ObjectId id)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("DndBlog");
            var posts = db.GetCollection<Post>("Posts");
            await posts.DeleteOneAsync(post => post.Id == id);
        }

        
    }
}
