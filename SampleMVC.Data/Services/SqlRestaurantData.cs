using SampleMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext DbContext;
        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public void Add(Restaurant restaurant)
        {
            DbContext.Restaurants.Add(restaurant);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = DbContext.Restaurants.Find(id);
            DbContext.Restaurants.Remove(restaurant);
            DbContext.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return DbContext.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return DbContext.Restaurants;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entry = DbContext.Entry(restaurant);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
            return restaurant;
        }
    }
}
