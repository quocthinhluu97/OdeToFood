﻿using System.Linq;
using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Scott's",
                    Location = "MaryLand",
                    Cuisine = CuisineType.Indian
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Peter's",
                    Location = "HolyLand",
                    Cuisine = CuisineType.Italian
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "John's",
                    Location = "Ali",
                    Cuisine = CuisineType.Mexican
                }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r=>r.Id == id);
        }
    }
}