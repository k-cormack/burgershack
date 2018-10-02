using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{

    public class Side
    {
        public int Id { get; set; }


        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public Side() {
            
        }

        public Side(string name, string description, decimal price = 5.00m)
        {
            
            Name = name;
            Description = description;
            if(price > 5){
            Price = price;
            }
            else{
                Price = 5;
            }
        }


    }
}