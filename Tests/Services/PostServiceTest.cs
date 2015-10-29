using System;
using System.Linq;
using Blog.DAL;
using Blog.Models;
using Blog.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Tests.Services
{
    [TestClass]
    public class PostServiceTest
    {
        [TestMethod]
        public void CanSavePost()
        {
            var post = new JournalEntry("UnitTestEntry", "test title", "Ttiamus");
            PostService postService = new PostService();

            var insertTask = postService.CreatePost(post);

            Assert.IsTrue(insertTask.Result);
        }

        [TestMethod]
        public void CanGetAllPosts()
        {
            PostService postService = new PostService();

            var postToInsert = new JournalEntry("CanGetAllEntries", "test title", "Ttiamus");
            postService.CreatePost(postToInsert).Wait();

            var getAllPostTask = postService.GetEntries();
            var posts = getAllPostTask.Result.ToList();
            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        public void CanGetPost()
        {
            PostService postService = new PostService();

            var postToInsert = new JournalEntry("UnitTestEntry", "test title", "Ttiamus");

            postService.CreatePost(postToInsert).Wait();

            var post = postService.GetEntry(postToInsert.Id).Result;

            Assert.IsTrue(String.Equals(post.Id, postToInsert.Id));
        }

        [TestMethod]
        public void CanUpdatePost()
        {
            PostService postService = new PostService(); ;

            var postToUpdate = new JournalEntry("Entry To Update", "test title", "Ttiamus");
            postService.CreatePost(postToUpdate).Wait();

            var post = new JournalEntry("CanUpdateEntryTest", "test title", "Ttiamus") {Id = postToUpdate.Id };


            var updatePostTask = postService.UpdateEntry(post);
            updatePostTask.Wait();
            Assert.AreEqual("CanUpdateEntryTest", postService.GetEntry(postToUpdate.Id).Result.Body);
        }

        [TestMethod]
        public void CanDeletePost()
        {
            PostService postService = new PostService();
            var post = new JournalEntry("CanDeleteEntry test", "test title", "Ttiamus");
            postService.CreatePost(post).Wait();

            var deletePostTask = postService.DeleteEntry(post.Id);
            deletePostTask.Wait();
            Assert.IsNull(postService.GetEntry(post.Id).Result);
        }
    }
}