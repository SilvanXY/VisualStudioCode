using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reitturnier.Helpers;
using Reitturnier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reitturnier.Controllers
{
    public class BesitzerController : Controller
    {
        private DbReitturnier dbReitturnier;
        public BesitzerController(DbReitturnier dbReitturnier)
        {
            this.dbReitturnier = dbReitturnier;
        }

        public async Task<IActionResult> Index()
        {
            var besitzer = await dbReitturnier.Besitzer.ToListAsync();

            return View(besitzer);
        }

        public async Task<IActionResult> Details(int? rowguid)
        {
            if (rowguid == null)
            {
                return NotFound();
            }

            var besitzer = await dbReitturnier.Besitzer.FirstOrDefaultAsync(b => b.Rowguid == rowguid);

            if (besitzer == null)
            {
                return NotFound();
            }

            return View(besitzer);
        }
        public async Task<IActionResult> Delete(int? rowguid)
        {
            if (rowguid == null)
            {
                return NotFound();
            }

            var besitzer = await dbReitturnier.Besitzer.FirstOrDefaultAsync(b => b.Rowguid == rowguid);

            if (besitzer == null)
            {
                return NotFound();
            }

            return View(besitzer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int rowguid)
        {
            var besitzer = await dbReitturnier.Besitzer.FirstOrDefaultAsync(b => b.Rowguid == rowguid);

            if (besitzer == null)
            {
                return NotFound();
            }

            dbReitturnier.Besitzer.Remove(besitzer);
            await dbReitturnier.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddOrEdit(int? rowguid)
        {
            ViewBag.PageName = rowguid == null ? "Hinzufügen Besitzer" : "Bearbeiten Besitzer";
            ViewBag.IsEdit = rowguid == null ? false : true;

            if (rowguid == null)
            {
                return View();
            }
            else
            {
                var besitzer = await dbReitturnier.Besitzer.FirstOrDefaultAsync(b => b.Rowguid == rowguid);

                if (besitzer == null)
                {
                    return NotFound();
                }

                return View(besitzer);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int rowguid, [Bind("Nachname, Vorname, Strasse, PLZ, Ort")] Besitzer besitzerData)
        {
            var besitzer = await dbReitturnier.Besitzer.FirstOrDefaultAsync(b => b.Rowguid == rowguid);

            bool IsBesitzerExists = false;

            if (besitzer == null)
                besitzer = new Models.Besitzer();
            else
                IsBesitzerExists = true;

            besitzer.Vorname = besitzerData.Vorname;
            besitzer.Nachname = besitzerData.Nachname;
            besitzer.Strasse = besitzerData.Strasse;
            besitzer.Ort = besitzerData.Ort;
            besitzer.PLZ = besitzerData.PLZ;



            if (IsBesitzerExists)
            {
                dbReitturnier.Besitzer.Update(besitzer);
            }
                 
            else
            {
                dbReitturnier.Besitzer.Add(besitzer);
            }
                
            await dbReitturnier.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
