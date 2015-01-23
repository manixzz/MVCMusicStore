using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using System.Data.Entity;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            var artists = storeDB.Artists.OrderByDescending(a => a.Albums.Count()).Take(5).ToList();
            ViewData["artists"] = artists;
            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);
            ViewData["artists"] = storeDB.Albums.Include("Artist").Where(g => g.Genre.Name == genre).Select(a => a.Artist).Distinct().ToList();
            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);

            return View(album);
        }

        // GET: /Store/ArtistDetails/61

        //Call the view to display Artist details (Name, Number of Albums, and list of genres associated with the artist)
        public ActionResult ArtistDetails(int id) {

            var artist = storeDB.Artists.Find(id);
            artist.NumberOfAlbums = storeDB.Albums.Where(a => a.ArtistId == artist.ArtistId).Count();
            artist.ListOfGenres = storeDB.Albums.Include("Genre").Where(a => a.ArtistId == artist.ArtistId).Select(g => g.Genre).Distinct().ToList();
            return View(artist);
        
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();

            return PartialView(genres);
        }

    }
}