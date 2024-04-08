using System;

namespace IngProgram
{
    public class Ingredients
    {
        public string IngName;
        public int ingQuantity;
        public string UoM;

        public Ingredients(string IngName, int ingQuantity, string UoM)
        {
            this.IngName = IngName;
            this.ingQuantity = ingQuantity;
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

            /*foreach( var ingredient in IngArray) {
             //"$" indicates string interpolation - replaces words within {} with actual values given
             Console.WriteLine($"{ingredient.IngName}");
            }*/
        }

        //SaveIngredients() allows for user input and saves the Ingredients info to the array
        public static void SaveIngredients(Ingredients[] IngArray)
        {
            for (int i = 0; i < IngArray.Length; i++)
            {
                int x = 1;
                Console.WriteLine("Please enter name of ingredient: " + x++);
                string IngName = Console.ReadLine();

                Console.WriteLine("Please enter quantity of: " + IngName);
                int IngQuantity = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Please enter Unit of Measurment for: " + IngName);
                string UoM = Console.ReadLine();

                //stores user input into the array
                IngArray[i] = new Ingredients(IngName, IngQuantity, UoM);
            }
        }
    }
}

