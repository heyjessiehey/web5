using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class PlaylistController : Controller
    {
        private Manager m = new Manager();

        // GET: Playlist
        public ActionResult Index()
        {
            return View(m.PlaylistGetAll());
        }

        // GET: Playlist/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.PlaylistGetByIdWithDetail(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        /*// GET: Playlist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlist/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Playlist/Edit/5
        public ActionResult Edit(int? id)
        {
            var obj = m.PlaylistGetByIdWithDetail(id.GetValueOrDefault());

            if(obj == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = m.mapper.Map<PlaylistEditTracksFormViewModel>(obj);

                var selectedValues = obj.Tracks.Select(t => t.TrackId);

                form.TrackList = new MultiSelectList(
                    items: m.TrackGetAll(),
                    dataValueField: "TrackId",
                    dataTextField: "NameSort",
                    selectedValues: selectedValues
                    ); 
                
                return View(form);
            }
            
        }

        // POST: Playlist/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, PlaylistEditTracksViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = newItem.PlaylistId });
            }

            if (id.GetValueOrDefault() != newItem.PlaylistId)
            {
                return RedirectToAction("Index");
            }

            var editedItem = m.PlaylistEdit(newItem);

            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = newItem.PlaylistId });
            }
            else
            {
                return RedirectToAction("Details", new { id = newItem.PlaylistId });
            }
        }

        /*// GET: Playlist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Playlist/Delete/5
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
