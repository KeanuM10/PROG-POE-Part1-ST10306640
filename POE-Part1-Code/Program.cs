using System;
using Microsoft.VisualBasic;

namespace IngProgram
{
    //Variable Decleration
    public class Ingredients
    {
        public string IngName;
        public int IngQuantity;
        public string UoM;

        //Variables now initialzed
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
            int ingCounter = Int32.Parse(Console.ReadLine());

            //Decleration of ingredients array
            Ingredients[] IngArray = new Ingredients[ingCounter];

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

        //FactorIngredients() allows user to scale the factor of IngQuantity or follows necessary actions (exit or proceed to steps)
        public static void FactorIngredients(Ingredients[] IngArray)
        {
            double factorScale;
            bool factorScaleCheck = false;

            Console.WriteLine("Would you like to scale the factor of your ingredients? Type Yes or No");
            var factorCheck = Console.ReadLine();
            factorCheck.ToLower();

            //while statment ensuring user loops if incorrect values are used
            while (factorScaleCheck == false)
            {
                //if statment checking for valid input and then applying needed factor
                if (factorCheck == "yes" || factorCheck == "y")
                {
                    Console.WriteLine("Please select your factor scale (Enter the corresponding letter): A: x0.5, B: x2, or C: x3");
                    var factorValue = Console.ReadLine();
                    factorValue.ToUpper();

                    if (factorValue == "A")
                    {
                        factorScale = 0.5;
                        Console.WriteLine("Here is the updated recipe: ");
                        //foreach statement looping through IngArray to apply factors and display updated recipe
                        foreach (var ingredient in IngArray)
                        {
                            double updatedQuantity = ingredient.IngQuantity * factorScale;
                            Console.WriteLine($"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                        }
                        factorScaleCheck = true;
                    }
                    else if (factorValue == "B")
                    {
                        factorScale = 2;
                        Console.WriteLine("Here is the updated recipe: ");
                        //foreach statement looping through IngArray to apply factors and display updated recipe
                        foreach (var ingredient in IngArray)
                        {
                            double updatedQuantity = ingredient.IngQuantity * factorScale;
                            Console.WriteLine("Here is the updated recipe: " + $"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                        }
                        factorScaleCheck = true;
                    }
                    else if (factorValue == "C")
                    {
                        factorScale = 3;
                        Console.WriteLine("Here is the updated recipe: ");
                        //foreach statement looping through IngArray to apply factors and display updated recipe
                        foreach (var ingredient in IngArray)
                        {
                            double updatedQuantity = ingredient.IngQuantity * factorScale;
                            Console.WriteLine("Here is the updated recipe: " + $"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                        }

                        factorScaleCheck = true;
                    }
                    //else if allowing user to retry, or exit program if an invalid letter is being selected
                    else if (factorValue != "A" || factorValue != "B" || factorValue != "C")
                    {
                        Console.WriteLine("Please enter a valid letter or 0 to exit the program");
                        var exitIng = Int32.Parse(Console.ReadLine());
                        factorScaleCheck = false;

                        if(exitIng == 0) {
                            Environment.Exit(0);
                        }
                    }
                    //Main if statment else block
                    else
                    {
                        Console.WriteLine("Proceeding to steps...");
                    }
                }
            }
        }
    }
}

