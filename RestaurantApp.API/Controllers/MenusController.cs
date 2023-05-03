using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.API.Data;
using RestaurantApp.API.Data.DTOs.Menu;
using RestaurantApp.API.Data.Models;

namespace RestaurantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public MenusController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet("GetMenuById/{id}")]
        public IActionResult GetMenu(int id)
        {
            var Menu = _appDbContext.Menus.FirstOrDefault(x => x.Id == id);
            if (Menu == null)
            {
                return NotFound();
            }

            return Ok(Menu);
        }


        [HttpPost("AddMenu")]
        public IActionResult AddMenu([FromBody] PostMenuDTO payload)
        {
            //1. Krijo nje objekt Menu me te dhenat e marra nga payload
            Menu newMenu = new Menu()
            {
                Name=payload.Name,
                Dishes = payload.Dishes,
                Description = payload.Description,
                DateCreated = DateTime.UtcNow,
                Price = payload.Price,

                RestaurantId = payload.RestaurantId
            };

            _appDbContext.Menus.Add(newMenu);
            _appDbContext.SaveChanges();

            return Ok("Menuja u krijua me sukses!");
        }


        [HttpPut("UpdateMenuById/{id}")]
        public IActionResult UpdateMenu([FromBody] PutMenuDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var Menu = _appDbContext.Menus.FirstOrDefault(x => x.Id == id);
            if (Menu == null)
                return NotFound();

            //2. Perditesojme menune e DB me te dhenat e payload-it
            Menu.Name = payload.Name;
            Menu.Dishes = payload.Dishes;
            Menu.Description = payload.Description;
            Menu.Price = payload.Price;

            //Add Refrence to Restaurant Id
            Menu.RestaurantId = payload.RestaurantId;

            //3. Ruhen te dhenat ne database
            _appDbContext.Menus.Update(Menu);
            _appDbContext.SaveChanges();

            return Ok($"Menuja me id= {id} u modifikua me sukses!");
        }

        [HttpDelete("DeleteMenuById/{id}")]
        public IActionResult DeleteMenu(int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var Menu = _appDbContext.Menus.FirstOrDefault(x => x.Id == id);
            if (Menu == null)
                return NotFound();

            //2. Fshijme menune nga DB
            _appDbContext.Menus.Remove(Menu);
            _appDbContext.SaveChanges();

            return Ok($"Menuja me id = {id} u fshi me sukses!");
        }

    }
}
