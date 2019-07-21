using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class VoiceController : Controller
    {
        

        // GET: Voice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}