using System.Collections.Generic;
using System.Web.Http;

namespace DndBlog.Services
{
    public class PostController : ApiController
    {
        public List<string> test = new List<string> { "hello", "world!", "one more for good luck!" };


        [HttpGet]
        public IEnumerable<string> GetAllPosts()
        {
            return test;
        }

        [HttpGet]
        public IEnumerable<string> GetPostById(int id)
        {
            return test;
        }


        [HttpPut]
        public bool UpdatePost(int id)
        {
            return true;
        }

        [HttpPost]
        public void Post(string post)
        {
            //save post to db
        }
    }
}
