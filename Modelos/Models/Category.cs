using System.ComponentModel.DataAnnotations;

namespace Modelos.Models
{
    public class Category
    {
        [Key]
        public int id_category { get; set; }
        public string name { get; set; }
    }
}
