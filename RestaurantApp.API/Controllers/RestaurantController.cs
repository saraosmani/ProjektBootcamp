using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.API.Data;
using RestaurantApp.API.Data.DTOs.Restaurant;
using RestaurantApp.API.Data.Models;

namespace RestaurantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public RestaurantController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        [HttpGet("GetRestaurant")]
        public IActionResult GetRestaurant()
        {
            var Restaurant = _appDbContext.Restaurant.ToList();
            return Ok(Restaurant);
        }


        [HttpGet("GetRestaurantById/{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            var Restaurant = _appDbContext.Restaurant.FirstOrDefault(x => x.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }

            return Ok(Restaurant);
        }


        [HttpPost("AddRestaurant")]
        public IActionResult AddRestaurant([FromBody] PostRestaurantDTO payload)
        {
            Restaurant newRestaurant = new Restaurant()
            {
                Name = payload.Name,
                PhoneNumber= payload.PhoneNumber,
                Adress = payload.Adress,
                Capacity = payload.Capacity,
                Owner = payload.Owner,
                Cuisine = payload.Cuisine,
                Ratings = payload.Ratings,
                DateCreated = DateTime.UtcNow,

            };

            _appDbContext.Restaurant.Add(newRestaurant);
            _appDbContext.SaveChanges();

            return Ok("Restoranti u krijua me sukses!");
        }


        [HttpPut("UpdateRestaurantById/{id}")]
        public IActionResult UpdateRestaurant([FromBody] PutRestaurantDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var Restaurant = _appDbContext.Restaurant.FirstOrDefault(x => x.Id == id);

            //2. Perditesojme Restorantin e DB me te dhenat e payload-it
            if (Restaurant == null)
                return NotFound();

            Restaurant.Name = payload.Name;
            Restaurant.PhoneNumber = payload.PhoneNumber;
            Restaurant.Adress = payload.Adress;
            Restaurant.Capacity = payload.Capacity;
            Restaurant.Owner = payload.Owner;
            Restaurant.Cuisine = payload.Cuisine;
            Restaurant.Ratings = payload.Ratings;


            //3. Ruhen te dhenat ne database
            _appDbContext.Restaurant.Update(Restaurant);
            _appDbContext.SaveChanges();

            return Ok($"Restoranti me id = {id} u modifikua me sukses!");
        }


        [HttpDelete("DeleteRestaurantById/{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var Restaurant = _appDbContext.Restaurant.FirstOrDefault(x => x.Id == id);

            if (Restaurant == null)
                return NotFound();

            _appDbContext.Restaurant.Remove(Restaurant);
            _appDbContext.SaveChanges();

            return Ok($"Restoranti me id = {id} u fshi me sukses!");
        }


    }
}


