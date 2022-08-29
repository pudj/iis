using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Zadatak1.Models;

namespace Zadatak1.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/events/create")]
        public ActionResult Create([FromBody]XElement request) {       
            if (!IsValidXml(new XDocument(request))) {
                return BadRequest("Sent XML is not valid!");
            }

            return Ok();
        }

        private bool IsValidXml(XDocument doc) {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", @"C:\Users\nadan.marenkovic\Desktop\tuts\ProjektniZadatakIIS\Zadatak1\Models\Event.xsd");
            doc.Validate(schema, ValidationEventHandler);
            return true;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e) {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            }
        }
    }
}
