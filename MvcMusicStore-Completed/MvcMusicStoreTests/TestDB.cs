using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcMusicStore.Models;

namespace MvcMusicStoreTests
{
    class TestDB : IMusicStoreEntities
    {
        //Leaving System.Data.Entity here because for some reason it breaks if I change it, it breaks the program
        public System.Data.Entity.IDbSet<Album> Albums { get; set; }

        public System.Data.Entity.IDbSet<Artist> Artists { get; set; }

        public System.Data.Entity.IDbSet<Cart> Carts { get; set; }

        public System.Data.Entity.IDbSet<Genre> Genres { get; set; }

        public System.Data.Entity.IDbSet<OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.IDbSet<Order> Orders { get; set; }

        public virtual int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {

        }
    }
}
