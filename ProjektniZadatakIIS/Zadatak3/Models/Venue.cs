using System.Runtime.Serialization;

namespace Zadatak3.Models
{
    [DataContract]
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
    }
}
