using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Zadatak3.Models;

namespace Zadatak3.Services
{
    public class EventService : IEventService
    {
        public string SearchXml(string query)
        {
            //http://localhost:5068/EventService.asmx/

            //<?xml version="1.0" encoding="utf-8"?>
            //<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
            //<soap:Body>
            //<SearchXml xmlns="http://www.w3.org/2001/XMLSchema">
            //<query>/tempuri:GetEventsResponse/tempuri:GetEventsResult/d2p1:Event/d2p1:Name</query>
            //</SearchXml>
            //</soap:Body>
            //</soap:Envelope>

            const string serviceUrl = "http://localhost:5068/EventService.asmx/GetEvents";
            XmlDocument document = new XmlDocument();
            document.Load(serviceUrl);

            var nsmgr = new XmlNamespaceManager(document.NameTable);

            nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Zadatak3.Models");
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
            nsmgr.AddNamespace("i", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("tempuri", "http://tempuri.org/");

            try
            {
                XmlNode? node = document.SelectSingleNode(query, nsmgr);
                if (node != null)
                {
                    return node.InnerText;
                }
                else
                {
                    return $"Data does not exist! Search term: {query}";
                }
            }
            catch (Exception e)
            {
                return $"{e.Message}";
                throw;
            }
        }

        public List<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event{
                    Id = 1,
                    Name = "Party u Močvari",
                    Type = "Party",
                    Url = "http://mocvara.com/event/1",
                    Promoter = "Močvara Promotions",
                    StartDate = new DateTime(2022, 8, 1),
                    EndDate = new DateTime(2022, 8, 2),
                    Price = 50,
                    Venue = new Venue { 
                        Id = 1,
                        Name = "Močvara",
                        Address = "Neka adresa",
                        City = "Zagreb",
                        Country = "Hrvatska",
                        PostalCode = "10000",
                        ContactName = "Pero"
                    }
                },
                new Event{
                    Id = 2,
                    Name = "Koncert u Skwhatu",
                    Type = "Koncert",
                    Url = "http://swkwhat.com/event/2",
                    Promoter = "Kištra",
                    StartDate = new DateTime(2022, 8, 10),
                    EndDate = new DateTime(2022, 8, 11),
                    Price = 80,
                    Venue = new Venue {
                        Id = 2,
                        Name = "Skwhat",
                        Address = "Viktorovac 1",
                        City = "Sisak",
                        Country = "Hrvatska",
                        PostalCode = "44000",
                        ContactName = "Ivica"
                    }
                },
                new Event{
                    Id = 3,
                    Name = "Festival u Močvari",
                    Type = "Festival",
                    Url = "http://mocvara.com/festival/1",
                    Promoter = "Čvarci",
                    StartDate = new DateTime(2022, 9, 1),
                    EndDate = new DateTime(2022, 9, 4),
                    Price = 220,
                    Venue = new Venue {
                        Id = 1,
                        Name = "Močvara",
                        Address = "Neka adresa",
                        City = "Zagreb",
                        Country = "Hrvatska",
                        PostalCode = "10000",
                        ContactName = "Pero"
                    }
                }
            };
        }
    }
}
