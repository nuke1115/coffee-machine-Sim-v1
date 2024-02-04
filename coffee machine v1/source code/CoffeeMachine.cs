using System;


namespace Code
{
    public class CoffeeMachine
    {
        private static bool Running = true;
        private UserInput _userInput;

        public static void Main()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            coffeeMachine.Run();
        }
        private UserInput userInput = new UserInput();
        private void Run()
        {
            while (Running)
            {
                userInput.GetUserInput();
                
            }
        } 
    }

    public class UserInput
    {
        private ManageInput manageInput = new ManageInput();
        private string Order;
        public void GetUserInput()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("|| MilkCoffee \n|| SugarCoffee \n|| BlackCoffee \n|| YulmuCha");
            Console.WriteLine("|| 입력을 이상하게 하면 기본적으로 BlackCoffee가 나온다 ");
            Console.WriteLine("==========================================================");

            Console.Write("주문을 입력하세요:");

            Order = Console.ReadLine();
            dispenseUserOrder();

            Console.WriteLine("==========================================================");
        }

        private void dispenseUserOrder()
        {
            manageInput.startDispense(Order);
        }
    }

    //=================================================================================
    public abstract class Drink
    {
        
        public abstract void DispenseDrink();
    }

    public class MilkCoffee : Drink
    {
        public override void DispenseDrink()
        {
            Console.WriteLine("MilkCoffee 가 나왔습니다");
        }
    }

    public class SugarCoffee : Drink
    {
        public override void DispenseDrink()
        {
            Console.WriteLine("SuagarCoffee 가 나왔습니다");
        }
    }

    public class BlackCoffee : Drink
    {
        public override void DispenseDrink()
        {
            Console.WriteLine("BlackCoffee 가 나왔습니다");
        }
    }

    public class YulmuCha : Drink
    {
        public override void DispenseDrink()
        {
            Console.WriteLine("YulmuCha 가 나왔습니다");
        }
    }

    //=================================================================================

    
    
    public class DrinkInstanceFactory
    {

        public Drink getDrink(string Input)
        {
            if(Input == "MilkCoffee")
            {
                return new MilkCoffee();
            }
            else if( Input == "SugarCoffee")
            {
                return new SugarCoffee();
            }
            else if(Input == "BlackCoffee")
            {
                return new BlackCoffee();
            }
            else if(Input == "YulmuCha"){
                return new YulmuCha();
            }
            return new BlackCoffee();
        }
    }

    public class ManageInput
    {
        private DrinkInstanceFactory drinkInstanceFactory = new DrinkInstanceFactory();

        private Dispense dispense;

        public void startDispense(string order)
        {
            dispense = new Dispense(drinkInstanceFactory.getDrink(order));
        }

    }


    public class Dispense
    {
        Drink _drink;
        public Dispense(Drink drink)
        {
            _drink = drink;
            DispenseDrink();
        }

        public void DispenseDrink()
        {
            _drink.DispenseDrink();
        }

    }
}
