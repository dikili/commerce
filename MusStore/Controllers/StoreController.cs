﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusStore.Models;

namespace MusStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        MusicStoreEntities storeDB=new MusicStoreEntities();

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();

            return View(genres);
        }
        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            return View(genreModel);

        }
        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);

            return View(album);
        }

    }
}
