using System.Runtime.Serialization;

namespace Gos.Entities
{    
    //note we do not have annotations here, and it is called implicit data contract in WCF
    // the difference we have less control at wire level, for example exposing name
    // differs from its type name etc
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
