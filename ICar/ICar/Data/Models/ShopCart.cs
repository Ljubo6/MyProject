
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContext appDbContext;

        public ShopCart(AppDbContext appDbContext)
        {
            this.ListShopItems = new HashSet<ShopCartItem>();
            this.appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }
        public ICollection<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId",shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            appDbContext.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price,
            });

            appDbContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDbContext.ShopCartItem
                .Where(c => c.ShopCartId == ShopCartId)
                .Include(s => s.Car)
                .ToList();
        }
    }
}
