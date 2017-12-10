using Gos.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace Gos.Services
{
    [ServiceContract]
    public interface IGosService
    {
        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        List<Customer> GetCustomer();

        [OperationContract]
        void SubmitOrder(Order order);
    }
}
