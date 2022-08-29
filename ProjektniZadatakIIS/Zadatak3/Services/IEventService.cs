using System.ServiceModel;
using System.Xml.Linq;
using Zadatak3.Models;

namespace Zadatak3.Services
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        List<Event> GetEvents();
        [OperationContract]
        string SearchXml(string query);
    }
}
