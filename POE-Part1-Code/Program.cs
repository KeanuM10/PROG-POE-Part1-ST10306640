using System;
using Microsoft.VisualBasic;

namespace IngProgram
{
    //Variable Decleration
    public class Ingredients
    {
        public string IngName;
        public double IngQuantity;
        public string UoM;

        //Variables now initialzed
        public Ingredients(string IngName, double IngQuantity, string UoM)
        {
            this.IngName = IngName;
            this.IngQuantity = IngQuantity;
            this.UoM = UoM;
        }
    }
    //Variable Decleration
    public class UserSteps
    {
        public string userStepCount;

        public UserSteps(string userStepCount)
        {
            this.userStepCount = userStepCount;
        }
    }
    class IngredientProgram
    {
        public static void Main(string[] args)
        {
            try
            {
                ProgramStart();
            }
            catch
            {

                ProgramStart();
            }
        }


        //MainRepeat() Method declares needed arrays and call necessary methods, surrounded in a try catch for error handling.
        public static void ProgramStart()
        {
            try
            {
                Console.WriteLine("Please enter number of ingredients in recipe:");
                int ingCounter = Int32.Parse(Console.ReadLine());

                //Decleration of ingredients array
                Ingredients[] IngArray = new Ingredients[ingCounter];
                SaveIngredients(IngArray);

                Console.WriteLine("Please enter the number of steps in recipe: ");
                var userStepCount = Int32.Parse(Console.ReadLine());

                //Decleration of step counter array
                UserSteps[] stepCount = new UserSteps[userStepCount];
                UserSteps(stepCount);

                DisplayRecipe(IngArray, stepCount);

                FactorIngredients(IngArray);

                ClearData(IngArray, stepCount);
            }
            catch
            {
                //Main error handle, ensures system wont crash
                Console.WriteLine("The system encountered an error, try again");
                ProgramStart();
            }
        }

        //SaveIngredients() allows for user input and saves the Ingredients info to the array.
        public static void SaveIngredients(Ingredients[] IngArray)
        {
            int x = 1;
            try
            {
                for (int i = 0; i < IngArray.Length; i++)
                {
                    Console.WriteLine("Please enter name of ingredient: " + x++);
                    string IngName = Console.ReadLine();
                    if (IngName.Length == 0)
                    {
                        Console.WriteLine("Please add a valid word:");
                        SaveIngredients(IngArray);
                    }

                    //Turned to a var as input will be mixed between string and int
                    Console.WriteLine("Please enter quantity of: " + IngName);
                    double IngQuantity = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Please select a Unit of Measurment for: " + IngName + "\n" +
                    "1. - Gram/s (g)" + "\n" +
                    "2. - Kilogram/s (kg)" + "\n" +
                    "3. - Milliliter/s (ml)" + "\n" +
                    "4. - Liter/s (L)" + "\n" +
                    "5. - Teaspoon/s" + "\n" +
                    "6. - Tablespoon/s" + "\n" +
                    "7. - Cup/s" + "\n" +
                    "8. - Custom Value");
                    string UoM = Console.ReadLine();

                    //Switch case to convert user selection

                    switch (UoM)
                    {
                        case "1":
                            UoM = "Gram/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "2":
                            UoM = "Kilogram/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "3":
                            UoM = "Milliliter/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "4":
                            UoM = "Liter/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "5":
                            UoM = "Teaspoon/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "6":
                            UoM = "Tablespoon/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "7":
                            UoM = "Cup/s";
                            Console.WriteLine("Selected Option: " + UoM);
                            break;

                        case "8":
                            Console.WriteLine("Please enter custom unit of measurment:");
                            UoM = Console.ReadLine();
                            Console.WriteLine("Selected Option: " + UoM);
                            break;
                    }

                    //stores user input into the array
                    IngArray[i] = new Ingredients(IngName, IngQuantity, UoM);
                }
            }
            catch
            {
                //Error handling
                Console.WriteLine("Oh no! That wasn't correct, please try again");
                //Recall method
                SaveIngredients(IngArray);
            }
        }

        //UserSteps methods uses stepCount and saves user's steps to system temporarily (while running).
        public static void UserSteps(UserSteps[] stepCount)
        {
            int x = 1;
            try
            {
                for (int i = 0; i < stepCount.Length; i++)
                {
                    Console.WriteLine("Please enter step " + x++ + " for this recipe:");
                    var stepWritten = Console.ReadLine();
                    stepCount[i] = new UserSteps(stepWritten);
                }
            }
            catch
            {
                //Error handling
                Console.WriteLine("That doesn't look right :( lets give it another go");
                //Recall method
                UserSteps(stepCount);
            }
        }

        //DisplayRecipe method takes values from both arrays and displays the recipe and steps for recipe in a neat manner.
        public static void DisplayRecipe(Ingredients[] IngArray, UserSteps[] stepCount)
        {
            //Set text colour to blue
            Console.ForegroundColor
            = ConsoleColor.Blue;
            try
            {
                Console.WriteLine("" + "\n" +
                "******************************" + "\n" +
                "--------------------" + "\n" +
                "Here is your recipe:" + "\n" +
                "--------------------" + "\n");
                foreach (var ingredient in IngArray)
                {
                    Console.WriteLine($"{ingredient.IngQuantity} {ingredient.UoM} - {ingredient.IngName}"); ;
                }
                Console.WriteLine("" + "\n" +
                "******************************" + "\n" +
                "--------------------------" + "\n" +
                "Here are the recipe steps:" + "\n" +
                "--------------------------" + "\n");
                for (int i = 1; i < stepCount.Count(); i++)
                {
                    foreach (var step in stepCount)
                    {
                        Console.WriteLine("Step:" + i++ + " -" + "\n" + $"{step.userStepCount}");

                    }
                    Console.WriteLine("******************************" + "\n");
                }
            }
            catch
            {
                //Error handling
                Console.ForegroundColor
                    = ConsoleColor.White;
                Console.WriteLine("Something went wrong with the recipe display, please try again");
                //Restarts program
                ProgramStart();
            }
            //Sets text colour back to white
            Console.ForegroundColor
                    = ConsoleColor.White;
        }

        //FactorIngredients() allows user to scale the factor of IngQuantity or follows necessary actions (exit or proceed to steps).
        //UoM is scaled accordingly here, measurements are converted to more appropriate values.
        public static void FactorIngredients(Ingredients[] IngArray)
        {
            double factorScale;
            bool factorScaleCheck = false;

            Console.WriteLine("Would you like to scale the factor of your ingredients? Type Yes or Anything to skip");
            var factorCheck = Console.ReadLine();
            factorCheck = factorCheck.ToLower();


            //while statment ensuring user loops if incorrect values are used
            while (factorScaleCheck == false)
            {
                //if statment checking for valid input and then applying needed factor
                if (factorCheck == "yes" || factorCheck == "y")
                {
                    Console.WriteLine("Please select your factor scale (Enter the corresponding letter): A: x0.5, B: x2, or C: x3");
                    var factorValue = Console.ReadLine();
                    factorValue = factorValue.ToUpper();

                    if (factorValue == "A")
                    {
                        factorScale = 0.5;

                        Console.ForegroundColor
                                = ConsoleColor.Green;

                        Console.WriteLine("Here is the updated recipe: ");
                        //foreach statement looping through IngArray to apply factors and display updated recipe
                        foreach (var ingredient in IngArray)
                        {

                            double updatedQuantity = ingredient.IngQuantity * factorScale;

                            if (updatedQuantity >= 1000 && ingredient.UoM == "Gram/s")
                            {
                                updatedQuantity = updatedQuantity / 1000;
                                ingredient.UoM = "Kilogram/s";
                            }

                            if (updatedQuantity <= 1 && ingredient.UoM == "Kilogram/s")
                            {
                                updatedQuantity = updatedQuantity * 1000;
                                ingredient.UoM = "Gram/s";
                            }

                            if (updatedQuantity >= 1000 && ingredient.UoM == "Milliliter/s")
                            {
                                updatedQuantity = updatedQuantity / 1000;
                                ingredient.UoM = "Liter/s";
                            }

                            if (updatedQuantity <= 1 && ingredient.UoM == "Liter/s")
                            {
                                updatedQuantity = updatedQuantity * 1000;
                                ingredient.UoM = "Milliliter/s";
                            }

                            if (ingredient.UoM == "Teaspoon/s" && updatedQuantity >= 3)
                            {
                                updatedQuantity = updatedQuantity / 3;
                                ingredient.UoM = "Tablespoon/s";
                            }

                            if (ingredient.UoM == "Tablespoon/s" && updatedQuantity < 1)
                            {
                                updatedQuantity = updatedQuantity * 3;
                                ingredient.UoM = "Teaspoon/s";
                            }
                            if (updatedQuantity < 1 && ingredient.UoM == "Cup/s")
                            {
                                updatedQuantity = updatedQuantity * 16;
                                ingredient.UoM = "Tablespoon/s";
                            }

                            Console.WriteLine("");
                            Console.WriteLine($"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                            Console.WriteLine("");
                        }
                        Console.ForegroundColor
                                = ConsoleColor.White;

                        factorScaleCheck = true;
                    }
                    else if (factorValue == "B")
                    {
                        factorScale = 2;
                        Console.ForegroundColor
                                = ConsoleColor.Green;
                        Console.WriteLine("Here is the updated recipe: ");
                        //foreach statement looping through IngArray to apply factors and display updated recipe
                        foreach (var ingredient in IngArray)
                        {
                            double updatedQuantity = ingredient.IngQuantity * factorScale;

                            if (updatedQuantity >= 1000 && ingredient.UoM == "Gram/s")
                            {
                                updatedQuantity = updatedQuantity / 1000;
                                ingredient.UoM = "Kilogram/s";
                            }

                            if (updatedQuantity <= 1 && ingredient.UoM == "Kilogram/s")
                            {
                                updatedQuantity = updatedQuantity * 1000;
                                ingredient.UoM = "Gram/s";
                            }

                            if (updatedQuantity >= 1000 && ingredient.UoM == "Milliliter/s")
                            {
                                updatedQuantity = updatedQuantity / 1000;
                                ingredient.UoM = "Liter/s";
                            }

                            if (updatedQuantity <= 1 && ingredient.UoM == "Liter/s")
                            {
                                updatedQuantity = updatedQuantity * 1000;
                                ingredient.UoM = "Milliliter/s";
                            }

                            if (ingredient.UoM == "Teaspoon/s" && updatedQuantity >= 3)
                            {
                                updatedQuantity = updatedQuantity / 3;
                                ingredient.UoM = "Tablespoon/s";
                            }

                            if (ingredient.UoM == "Tablespoon/s" && updatedQuantity < 1)
                            {
                                updatedQuantity = updatedQuantity * 3;
                                ingredient.UoM = "Teaspoon/s";
                            }
                            if (updatedQuantity < 1 && ingredient.UoM == "Cup/s")
                            {
                                updatedQuantity = updatedQuantity * 16;
                                ingredient.UoM = "Tablespoon/s";
                            }


                            Console.WriteLine("");
                            Console.WriteLine($"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                            Console.WriteLine("");

                        }
                        Console.ForegroundColor
                                = ConsoleColor.White;

                        factorScaleCheck = true;
                    }
                    else if (factorValue == "C")
                    {
                        factorScale = 3;
                        Console.ForegroundColor
                                = ConsoleColor.Green;
                        Console.WriteLine("Here is the updated recipe: ");
                        //foreach statement looping through IngArray to apply factors and display updated recipe
                        foreach (var ingredient in IngArray)
                        {
                            double updatedQuantity = ingredient.IngQuantity * factorScale;

                            if (updatedQuantity >= 1000 && ingredient.UoM == "Gram/s")
                            {
                                updatedQuantity = updatedQuantity / 1000;
                                ingredient.UoM = "Kilogram/s";
                            }

                            if (updatedQuantity <= 1 && ingredient.UoM == "Kilogram/s")
                            {
                                updatedQuantity = updatedQuantity * 1000;
                                ingredient.UoM = "Gram/s";
                            }

                            if (updatedQuantity >= 999 && ingredient.UoM == "Milliliter/s")
                            {
                                updatedQuantity = updatedQuantity / 1000;
                                ingredient.UoM = "Liter/s";
                            }

                            if (updatedQuantity <= 1 && ingredient.UoM == "Liter/s")
                            {
                                updatedQuantity = updatedQuantity * 1000;
                                ingredient.UoM = "Milliliter/s";
                            }

                            if (ingredient.UoM == "Teaspoon/s" && updatedQuantity >= 3)
                            {
                                updatedQuantity = updatedQuantity / 3;
                                ingredient.UoM = "Tablespoon/s";
                            }

                            if (ingredient.UoM == "Tablespoon/s" && updatedQuantity < 1)
                            {
                                updatedQuantity = updatedQuantity * 3;
                                ingredient.UoM = "Teaspoon/s";
                            }
                            if (updatedQuantity < 1 && ingredient.UoM == "Cup/s")
                            {
                                updatedQuantity = updatedQuantity * 16;
                                ingredient.UoM = "Tablespoon/s";
                            }

                            Console.WriteLine("");
                            Console.WriteLine($"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                            Console.WriteLine("");
                        }
                        Console.ForegroundColor
                                = ConsoleColor.White;

                        factorScaleCheck = true;
                    }
                    //else if allowing user to retry, or exit program if an invalid letter is being selected
                    else if (factorValue != "A" || factorValue != "B" || factorValue != "C")
                    {
                        Console.WriteLine("Please enter a valid letter or Z to exit the program");
                        string exitIng = Console.ReadLine();

                        if (exitIng == "Z" || exitIng == "z")
                        {
                            Environment.Exit(0);
                        }
                        factorScaleCheck = false;
                    }
                    //Main if statment else block
                }
                else
                {
                    Console.WriteLine("No Factor applied to quantities");
                    factorScaleCheck = true;
                }
                //Allows user to reset quantities back to original input
                Console.WriteLine("Would you like to reset your quantities? Type R to reset or anything to skip");
                string resetCheck = Console.ReadLine();
                resetCheck = resetCheck.ToUpper();

                Console.ForegroundColor
                            = ConsoleColor.Magenta;
                if (resetCheck == "R")
                {
                    Console.WriteLine("Here is the recipe with the reset values: ");
                    //resets quantities and displays the now new values
                    foreach (var value in IngArray)
                    {
                        double originalQuan = value.IngQuantity;

                        if (value.UoM == "Gram/s")
                        {
                            if (value.IngQuantity <= 1000)
                            {
                                value.UoM = "Kilogram/s";
                            }
                        }
                        else if (value.UoM == "Kilogram/s")
                        {
                            if (value.IngQuantity >= 1)
                            {
                                value.UoM = "Gram/s";
                            }
                        }

                        if (value.UoM == "Milliliter/s" && value.IngQuantity <= 1000)
                        {
                            value.UoM = "Liter/s";
                        }
                        else if (value.UoM == "Liter/s" && value.IngQuantity >= 1)
                        {
                            value.UoM = "Milliliter/s";
                        }

                        if(value.UoM == "Teaspoon/s" && value.IngQuantity >= 3) {
                            value.IngQuantity = value.IngQuantity / 3;
                            value.UoM = "Tablespoon/s";
                        }

                        if(value.UoM == "Tablespoon/s" && value.IngQuantity >= 16) {
                            value.IngQuantity = value.IngQuantity / 16;
                            value.UoM = "Cup/s";
                        }

                        Console.WriteLine("");
                        Console.WriteLine($"{originalQuan} {value.UoM} - {value.IngName}");
                        Console.WriteLine("");

                    }
                    Console.ForegroundColor
                            = ConsoleColor.White;
                }
            }
        }

        //ClearData clears data from IngArray and UserSteps, allowing for a clean start.
        public static void ClearData(Ingredients[] IngArray, UserSteps[] userSteps)
        {
            Console.WriteLine("Would you like to clear and start a new recipe? type \"new\" or anything else to close application");
            string newRecipe = Console.ReadLine();
            newRecipe = newRecipe.ToUpper();

            //Clears arrays
            if (newRecipe == "NEW")
            {
                ProgramStart();

                //If user chooses not to start a new recipe, application will close    
            }
            else
            {
                Environment.Exit(0);
            }
        }

    }
}


