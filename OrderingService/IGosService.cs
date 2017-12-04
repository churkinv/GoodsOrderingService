using Gos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GOS.Services
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
