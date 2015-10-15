using System;

namespace Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Post
    {
        public string Body { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }


        public Post()
        {
            
        }
    }
}
