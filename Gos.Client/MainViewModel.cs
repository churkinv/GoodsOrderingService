using Gos.Entities;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Windows;
using Gos.Client.GosServices;

namespace Gos.Client
{
    public class MainViewModel : MainViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Product> _products;
        private ObservableCollection<OrderItemModel> _items = new ObservableCollection<OrderItemModel>();
        private Order _currentOrder = new Order();

        public OrderCommand SubmitOrderCommand { get; private set; }
        public OrderCommand AddOrderItemCommand { get; private set; }

        public MainViewModel()
        {
            _currentOrder.OrderDate = DateTime.Now;
            _currentOrder.OrderStatusId = 1;           
            SubmitOrderCommand = new OrderCommand(OnSubmitOrder);
            AddOrderItemCommand = new OrderCommand(OnAddItem);

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

        private void OnAddItem()
        {
            throw new NotImplementedException();
        }

        private void OnSubmitOrder()
        {
            throw new NotImplementedException();
        }

        private async void LoadProductsAndCustomers()
        {
            // we use here "automatic" implementation of service here (right click of project add service ref...) 
            // Actualy we didn`t created Asyncs methods but they where genereted autonatically
            // we can find GosServiceClient and async methods by the following: Sol.Expl. Show All Files
            // Open connected services -> under Reference.svcmap-> Reference.cs
            GosServiceClient proxy = new GosServiceClient("NetTcpBinding_IGosService"); // we are passing name of endpoint to the constructor
            Products = await proxy.GetProductsAsync();
            Customers = await proxy.GetCustomerAsync();
            proxy.Close();
        }

    }
}
