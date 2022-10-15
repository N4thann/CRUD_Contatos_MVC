using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContatosMVC.Data;
using ContatosMVC.Models;

namespace ContatosMVC.Controllers
{
    public class DominioController : Controller
    {
       private readonly NZContext _context;

       public DominioController(NZContext context)
       {
                _context = context;
       }
       public async Task<IActionResult> Index()
       {
          return View();
       }

      public async Task<IActionResult> Gmail()
       {
            var contatosGmail = from s in _context.Contatos select s;

            contatosGmail = contatosGmail.Where(s => s.Email.Contains("gmail"));


            return View(await contatosGmail.ToListAsync());
       }

       public async Task<IActionResult> Hotmail()
        {
            var contatosHotmail = from s in _context.Contatos select s;

            contatosHotmail = contatosHotmail.Where(s => s.Email.Contains("hotmail"));

            return View(await contatosHotmail.ToListAsync());
        }
        public async Task<IActionResult> Outlook()
        {
            var contatosOutlook = from s in _context.Contatos select s;

            contatosOutlook = contatosOutlook.Where(s => s.Email.Contains("outlook"));

            return View(await contatosOutlook.ToListAsync());
        }
        public async Task<IActionResult> Outros()
        {
            var contatosOutros = from s in _context.Contatos select s;

            contatosOutros = contatosOutros.Where(s => !s.Email.Contains("gmail") &&
                                                    !s.Email.Contains("outlook") &&
                                                    !s.Email.Contains("hotmail"));
            return View(await contatosOutros.ToListAsync());
        }



    }
}
