using GOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gos.Entities;
using Gos.Data;
using System.ServiceModel;

namespace GOS.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] // InstanceContextMode determines the lifetime of service instance,                                                                             
    public class GosService : IGosService, IDisposable                   // Suggestion to use PerCall instead of default PerSession
    {
        readonly GosDbContex _ctx = new GosDbContex();

        public List<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public List<Customer> GetCustomer()
        {
            return _ctx.Customers.ToList();
        }       

        [OperationBehavior(TransactionScopeRequired=true)] // we use it to handle with multiple calls to DB
        public void SubmitOrder(Order order)               // so as you enter this method a transaction will be started
        {                                                  // if you leave transaction will be comitted, if method cause exception it will roll back the transaction
            _ctx.Orders.Add(order);
            order.OrderItems.ForEach(oi => _ctx.OrderItems.Add(oi));
            _ctx.SaveChanges();
        }

        // We should use IDisposable as default behaviour is that service will be kept alive 
        // as long as proxy communicating with the server side     
        // WCF will call it for us. 
        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
