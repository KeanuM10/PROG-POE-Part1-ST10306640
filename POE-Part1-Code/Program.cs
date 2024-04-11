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
            try {
                MainRepeat();
            } catch {
                
                MainRepeat();
            }
        }

        public static void MainRepeat() {
            try{
            Console.WriteLine("Please enter number of ingredients");
            int ingCounter = Int32.Parse(Console.ReadLine());

            //Decleration of ingredients array
            Ingredients[] IngArray = new Ingredients[ingCounter];
            SaveIngredients(IngArray);

            Console.WriteLine("Please enter the number of steps in recipe: ");
            var userStepCount = Int32.Parse(Console.ReadLine());

            UserSteps[] stepCount = new UserSteps[userStepCount];
            UserSteps(stepCount);

            DisplayRecipe(IngArray, stepCount);

            FactorIngredients(IngArray);

            ClearData(IngArray, stepCount);
            } catch {
                Console.WriteLine("The system encountered an error, try again");
                MainRepeat();
            }
        }

        //SaveIngredients() allows for user input and saves the Ingredients info to the array
        public static void SaveIngredients(Ingredients[] IngArray)
        {
            int x = 1;
            try
            {
                for (int i = 0; i < IngArray.Length; i++)
                {
                    Console.WriteLine("Please enter name of ingredient: " + x++);
                    string IngName = Console.ReadLine();
                    if(IngName.Length == 0) {
                        Console.WriteLine("Please add a valid word");
                        SaveIngredients(IngArray);
                    }

                    //Turned to a var as input will be mixed between string and int
                    Console.WriteLine("Please enter quantity of: " + IngName);
                    int IngQuantity = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter Unit of Measurment for: " + IngName);
                    string UoM = Console.ReadLine();
                    if(UoM.Length == 0) {
                        Console.WriteLine("Please add a valid Unit of Measurment");
                        SaveIngredients(IngArray);
                    }

                    //stores user input into the array
                    IngArray[i] = new Ingredients(IngName, IngQuantity, UoM);
                }
            }
            catch
            {
                Console.WriteLine("Oh no! That should not happen, please try again");
                SaveIngredients(IngArray);
            }
        }

        //UserSteps methods uses stepCount and allows for steps to be written
        public static void UserSteps(UserSteps[] stepCount)
        {
            int x = 1;
            try
            {
                for (int i = 0; i < stepCount.Length; i++)
                {
                    Console.WriteLine("Please enter step " + x++ + " for this recipe");
                    var stepWritten = Console.ReadLine();
                    stepCount[i] = new UserSteps(stepWritten);
                }
            }
            catch
            {
                Console.WriteLine("That doesn't look right :( lets give it another go");
                UserSteps(stepCount);
            }
        }

        //DisplayRecipe method takes values from both arrays and displays the recipe and steps for recipe in a neat manner
        public static void DisplayRecipe(Ingredients[] IngArray, UserSteps[] stepCount)
        {
            Console.ForegroundColor 
            = ConsoleColor.Blue; 
            try {
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

            foreach (var step in stepCount)
            {
                int x = 1;
                Console.WriteLine("Step: " + x++ + $" {step.userStepCount}");
            }
            Console.WriteLine("******************************" + "\n");
            Console.ForegroundColor 
            = ConsoleColor.Black; 
            } catch {
                Console.WriteLine("Something went wrong with the recipe display, please try again");
                MainRepeat();
            }
        }

        //FactorIngredients() allows user to scale the factor of IngQuantity or follows necessary actions (exit or proceed to steps)
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
                            Console.WriteLine($"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
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
                            Console.WriteLine($"{updatedQuantity} {ingredient.UoM} - {ingredient.IngName}");
                        }

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
                    Console.WriteLine("Factor skipped...");
                    factorScaleCheck = true;
                }
                //Allows user to reset quantities back to original input
                Console.WriteLine("Would you like to reset your quantities? Type R to reset or anything to skip");
                string resetCheck = Console.ReadLine();
                resetCheck = resetCheck.ToUpper();

                if (resetCheck == "R")
                {
                    Console.WriteLine("Here is your recipe with reset values: ");
                    //resets quantities and displays the now new values
                    foreach (var value in IngArray)
                    {
                        double originalQuan = value.IngQuantity;
                        Console.WriteLine($"{originalQuan} {value.UoM} - {value.IngName}");
                    }
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
                MainRepeat();

                //If user chooses not to start a new recipe, application will close    
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}


