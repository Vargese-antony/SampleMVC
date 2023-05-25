using SampleMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace SampleMVC.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Pizza corner", Cuisine = CusineType.Italian},
                new Restaurant{ Id = 2, Name = "Punjab Tadka", Cuisine = CusineType.Indian},
                new Restaurant{ Id = 3, Name = "Madrin", Cuisine = CusineType.Chinese}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(x => x.Id) + 1;
            restaurants.Add(restaurant);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var restauranatToModify = restaurants.Find(x => x.Id == restaurant.Id);
            if(restauranatToModify != null)
            {
                restauranatToModify.Name = restaurant.Name;
                restauranatToModify.Cuisine = restaurant.Cuisine;
            }
            return restauranatToModify;
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy( x => x.Name);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
