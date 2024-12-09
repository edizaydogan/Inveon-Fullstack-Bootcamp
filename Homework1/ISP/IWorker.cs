using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.ISP
{
    // Bad Example of ISP
    /*
    public interface IWorker
    {
        void Work();
        void TakeBreak();
    }

    public class OfficeWorker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Office worker is working.");
        }

        public void TakeBreak()
        {
            Console.WriteLine("Office worker is taking a break.");
        }
    }

    public class Robot : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Robot is working.");
        }

        public void TakeBreak()
        {
            throw new NotImplementedException("Robots do not take breaks.");
        }
    }
    */

    // Good Example of ISP
    public interface IWorkable
    {
        void Work();
    }

    public interface IRestable
    {
        void TakeBreak();
    }

    public class OfficeWorker : IWorkable, IRestable
    {
        public void Work()
        {
            Console.WriteLine("Office worker is working.");
        }

        public void TakeBreak()
        {
            Console.WriteLine("Office worker is taking a break.");
        }
    }

    public class Robot : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot is working.");
        }
    }

}