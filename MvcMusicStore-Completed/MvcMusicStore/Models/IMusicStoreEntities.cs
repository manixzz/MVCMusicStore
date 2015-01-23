using System;
using System.Data.Entity;
namespace MvcMusicStore.Models
{
    public interface IMusicStoreEntities : IDisposable
    {
        IDbSet<Album> Albums { get; set; }
        IDbSet<Artist> Artists { get; set; }
        IDbSet<Cart> Carts { get; set; }
        IDbSet<Genre> Genres { get; set; }
        IDbSet<OrderDetail> OrderDetails { get; set; }
        IDbSet<Order> Orders { get; set; }

        //int because System.Data.Entity.DbContext.SaveChanges is type int, so it will implement this
        int SaveChanges();
    }
}
