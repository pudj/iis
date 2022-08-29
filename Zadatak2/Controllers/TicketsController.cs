using Commons.Xml.Relaxng;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Zadatak2.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/tickets/create")]
        public ActionResult Create([FromBody] XElement request)
        {
            if (!IsValidXml(new XDocument(request)))
            {
                return BadRequest("Sent XML is not valid!");
            }
            return Ok();
        }

        private bool IsValidXml(XDocument doc) {
            XmlReader xml = doc.CreateReader();
            XmlReader rng = XmlReader.Create(@"C:\Users\nadan.marenkovic\Desktop\tuts\ProjektniZadatakIIS\Zadatak2\Model\Ticket.rng");

            using (RelaxngValidatingReader reader = new RelaxngValidatingReader(xml, rng))
            {
                try
                {
                    while (!reader.EOF)
                    {
                        reader.Read();
                    }
                    Console.WriteLine("validation succeeded");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("validation failed with message:");
                    Console.WriteLine(ex.Message);
                }
            }

            return true;
        }
    }
}
