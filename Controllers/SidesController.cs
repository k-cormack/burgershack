using System.Collections.Generic;
using System;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;
using burgershack.Repositories;

namespace burgershack.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SidesController : Controller
    {
    SidesRepository _repo;
        // List<Side> sides;
        // public SidesController()
        // {
        //     sides = new List<Side>();
        //     sides.Add(new Side("The Plain Jane", "Burger on a Bun", 7.99m));
        //     sides.Add(new Side("The Monster", "Everything", 17.99m));
        //     sides.Add(new Side("The Nothing", "Lettuce", 1.99m));
            
        // }
        public SidesController(SidesRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<Side> Get()
        {
            return _repo.GetAll();
        }
        [HttpPost]
        public Side Post([FromBody] Side side)
        {
            if(ModelState.IsValid)
            {
            side = new Side(side.Name, side.Description, side.Price);
            return _repo.Create(side);
            
            }
        throw new Exception ("INVALID SIDE");
        }
    }
}