﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /* ActionResult Posts()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Quartermaster()
        {
            return View();
        }*/
    }
}