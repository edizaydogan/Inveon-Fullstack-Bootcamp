using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.SingleResponsibilityPrinciple
{

    internal class Order
    {

        public int Id { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal CalculateTotalPrice()
        {
            return Quantity * Price;
        }

        // Bad example of Single Responsibility Principle
        /*
        public void SaveToFile(string filePath)
        {
            // save data to a file
        }
        */
    }
}