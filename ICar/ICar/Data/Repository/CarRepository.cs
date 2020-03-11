using ICar.Data.Intrfaces;
using ICar.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContext appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Car> Cars => appDbContext.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavcars => appDbContext.Car.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car objectCar(int carId) => appDbContext.Car.FirstOrDefault(p => p.Id == carId);

    }
}
