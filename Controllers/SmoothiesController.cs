using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmoothiesController : Controller
    {
        List<Smoothie> smoothies;
        public SmoothiesController()
        {
            smoothies = new List<Smoothie>();
            smoothies.Add(new Smoothie("The Plain Jane", "Burger on a Bun", 7.99m));
            smoothies.Add(new Smoothie("The Monster", "Everything", 17.99m));
            smoothies.Add(new Smoothie("The Nothing", "Lettuce", 1.99m));
            
        }
        [HttpGet]
        public IEnumerable<Smoothie> Get()
        {
            return smoothies;
        }
        [HttpPost]
        public Smoothie Post([FromBody] Smoothie smoothie)
        {
            smoothies.Add(smoothie);
            return smoothie;
        }
    }
}