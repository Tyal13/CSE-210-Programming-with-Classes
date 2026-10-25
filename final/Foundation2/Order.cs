using System;
using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;
    private int _usaShippingCost;
    private int _internationalShippingCost;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _usaShippingCost = 5;
        _internationalShippingCost = 35;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += _usaShippingCost;
        }
        else
        {
            total += _internationalShippingCost;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:";

        foreach (Product product in _products)
        {
            label += $"\n{product.GetName()} (ID: {product.GetProductId()})";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
