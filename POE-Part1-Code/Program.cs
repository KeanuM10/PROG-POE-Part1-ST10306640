using System;
using Microsoft.VisualBasic;

namespace IngProgram
{
    public class Ingredients
    {
        public string IngName;
        public int IngQuantity;
        public string UoM;

        public Ingredients(string IngName, int IngQuantity, string UoM)
        {
            this.IngName = IngName;
            this.IngQuantity = IngQuantity;
            this.UoM = UoM;
        }
    }

    class IngredientProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter number of ingredients");
            int steps = Int32.Parse(Console.ReadLine());

            Ingredients[] IngArray = new Ingredients[steps];

            SaveIngredients(IngArray);
            FactorIngredients(IngArray);

            /*foreach( var ingredient in IngArray) {
             //"$" indicates string interpolation - replaces words within {} with actual values given
             Console.WriteLine($"{ingredient.IngName}");
            }*/
        }

        //SaveIngredients() allows for user input and saves the Ingredients info to the array
        public static void SaveIngredients(Ingredients[] IngArray)
        {
            int x = 1;
            for (int i = 0; i < IngArray.Length; i++)
            {    
                Console.WriteLine("Please enter name of ingredient: " + x++);
                string IngName = Console.ReadLine();

                //Turned to a var as input will be mixed between string and int
                Console.WriteLine("Please enter quantity of: " + IngName);
                int IngQuantity = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Please enter Unit of Measurment for: " + IngName);
                string UoM = Console.ReadLine();

                //stores user input into the array
                IngArray[i] = new Ingredients(IngName, IngQuantity, UoM);
            }
        }

        public static void FactorIngredients(Ingredients[] IngArray) {
            Console.WriteLine("Would you like to scale the factor of your ingredients? Type Yes or No");
            var factorCheck = Console.ReadLine();
            factorCheck.ToLower();

            if(factorCheck == "yes" || factorCheck == "y") {
                Console.WriteLine("Please enter your factor scale:");
                int factorScale = Int32.Parse(Console.ReadLine());
                
                foreach(var ingredient in IngArray){
                double updatedQuantity =  ingredient.IngQuantity * factorScale;
                Console.WriteLine("Here is the updated recipe: " + $"{updatedQuantity} {ingredient.UoM} of {ingredient.IngName}");
                }
            }
            else {
                Console.WriteLine("Proceeding to steps...");
            }
        }
    }
}

