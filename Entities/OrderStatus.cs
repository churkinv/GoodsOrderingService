using System.Runtime.Serialization;

namespace Gos.Entities
{
    [DataContract]
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
