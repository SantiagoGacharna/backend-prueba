using Microsoft.AspNetCore.Mvc;
using Modelos.Models;
using PruebaDigitalWare.Data;
using System.Linq;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : Controller
    {
        private readonly PruebaDbContext _db;

        public InvoiceController(PruebaDbContext pruebaDbContext)
        {
            _db = pruebaDbContext;
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _db.Invoice.ToList();

            return Ok(invoices);
        }

        [HttpPost]
        public IActionResult AddInvoice([FromBody] Invoice invoice)
        {
            var product = _db.Product.Find(invoice.product_id);
            if (product.inventory - invoice.amount <= 5)
            {
                return BadRequest("No hay inventario suficiente");
            }
            product.inventory -= invoice.amount;
            invoice.invoice_price = invoice.amount * product.price;

            _db.Invoice.Add(invoice);
            _db.SaveChanges();

            return Ok(invoice);
        }

        [HttpPut]
        public IActionResult EditInvoice([FromBody] Invoice updateInvoice)
        {
            var invoice = _db.Invoice.Find(updateInvoice.id_invoice);
            var product = _db.Product.Find(invoice.product_id);
            product.inventory += invoice.amount;

            if (invoice == null)
            {
                return NotFound();
            }
            var productNew = _db.Product.Find(updateInvoice.product_id);
            productNew.inventory -= updateInvoice.amount;

            if (product.inventory - updateInvoice.amount <= 5)
            {
                return BadRequest("No hay inventario suficiente");
            }

            invoice.client_id = updateInvoice.client_id;
            invoice.product_id = updateInvoice.product_id;
            invoice.amount = updateInvoice.amount;
            invoice.invoice_price = updateInvoice.amount * productNew.price;
            invoice.invoice_date = updateInvoice.invoice_date;

            

            _db.SaveChanges();

            return Ok(invoice);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteInvoice([FromRoute] int id)
        {
            var invoice = _db.Invoice.Find(id);

            if (invoice == null)
            {
                return NotFound();
            }

            _db.Invoice.Remove(invoice);
            _db.SaveChanges();

            return Ok(invoice);
        }
    }
}
