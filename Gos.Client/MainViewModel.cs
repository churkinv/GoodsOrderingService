using Gos.Entities;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Windows;
using Gos.Client.GosServices;
using System.Linq;

namespace Gos.Client
{
    public class MainViewModel : MainViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Product> _products;
        private ObservableCollection<OrderItemModel> _items = new ObservableCollection<OrderItemModel>();
        private Order _currentOrder = new Order();

        //public OrderCommand SubmitOrderCommand { get; private set; }
        public OrderCommand<object> AddOrderItemCommand  { get; private set; }

        public MainViewModel()
        {
            _currentOrder.OrderDate = DateTime.Now;
            _currentOrder.OrderStatusId = 1;
            //SubmitOrderCommand = new OrderCommand(OnSubmitOrder);
            AddOrderItemCommand = new OrderCommand<object>(OnAddItem); // we use generic to pass method with parametr also adjusted in OrderCommand

            // TODO: find out more
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                LoadProductsAndCustomers();
            }
        }

        public Order CurrentOrder
        {
            get { return _currentOrder = new Order(); }
            set
            {
                _currentOrder = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<OrderItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private async void LoadProductsAndCustomers()
        {
            // We use "automatic" implementation of service here (right click of project add service ref...) 
            // Actualy we didn`t created Asyncs methods but they where genereted autonatically
            // we can find GosServiceClient and async methods by the following: Sol.Expl. Show All Files
            // Open connected services -> under Reference.svcmap-> Reference.cs
            GosServiceClient proxy = new GosServiceClient("NetTcpBinding_IGosService"); // we are passing name of endpoint from App.config to the constructor
            try
            {
                Products = await proxy.GetProductsAsync();
                Customers = await proxy.GetCustomerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load server data. " + ex.Message);
            }
            finally
            {
                proxy.Close();
            }
        }

        private void OnSubmitOrder()
        {
            if (_currentOrder.CustomerId != Guid.Empty && _currentOrder.OrderItems.Count > 0)
            {
                GosServiceClient proxy = new GosServiceClient("NetTcpBinding_IGosService");
                try
                {
                    proxy.SubmitOrder(_currentOrder);
                    CurrentOrder = new Order();
                    CurrentOrder.OrderDate = DateTime.Now;
                    CurrentOrder.OrderStatusId = 1;
                    Items = new ObservableCollection<OrderItemModel>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving order, please try again later. " + ex.Message);
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        //
        private void OnAddItem (object productO)
        {
            Product product = (Product)productO;
            var existingOrderItem = _currentOrder.OrderItems.Where(oi => oi.ProductId == product.Id).FirstOrDefault();
            var existingOrderItemModel = _items.Where(i => i.ProductId == product.Id).FirstOrDefault();
            if (existingOrderItem != null && existingOrderItemModel != null)
            {
                existingOrderItem.Quantity++;
                existingOrderItemModel.Quantity++;
                existingOrderItem.TotalPrice = existingOrderItem.UnitPrice * existingOrderItem.Quantity;
                existingOrderItemModel.TotalPrice = existingOrderItem.TotalPrice;
            }
            else
            {
                var orderItem = new OrderItem { ProductId = product.Id, Quantity = 1,
                    UnitPrice = 9.99m, TotalPrice = 9.99m };
                _currentOrder.OrderItems.Add(orderItem);
                Items.Add(new OrderItemModel { ProductId = product.Id, ProductName = product.Name,
                    Quantity = orderItem.Quantity, TotalPrice = orderItem.TotalPrice });
            }
        }
    }
}
