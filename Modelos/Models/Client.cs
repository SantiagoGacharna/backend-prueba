using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Modelos.Models
{
    public class Client
    {
        [Key]
        public int id_client { get; set; }
        public string full_name { get; set; }
        public string cellphone { get; set; }
        public DateTime birthdate { get; set; }
    }
}
