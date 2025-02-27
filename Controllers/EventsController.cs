using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Services;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entity;


namespace WebApplication1.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        { 
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync();

            return View(allEvents);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create([Bind("ImagePath,EventName,Description,Location,Date,TicketPrice,TotalTickets,AvaliableTickets,DateCreated")] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }
            await _service.AddAsync(@event);
            return RedirectToAction(nameof(Index));
         }

        [AllowAnonymous]
        public async Task<IActionResult>Details(int id)
             {
                var eventDetails = await _service.GetByIdAsync(id);
                if (eventDetails == null) return View("NotFound");
                return View(eventDetails);
             }
        //get actors/create
        public async Task< IActionResult> Edit(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(int id, [Bind("EventId,EventName,Description,Location,Date,TicketPrice,TotalTickets,AvaliableTickets,DateCreated")] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }
            await _service.UpdateAsync(id,@event);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _service.GetByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }   
}
