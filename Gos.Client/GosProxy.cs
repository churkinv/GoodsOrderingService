using Gos.Client.GosServices;
using Gos.Entities;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Gos.Client
{

    /// <summary>
    /// We used trick and referenced our automatically generated code.
    /// But when you are writing your own proxy on client:
    /// add service reference to you service contract - in this case you won`t have async methods...
    /// or handcode service contract for client side    
    /// </summary>
    class GosProxy : ClientBase<IGosService>, IGosService
    {
        public GosProxy() { }
        public GosProxy(string endpointName) : base(endpointName) { }
        public GosProxy(Binding binding, string address) : base(binding, new EndpointAddress(address)) { }

        public ObservableCollection<Customer> GetCustomer()
        {
            return Channel.GetCustomer();
        }

        public Task<ObservableCollection<Customer>> GetCustomerAsync()
        {
            return Channel.GetCustomerAsync();
        }

        public ObservableCollection<Product> GetProducts()
        {
            return Channel.GetProducts();
        }

        public Task<ObservableCollection<Product>> GetProductsAsync()
        {
            return Channel.GetProductsAsync();
        }

        public void SubmitOrder(Order order)
        {
            Channel.SubmitOrder(order);
        }

        public Task SubmitOrderAsync(Order order)
        {
            return Channel.SubmitOrderAsync(order);
        }
    }
}
