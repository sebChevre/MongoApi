using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Services;
using MongoApi.Models;

namespace MongoApi.Controllers
{
    public class BeerController : Controller
    {
        private readonly BeerService _beerService;
        private readonly MongoDbService _mongodbService;

        // GET: BeerController

        public BeerController(BeerService beerService, MongoDbService mongoDbService) {
            _beerService = beerService;
            _mongodbService = mongoDbService;
        }
        public ActionResult Index()
        {
            ViewData["beers"] = _beerService.Get();
            ViewData["mongoinfo"] = _mongodbService.getMongoInfo();
            return View();
        }

        public ActionResult Inject()
        {
            ViewData["beers"] = _beerService.Get();
            ViewData["mongoinfo"] = _mongodbService.getMongoInfo();
            return View();
        }

        // GET: BeerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BeerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public String Create(Beer beer)
        {
           
            

            return "ok";
            
        }

        // GET: BeerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BeerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BeerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
