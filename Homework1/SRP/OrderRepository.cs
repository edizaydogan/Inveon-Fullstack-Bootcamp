using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.SingleResponsibilityPrinciple
{
    internal class OrderRepository
    {
        // SaveToFile function moved here in order to comply with SRP
        public void SaveToFile(Order order, string filePath)
        {
            // save data to a file
        }
    }
}