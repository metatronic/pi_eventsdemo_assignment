using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Greetings greetings = new Greetings();
            greetings.MyEvent += new Greetings.MyDelegate(OnEvent);
            Console.WriteLine("Enter Your Name:");
            string name = Console.ReadLine();

            greetings.RaiseEvent(name);
            Console.ReadLine();
        }

        static void OnEvent(object sender, Greetings.MyEventArgs e)
        {
            if(sender is Greetings)
            {
                Greetings greetings = (Greetings)sender;
                Console.WriteLine($"Hello and welcome : {e.message}");
            }
        }
    }

    class Greetings
    {
        public class MyEventArgs : EventArgs
        {
            public readonly string message;
            public MyEventArgs(string message)
            {
                this.message = message;
            }
        }
        public delegate void MyDelegate(object sender, MyEventArgs e);
        public event MyDelegate MyEvent;

        public void RaiseEvent(string message)
        {
            if (MyEvent != null) MyEvent(this, new Greetings.MyEventArgs(message));
        }

    }
}
