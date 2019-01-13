using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning! :)" : "Good AfterNoon! :)";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View("RsvpForm");
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // TO DO: store response from guest
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View("RsvpForm");
            }

            Repository.AddResponse(guestResponse); //added to the model Respository made


            return View("Thanks", guestResponse); //passes info from guestResponse into the view
        }

        public ViewResult ListResponses()
        {
            return View("ListResponses", Repository.Responses.Where(r => r.WillAttend == true)); //LINK things
        }



    }
}
