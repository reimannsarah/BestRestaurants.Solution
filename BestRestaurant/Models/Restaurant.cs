using System.Collections.Generic;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public int Restaurant { get; set; }
    public string Description { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
  }
}