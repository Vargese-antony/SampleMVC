using SampleMVC.Data.Models;
using SampleMVC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleMVC.Web.Api
{
    public class RestaurantsController : ApiController
    {
        IRestaurantData restaurantData;
        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IEnumerable<Restaurant> Get()
        {
            return restaurantData.GetAll();
        }
    }
}
