﻿using System.Data.Entity;

namespace MvcMusicStore.Models
{
    public class MusicStoreEntities : DbContext, IMusicStoreEntities
    {
        //Dbset is an implementation of IDbSet
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
    }
}