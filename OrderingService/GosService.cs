using System;
using System.Collections.Generic;
using System.Linq;
using Gos.Entities;
using Gos.Data;
using System.ServiceModel;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Claims;
using System.Windows;

namespace Gos.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] // InstanceContextMode determines the lifetime of service instance,                                                                             
    public class GosService : IGosService, IDisposable                   // Suggestion to use PerCall instead of default PerSession
    {
        readonly GosDbContex _ctx = new GosDbContex();

        #region security option 2
        //[PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Administrators")]
        #endregion
        public List<Product> GetProducts()
        {
            #region security option 1
            //var principal = Thread.CurrentPrincipal; // to check security, two types of autontification NTLM (work group config), Kerberos (domain)
            //if (!principal.IsInRole("BUILTIN\\Administrators"))
            //    throw new SecurityException("Access denied");
            #endregion
            
            #region security option 3
            //ClaimsPrincipal.Current.HasClaim(...); // value can be determined dynamically. From .net 4.5 all principals are claim principals
            #endregion
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
