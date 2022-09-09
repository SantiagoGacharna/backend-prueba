using Microsoft.AspNetCore.Mvc;
using Modelos.Models;
using PruebaDigitalWare.Data;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : Controller
    {
        private readonly PruebaDbContext _db;

        public ClientController(PruebaDbContext pruebaDbContext)
        {
            _db = pruebaDbContext;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _db.Client.ToList();

            return Ok(clients);
        }

        [HttpPost]
        public IActionResult AddClient([FromBody] Client client)
        {
            client.birthdate = client.birthdate.Date;
            _db.Client.Add(client);
            _db.SaveChanges();

            return Ok(client);
        }

        [HttpPut]
        public IActionResult EditClient([FromBody] Client updateClient)
        {
            var client = _db.Client.Find(updateClient.id_client);

            if (client == null)
            {
                return NotFound();
            }

            client.full_name = updateClient.full_name;
            client.cellphone = updateClient.cellphone;
            client.birthdate = updateClient.birthdate;

            _db.SaveChanges();

            return Ok(client);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteClient([FromRoute] int id)
        {
            var client = _db.Client.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            _db.Client.Remove(client);
            _db.SaveChanges();

            return Ok(client);
        }
    }
}
