using System.Runtime.Serialization;

namespace Zadatak3.Models
{
    [DataContract]
    public class Event
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; } = string.Empty;
        [DataMember]
        public string Type { get; set; } = string.Empty;
        [DataMember]
        public string Url { get; set; } = string.Empty;
        [DataMember]
        public string Promoter { get; set; } = string.Empty;
        [DataMember]
        public string Info { get; set; } = string.Empty;
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Venue Venue { get; set; }
    }
}
