//Can you think of any new requirements that can impact your design?
//These are obvious new requirements
//Add loyalty points (customer object etc.)
//Order multiple drinks
//Take away or having in (container)

//Where I looked in to find solutions:
//https://msdn.microsoft.com/en-GB/library/yd3z1377.aspx
//https://msdn.microsoft.com/en-us/library/hh694602.aspx
//http://code.tutsplus.com/tutorials/solid-part-1-the-single-responsibility-principle--net-36074
using System;

namespace AcuCafe
{
    public class AcuCafe
    {
        //changed base class to be abstract
        public static Drink OrderDrink(string type, bool hasMilk, bool hasSugar)
        {
            Drink drink=null;
            if (type == "Expresso")
                drink = new Expresso();
            else if (type == "HotTea")
                drink = new Tea();
            else if (type == "IceTea")
                drink = new IceTea();

            try
            {
                drink.HasMilk = hasMilk;
                drink.HasSugar = hasSugar;
                drink.Prepare(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine("We are unable to prepare your drink.");
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }

            return drink;
        }
    }

    public abstract class Drink
    {
        public const double MilkCost = 0.5;
        public const double SugarCost = 0.5;
        //A new property to indicate all ingredients are set properly
        public  string HasError { get; set; }
        //changed to abstract, HasMilk is not really common for all drinks, this way I can set HasError on IceTea if HasMik==true
        public abstract  bool HasMilk { get; set; }

        public  bool HasSugar { get; set; }
        public abstract string Description { get; }

        public double Cost()
        {
            return 0;
        }

        public void Prepare(string drink)
        {
            //do a check if drink arguments are correctly in place
            if (HasError != string.Empty && HasError!=null)
            {
                Console.WriteLine(HasError);
            }
            else
            {
                //added some spaces so I get readable output
                string message = "We are preparing the following drink for you: " + Description;
                if (HasMilk)
                    message += " with milk";
                else
                    message += " without milk";

                if (HasSugar)
                    message += " with sugar";
                else
                    message += " without sugar";

                Console.WriteLine(message);
            }
        }
    }

    public class Expresso : Drink
    {
        public override  string Description
        {
            get { return "Expresso"; }
        }

        public override bool HasMilk
        {
            get
            {
                return HasMilk;
            }
            set
            {
            }
        }
        //for now added chocolate topping here. I would recommend to add a Topping property to Drink and then set the type in each subclass
        public new bool ChocolateTopping { get; set; }

        public  double Cost()
        {
            double cost = 1.8;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }

    public class Tea : Drink
    {
        public override string Description
        {
            get { return "Hot tea"; }
        }

        public override bool HasMilk
        {
            get
            {
                return HasMilk;
            }
            set
            {
            }
        }

        public  double Cost()
        {
            double cost = 1;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }

    public class IceTea : Drink
    {
        public override string Description
        {
            get { return "Ice tea"; }
        }

        public override bool HasMilk
        {
            get{return HasMilk;}
            set
            {
                //validate if HasMilk is set
                if (value)
                    HasError = "IceTea can not be made with Milk, no drink made.";
            }
        }
        public  double Cost()
        {
            double cost = 1.5;

            if (HasMilk)
                cost += MilkCost;

            if (HasSugar)
                cost += SugarCost;

            return cost;
        }
    }
}