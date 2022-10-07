using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContatosMVC.Data;
using ContatosMVC.Models;

namespace ContatosMVC.Controllers
{
    public class DominioController : Controller
    {
        // GET: DominioController
        public ActionResult Gmail()
        {
            return View();
        }

    }
}
