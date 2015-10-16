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
        public async void CreatePost(Post post)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("test");
            //get or create table
            var posts = db.GetCollection<Post>("BlogPosts");
            await posts.InsertOneAsync(post);
        }

        public List<Post>  GetPosts()
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("test");
            var posts = db.GetCollection<Post>("BlogPosts").Find(post => true).ToListAsync().Result;
            
            return posts;
        }

        public Post GetPost(int id)
        {
            //initlaize connection
            var client = new MongoClient();
            //get db you are working with
            var db = client.GetDatabase("test");
            var posts = db.GetCollection<Post>("BlogPosts");
            var post = posts.Find(blogPost => blogPost.Author == "Ttiamus").FirstOrDefaultAsync().Result;

            
            return post;
        }

        public async void UpdatePost(Post post)
        {

        }

        public async void DeletePost(int id)
        {
            
        }

        
    }
}
