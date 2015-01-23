using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{

    //Three controllers need to be updated since they use ShoppingCart, so makes
    //more sense to put the required changes here and have them extend this.
    public class ControllerBase : Controller
    {
        private IMusicStoreEntities fakeDB;

        protected IMusicStoreEntities StoreDB {
            get {
                return fakeDB;
            }
        }

        public ControllerBase() : this(new MusicStoreEntities()) { }

        public ControllerBase(IMusicStoreEntities storeDb) {
            fakeDB = storeDb;
        }
    }
}
