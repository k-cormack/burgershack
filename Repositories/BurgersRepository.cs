using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{

    //Responsible for talking to Burgers database
    public class BurgersRepository
    {
        private IDbConnection _db;
        public BurgersRepository(IDbConnection db)
        {
            _db = db;
        }


        //CRUD via SQL

        //GET ALL BURGERS
        public IEnumerable<Burger> GetAll()
        {
            return _db.Query<Burger>("SELECT * FROM burgers");
        }
        //GET BURGER BY ID

        public Burger GetById(int id)
        {
            return _db.Query<Burger>("SELECT * FROM burgers WHERE id = @id", new { id }).FirstOrDefault();
        }
        //CREATE BURGER
        public Burger Create(Burger burger)
        {
            // Dapper used below in VALUES line (The '@' symbol)
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO burgers (name, description, price)
            VALUES (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();", burger
            );
            //Or instead of burger, use instead: new {
            // Name = burger.Name,
            // Description = burger.Description,
            // Price = burger.Price
            //  }

            burger.Id = id;
            return burger;
        }
        //UPDATE BURGER
        public Burger Update(Burger burger)
        {
            _db.Execute("UPDATE burgers SET (name, description, price) VALUES(@Name, @Description, @Price) WHERE id = @Id", burger);
            return burger;
        }
        //DELETE BURGER
         public Burger Delete(Burger burger)
         {
             _db.Execute("DELETE FROM burgers WHERE id = @Id", burger);
             return burger;
         }

        public IEnumerable<Burger> GetBurgersByUserId(string id)
        {
            return _db.Query<Burger>(@"
            SELECT * FROM userburgers
            JOIN burgers ON burgers.id = userburgers.burgerId
            WHERE userId = @id
            ", new {id});
        }

         public int Delete(int id)
         {
             return _db.Execute("DELETE FROM burgers WHERE id = @id", new { id });
         }
    }
}