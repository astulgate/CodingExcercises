using System;
/*
    Demonstrating Events and Delegates using a savings application example
    Event listeners fire when balance changes and when savings goal is met

*/
namespace EventsSolution
{
    //define the delegate for the event handler
    public delegate void myEventHandler(int value);

    class SaveUp
    {
        private int _theBal = 0;
        //declare event Handler
        public event myEventHandler valueChanged;

        public int balance{
            set{
                _theBal = value;
                //fire event when balance value changes
                valueChanged(value);
            }
            get{
                return _theBal;
            }
        }

    }

    class GoalLog
    {
        //Listener that prints message if savings goal is met
        public void goalMetListener(int value)
        {
            if(value >= 500){
                Console.WriteLine($"You met your goal, yout balance is {value}");
            }
            
        }
    }

    class BalanceLog
    {
        //Listener that logs each balance change
        public void balanceChangeListener(int value)
        {
            Console.WriteLine($"The balance is now {value}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //initialize classes
            SaveUp obj = new SaveUp();
            BalanceLog bl = new BalanceLog();
            GoalLog gl = new GoalLog();

            //Connect multiple event handlers
            obj.valueChanged += bl.balanceChangeListener;
            obj.valueChanged += gl.goalMetListener;

            string deposit;

            do {
                Console.WriteLine("How much will you deposit?");
                deposit = Console.ReadLine();
                if(!deposit.Equals("exit")){
                    obj.balance += int.Parse(deposit);
                }
            }while (!deposit.Equals("exit"));
            Console.WriteLine("Peace!");

        }

        
        
    }
}
