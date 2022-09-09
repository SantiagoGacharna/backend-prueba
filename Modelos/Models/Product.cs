using Modelos.Models;
using System.ComponentModel.DataAnnotations;

namespace PruebaDigitalWare.Models
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }
        public int category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int inventory { get; set; }
    }
}
