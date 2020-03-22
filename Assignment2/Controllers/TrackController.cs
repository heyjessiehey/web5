using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class TrackController : Controller
    {
        private Manager m = new Manager();

        // GET: Track
        public ActionResult Index()
        {
            return View(m.TrackGetAllWithDetails());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.TrackGetByIdWithDetail(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            var form = new TrackAddFormViewModel
            {
                AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title"),
                MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name")
            };

            return View(form);
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(TrackAddViewModel newTrack)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }

            var addedItem = m.TrackAdd(newTrack);

            if (addedItem == null)
                return View(newTrack);
            else
                return RedirectToAction("details", new { id = addedItem.TrackId });
        }

        /*// GET: Track/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Track/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Track/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
