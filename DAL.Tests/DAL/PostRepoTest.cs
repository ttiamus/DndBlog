using System;
using System.Linq;
using System.Runtime.Serialization;
using Blog.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using MongoDB.Bson;

namespace Tests.DAL
{
    [TestClass]
    public class PostRepoTest
    {
        [TestMethod]
        public void CanSavePost()
        {
            var post = new Post("UnitTestPost", "test title", "Ttiamus");
            var postRepo = new PostRepo();
            var insertTask = postRepo.CreatePost(post);
            insertTask.Wait();

            Assert.IsTrue(insertTask.IsCompleted);
        }

        [TestMethod]
        public void CanGetAllPosts()
        {
            var postRepo = new PostRepo();

            var postToInsert = new Post("CanGetAllPosts", "test title", "Ttiamus");
            postRepo.CreatePost(postToInsert).Wait();

            var getAllPostTask = postRepo.GetPosts();
            var posts = getAllPostTask.Result.ToList();
            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        public void CanGetPost()
        {
            var postRepo = new PostRepo();

            var postToInsert = new Post("UnitTestPost", "test title", "Ttiamus");
            
            postRepo.CreatePost(postToInsert).Wait();

            var post = postRepo.GetPost(postToInsert.Id).Result;

            var id1 = postToInsert.Id.ToString();
            var id2 = post.Id.ToString();
            var test = String.Equals(id1, id2);
            Assert.IsTrue(String.Equals(post.Id.ToString(), postToInsert.Id.ToString()));
        }

        [TestMethod]
        public void CanUpdatePost()
        {
            var postRepo = new PostRepo();

            var postToUpdate = new Post("Post To Update", "test title", "Ttiamus");
            postRepo.CreatePost(postToUpdate).Wait();

            var post = new Post("CanUpdatePostTest", "test title", "Ttiamus") {Id = postToUpdate.Id};


            var updatePostTask = postRepo.UpdatePost(post);
            updatePostTask.Wait();
            Assert.AreEqual("CanUpdatePostTest", postRepo.GetPost(postToUpdate.Id).Result.Body);
        }

        [TestMethod]
        public void CanDeletePost()
        {
            var postRepo = new PostRepo();
            var post = new Post("CanDeletePost test", "test title", "Ttiamus");
            postRepo.CreatePost(post).Wait();

            var deletePostTask = postRepo.DeletePost(post.Id);
            deletePostTask.Wait();
            Assert.IsNull(postRepo.GetPost(post.Id).Result);
        }
    }

}