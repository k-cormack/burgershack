using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{

    //Responsible for talking to Sides database
    public class SidesRepository
    {
        private IDbConnection _db;
        public SidesRepository(IDbConnection db)
        {
            _db = db;
        }


        //CRUD via SQL

        //GET ALL SIDES
        public IEnumerable<Side> GetAll()
        {
            return _db.Query<Side>("SELECT * FROM sides");
        }
        //GET SIDES BY ID

        public Side GetById(int id)
        {
            return _db.Query<Side>("SELECT * FROM sides WHERE id = @id", new { id }).FirstOrDefault();
        }
        //CREATE SIDES
        public Side Create(Side side)
        {
            // Dapper used below in VALUES line (The '@' symbol)
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO sides (name, description, price)
            VALUES (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();", side
            );
            //Or instead of side, use instead: new {
            // Name = side.Name,
            // Description = side.Description,
            // Price = side.Price
            //  }

            side.Id = id;
            return side;
        }
        //UPDATE SIDE
        public Side Update(Side side)
        {
            _db.Execute("UPDATE sides SET (name, description, price) VALUES(@Name, @Description, @Price) WHERE id = @Id", side);
            return side;
        }
        //DELETE SIDE
         public Side Delete(Side side)
         {
             _db.Execute("DELETE FROM sides WHERE id = @Id", side);
             return side;
         }
         public int Delete(int id)
         {
             return _db.Execute("DELETE FROM sides WHERE id = @id", new { id });
         }
    }
} 