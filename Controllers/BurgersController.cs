using System.Collections.Generic;
using System;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurgersController : Controller
    {
        List<Burger> burgers;
        public BurgersController()
        {
            burgers = new List<Burger>();
            burgers.Add(new Burger("The Plain Jane", "Burger on a Bun", 7.99m));
            burgers.Add(new Burger("The Monster", "Everything", 17.99m));
            burgers.Add(new Burger("The Nothing", "Lettuce", 1.99m));
            
        }
        [HttpGet]
        public IEnumerable<Burger> Get()
        {
            return burgers;
        }
        [HttpPost]
        public Burger Post([FromBody] Burger burger)
        {
            if(ModelState.IsValid)
            {
            burger = new Burger(burger.Name, burger.Description, burger.Price);
            burgers.Add(burger);
            return burger;
            }
        throw new Exception ("INVALID DATA");
        }
    }
}