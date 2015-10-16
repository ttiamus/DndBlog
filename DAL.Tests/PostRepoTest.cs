using System;
using Blog.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace DAL.Tests
{
    [TestClass]
    public class PostRepoTest
    {
        [TestMethod]
        public void CanSavePost()
        {
            var postRepo = new PostRepo();
            postRepo.CreatePost(new Post(1, "UnitTestPost", DateTime.Now, "Ttiamus"));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CanGetAllPosts()
        {
            var postRepo = new PostRepo();
            var posts = postRepo.GetPosts();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CanGetPost()
        {
            var postRepo = new PostRepo();
            var posts = postRepo.GetPost(1);
            Assert.IsTrue(true);
        }
    }

}