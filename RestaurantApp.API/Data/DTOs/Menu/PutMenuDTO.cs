﻿using RestaurantApp.API.Data.Base;

namespace RestaurantApp.API.Data.DTOs.Menu
{
    public class PutMenuDTO 
    {
        public string Name { get; set; }
        public string Dishes { get; set; }
        public string Description { get; set; } //represents a brief description of the menu
        public double Price { get; set; }

        //Add a reference to Restaurant table
        public int RestaurantId { get; set; }
    }

}
