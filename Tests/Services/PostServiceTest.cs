using System;
using System.Linq;
using Blog.DAL;
using Blog.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace DAL.Tests.Services
{
    [TestClass]
    public class PostServiceTest
    {
        [TestMethod]
        public void CanSavePost()
        {
            var post = new Post("UnitTestPost", "test title", "Ttiamus");
            PostService postService = new PostService();

            var insertTask = postService.CreatePost(post);

            Assert.IsTrue(insertTask.Result);
        }

        [TestMethod]
        public void CanGetAllPosts()
        {
            PostService postService = new PostService();

            var postToInsert = new Post("CanGetAllPosts", "test title", "Ttiamus");
            postService.CreatePost(postToInsert).Wait();

            var getAllPostTask = postService.GetPosts();
            var posts = getAllPostTask.Result.ToList();
            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        public void CanGetPost()
        {
            PostService postService = new PostService();

            var postToInsert = new Post("UnitTestPost", "test title", "Ttiamus");

            postService.CreatePost(postToInsert).Wait();

            var post = postService.GetPost(postToInsert.Id).Result;

            var id1 = postToInsert.Id.ToString();
            var id2 = post.Id.ToString();
            var test = String.Equals(id1, id2);
            Assert.IsTrue(String.Equals(post.Id.ToString(), postToInsert.Id.ToString()));
        }

        [TestMethod]
        public void CanUpdatePost()
        {
            PostService postService = new PostService(); ;

            var postToUpdate = new Post("Post To Update", "test title", "Ttiamus");
            postService.CreatePost(postToUpdate).Wait();

            var post = new Post("CanUpdatePostTest", "test title", "Ttiamus") {Id = postToUpdate.Id };


            var updatePostTask = postService.UpdatePost(post);
            updatePostTask.Wait();
            Assert.AreEqual("CanUpdatePostTest", postService.GetPost(postToUpdate.Id).Result.Body);
        }

        [TestMethod]
        public void CanDeletePost()
        {
            PostService postService = new PostService();
            var post = new Post("CanDeletePost test", "test title", "Ttiamus");
            postService.CreatePost(post).Wait();

            var deletePostTask = postService.DeletePost(post.Id);
            deletePostTask.Wait();
            Assert.IsNull(postService.GetPost(post.Id).Result);
        }
    }
}