using Gos.Entities;
using System.Collections.ObjectModel;
using System;

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
            SubmitOrderCommand = new OrderCommand(OnSubmitOrder);
            AddOrderItemCommand = new OrderCommand(OnAddItem);    
        }

        private void OnAddItem()
        {
            throw new NotImplementedException();
        }

        private void OnSubmitOrder()
        {
            throw new NotImplementedException();
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

    }
}
