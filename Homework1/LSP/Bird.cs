using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.LSP
{
    // Bad Example of LSP
    /*
    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("This bird can fly.");
        }
    }

    public class Eagle : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("The eagle soars high in the sky.");
        }
    }

    public class Penguin : Bird
    {
        public override void Fly()
        {
            throw new InvalidOperationException("Penguins cannot fly.");
        }
    }*/

    // Good Example of LSP
    public abstract class Bird
    {
        public abstract void MakeSound();
    }

    public interface IFlyingBird
    {
        void Fly();
    }

    public class Eagle : Bird, IFlyingBird
    {
        public override void MakeSound()
        {
            Console.WriteLine("The eagle screeches.");
        }

        public void Fly()
        {
            Console.WriteLine("The eagle soars high in the sky.");
        }
    }
    
    public class Penguin : Bird
    {
        public override void MakeSound()
        {
            Console.WriteLine("The penguin squawks.");
        }
    }
}