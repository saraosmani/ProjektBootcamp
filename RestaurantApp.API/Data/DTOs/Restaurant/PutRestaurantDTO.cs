using RestaurantApp.API.Data.Base;

namespace RestaurantApp.API.Data.DTOs.Restaurant
{
    public class PutRestaurantDTO
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int Capacity { get; set; } //represents the maximum number of customers the restaurant can accommodate
        public string Owner { get; set; }
        public string Cuisine { get; set; } //represents the type of cuisine served at the restaurant
        public int Ratings { get; set; } //represents the ratings given by customers to the restaurant (on a scale of 1 to 5, for example)

        
    }
}
