using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Models
{
    public class Invoice
    {
        [Key]
        public int id_invoice { get; set; }
        public int client_id { get; set; }
        public int product_id { get; set; }
        public int amount { get; set; }
        public int invoice_price { get; set; }
        public DateTime invoice_date { get; set; }
    }
}
