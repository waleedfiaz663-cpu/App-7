using System;

namespace Assignment2_Q3
{
    public delegate void NotifyDelegate(int value);

    public class NumberProcessor
    {
        public event NotifyDelegate ThresholdExceeded;

        public void CheckNumber(int number)
        {
            Console.WriteLine($"Processing number: {number}");

            if (number > 100)
            {
                OnThresholdExceeded(number);
            }
        }

        protected virtual void OnThresholdExceeded(int number)
        {
            ThresholdExceeded?.Invoke(number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NumberProcessor processor = new NumberProcessor();

            processor.ThresholdExceeded += ShowAlertMessage;

            processor.CheckNumber(45);
            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("");
            processor.CheckNumber(150);
           
        }

        static void ShowAlertMessage(int value)
        {
            Console.WriteLine("");
            Console.WriteLine($"[EVENT ALERT]: The number {value} has exceeded the limit of 100!");
        }
    }
}
