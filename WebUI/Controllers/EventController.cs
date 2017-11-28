using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.AspNetCore.Identity;
using DataAccess.Entity;
using Service.DTO;

namespace WebUI.Controllers
{
    public class EventController : Controller
    {

        private IEventService eventService;
        private readonly UserManager<User> userManager;


        public EventController(IEventService evService, UserManager<User> userManager)
        {
            eventService = evService;
            this.userManager = userManager;
        }

        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var model = this.eventService.GetEventById(id, out Treatment tr);

            if (tr.IsSuccess())
            {
                return View(model);
            }

            // if we get here, there was a problem
            return RedirectToAction("Home", "Index");
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var user = userManager.GetUserId(User);

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            var userClaim = this.User;
            var userId = userManager.GetUserId(userClaim);

            EventDto ev = eventService.GetEventById(id, out Treatment tr);

            return View(ev);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}