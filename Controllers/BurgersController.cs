using System.Collections.Generic;
using System;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;
using burgershack.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace burgershack.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BurgersController : Controller
    {
    BurgersRepository _repo;
        // List<Burger> burgers;
        // public BurgersController()
        // {
        //     burgers = new List<Burger>();
        //     burgers.Add(new Burger("The Plain Jane", "Burger on a Bun", 7.99m));
        //     burgers.Add(new Burger("The Monster", "Everything", 17.99m));
        //     burgers.Add(new Burger("The Nothing", "Lettuce", 1.99m));
            
        // }
        public BurgersController(BurgersRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<Burger> Get()
        {
            return _repo.GetAll();
        }
        // [HttpGet("id")]
        // public IEnumerable<Burger> Get(string id)
        // {
        //     return _repo.GetAll();
        // }
        [Authorize]
        [HttpPost]
        public Burger Post([FromBody] Burger burger)
        {
            if(ModelState.IsValid)
            {
            burger = new Burger(burger.Name, burger.Description, burger.Price);
            return _repo.Create(burger);
            
            }
        throw new Exception ("INVALID BURGER");
        }

        [HttpDelete]
        public string Delete([FromBody] Burger burger)
        {
            Burger deletedBurger = _repo.Delete(burger);
            //_backupRepo.Add(deletedBurger);
            return "deleted";
        }
    }
}