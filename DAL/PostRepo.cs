using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace Blog.DAL
{
    public class PostRepo
    {
        public MongoClient Client { get; set; }
        public IMongoDatabase Db { get; set; }
        public IMongoCollection<Post> Posts { get; set; }

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
        private readonly string blogDatabase = ConfigurationManager.AppSettings["BlogDatabase"];
        private readonly string postCollection = ConfigurationManager.AppSettings["PostCollection"];

        public PostRepo()
        {
            //initlaize connection
            Client = new MongoClient(connectionString);
            //get db you are working with
            Db = Client.GetDatabase(blogDatabase);
            //get or create table
            Posts = Db.GetCollection<Post>(postCollection);
        }


        //Id of the post is added to the object after insertion
        public async Task<bool> CreatePost(Post post)
        {
            try
            {
                await Posts.InsertOneAsync(post);
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
            return await Posts.Find(blogPost => blogPost.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await Posts.Find(post => true).ToListAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
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
                await Posts.ReplaceOneAsync(x => x.Id == post.Id, postToBeUpdated);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePost(string id)
        {
            try
            {
                await Posts.DeleteOneAsync(post => post.Id == id);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        
    }
}
