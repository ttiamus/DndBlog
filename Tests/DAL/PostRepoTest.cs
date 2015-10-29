using System;
using System.Linq;
using System.Runtime.Serialization;
using Blog.DAL;
using Blog.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace Tests.DAL
{
    [TestClass]
    public class PostRepoTest
    {
        [TestMethod]
        public void CanSavePost()
        {
            var post = new JournalEntry("UnitTestPost", "test title", "Ttiamus");
            var postRepo = new JournalRepo();
            var insertTask = postRepo.CreateEntry(post);
            insertTask.Wait();

            Assert.IsTrue(insertTask.IsCompleted);
        }

        [TestMethod]
        public void CanGetAllPosts()
        {
            var postRepo = new JournalRepo();

            var postToInsert = new JournalEntry("CanGetAllPosts", "test title", "Ttiamus");
            postRepo.CreateEntry(postToInsert).Wait();

            var getAllPostTask = postRepo.GetPosts();
            var posts = getAllPostTask.Result.ToList();
            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        public void CanGetPost()
        {
            var postRepo = new JournalRepo();

            var postToInsert = new JournalEntry("UnitTestPost", "test title", "Ttiamus");
            
            postRepo.CreateEntry(postToInsert).Wait();

            var post = postRepo.GetEntry(postToInsert.Id).Result;

            var id1 = postToInsert.Id.ToString();
            var id2 = post.Id.ToString();
            var test = String.Equals(id1, id2);
            Assert.IsTrue(String.Equals(post.Id.ToString(), postToInsert.Id.ToString()));
        }

        [TestMethod]
        public void CanUpdatePost()
        {
            var postRepo = new JournalRepo();

            var postToUpdate = new JournalEntry("Post To Update", "test title", "Ttiamus");
            postRepo.CreateEntry(postToUpdate).Wait();

            var post = new JournalEntry("CanUpdatePostTest", "test title", "Ttiamus") {Id = postToUpdate.Id};


            var updatePostTask = postRepo.UpdateEntry(post);
            updatePostTask.Wait();
            Assert.AreEqual("CanUpdatePostTest", postRepo.GetEntry(postToUpdate.Id).Result.Body);
        }

        [TestMethod]
        public void CanDeletePost()
        {
            var postRepo = new JournalRepo();
            var post = new JournalEntry("CanDeletePost test", "test title", "Ttiamus");
            postRepo.CreateEntry(post).Wait();

            var deletePostTask = postRepo.DeleteEntry(post.Id);
            deletePostTask.Wait();
            Assert.IsNull(postRepo.GetEntry(post.Id).Result);
        }
    }

}