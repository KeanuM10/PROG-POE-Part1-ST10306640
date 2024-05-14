using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace IngProgram
{
    //Create a delegate for the calorie count cap
    public delegate void CalorieCountEvent(int totalCal);
    //Variable Decleration
    public class Ingredients
    {
        public event CalorieCountEvent CalorieCountCap;

        public string IngName;
        public double IngQuantity;
        public string UoM;
        public int calCount;
        public int totalCal;
        public string foodGroup;

        //Variables now initialzed
        public Ingredients(string IngName, double IngQuantity, string UoM, int totalCal, string foodGroup, int calCount)
        {
            this.IngName = IngName;
            this.IngQuantity = IngQuantity;
            this.UoM = UoM;
            this.totalCal = totalCal;
            this.foodGroup = foodGroup;
            this.calCount = calCount;
        }

        //Notify user when caloriess
        public void CheckCalorieCount()
        {
            if (CalorieCountCap != null && totalCal >= 300)
            {
                CalorieCountCap(totalCal);
            }
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

    //Recipe class created and variables initialzed
    public class Recipe
    {
        public string Name;
        //Creation of Lists - Generic Collections
        public List<Ingredients> IngList;
        public List<UserSteps> StepList;

        //Initialize variables for recipe class
        public Recipe(string name, List<Ingredients> ingList, List<UserSteps> stepList)
        {
            Name = name;
            IngList = ingList;
            StepList = stepList;
        }

        //DisplayRecipe method takes values from both lists and displays them to the user in a neat format upon request.
        public void DisplayRecipe()
        {
            //Set text colour to green
            Console.ForegroundColor
            = ConsoleColor.Green;

            //Display the recipe
            Console.WriteLine("" +
                              "******************************\n" +
                              "---------------\n" +
                              $"Recipe: {Name}\n" +
                              "---------------\n");

            Console.WriteLine("Ingredients");
            foreach (var ingredient in IngList)
            {
                Console.WriteLine($"{ingredient.IngQuantity} {ingredient.UoM} - {ingredient.IngName}");
                Console.WriteLine($"Food Group - {ingredient.foodGroup}");
                Console.WriteLine($"Calorie Count: {ingredient.totalCal}");
                Console.WriteLine("");
            }

            Console.WriteLine("" +
                              "******************************\n" +
                              "-----------------------------\n" +
                              "Here are the recipe steps:\n" +
                              "-----------------------------\n");

            int i = 1;

            foreach (var step in StepList)
            {
                Console.WriteLine($"Step: {i++} -\n{step.userStepCount}");
            }

            Console.WriteLine("******************************\n");
            //Revert text color back to white
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    class IngredientProgram
    {
        //Created a dictionary - Sorted so as to display recipe names in alphabetical order
        public static SortedDictionary<string, Recipe> Recipes = new SortedDictionary<string, Recipe>();

        public static void Main(string[] args)
        {
            //Runs the program, try catch for error handling
            try
            {
                ProgramStart();
            }
            catch
            {
                Console.WriteLine("An error occured within the application, please try again");
                ProgramStart();
            }
        }

        //ProgramStart() displays option menu to user, allowing user to perform multiple actions
        public static void ProgramStart()
        {
            //Menu added so program will no longer be sequential
            Console.WriteLine(
                "+-----------------------------------+\n" +
                "| What would you like to do?        |\n" +
                "| 1 - Add a new recipe:             |\n" +
                "| 2 - View a recipe:                |\n" +
                "| 3 - Factor quantities of a recipe:|\n" +
                "| 4 - Exit:                         |\n" +
                "+-----------------------------------+\n"
            );

            String menuOption = Console.ReadLine();

            //Switch-case allowing user to select from avaliable menu options
            switch (menuOption)
            {
                case "1":
                    // add a recipe
                    AddRecipe();
                    break;
                case "2":
                    //View a recipe
                    ViewRecipe();
                    break;
                case "3":
                    //Factor quantities of a specific recipe
                    FactorRecipeQuantities();
                    break;
                case "4":
                    //Exit the application
                    Environment.Exit(0);
                    break;
                default:
                    //Default informs user to select a valid option
                    Console.WriteLine("Please select a valid menu option");
                    ProgramStart();
                    break;
            }
        }

        //AddRecipe() calls the declared lists and prompts user to add a recipe - name, num of ingredients and steps, adds them to the Lists and returns to menu
        public static void AddRecipe()
        {
            List<Ingredients> ingList = new List<Ingredients>();
            List<UserSteps> stepList = new List<UserSteps>();

            Console.WriteLine("Please enter the name of your recipe: \n");
            string recName = Console.ReadLine();
            //Checks if a recipe with that name exists already
            if (Recipes.ContainsKey(recName))
            {
                Console.WriteLine("A recipe with this name already exists, please enter a new name");
                AddRecipe();
            }
            Console.WriteLine($"Please enter the number of ingredients in: {recName}\n");
            int ingCounter = int.Parse(Console.ReadLine());

            SaveIngredients(ingList, ingCounter);

            Console.WriteLine("Please enter the number of steps in the recipe:\n");
            int userStepCount = int.Parse(Console.ReadLine());

            UserSteps(stepList, userStepCount);

            Recipe newRecipe = new Recipe(recName, ingList, stepList);

            Recipes.Add(recName, newRecipe);

            ProgramStart();
        }

        //SaveIngredients() saves the ingredients and corresponding information. Also calls calorie cap to see if it exceeds 300
        public static void SaveIngredients(List<Ingredients> IngList, int ingCounter)
        {
            int x = 1;
            int totalCal = 0;
            try
            {
                for (int i = 0; i < ingCounter; i++)
                {
                    Console.WriteLine("Please enter name of ingredient: " + x++ + "\n");
                    string IngName = Console.ReadLine();

                    //Allows the user to select a valid food group for each ingredient
                    Console.WriteLine(
                        "Please select food group of: " + IngName + "\n" +
                        "1. - Carbohydrates" + "\n" +
                        "2. - Protein" + "\n" +
                        "3. - Dairy Based" + "\n" +
                        "4. - Fruits/Vegetables" + "\n" +
                        "5. - Fats/Sugars" + "\n" +
                        "6. - Other" + "\n"
                    );

                    string foodGroup = Console.ReadLine();

                    switch (foodGroup)
                    {
                        case "1":
                            foodGroup = "Carbohydrates";
                            break;
                        case "2":
                            foodGroup = "Protein";
                            break;
                        case "3":
                            foodGroup = "Dairy Based";
                            break;
                        case "4":
                            foodGroup = "Fruit/Vegetables";
                            break;
                        case "5":
                            foodGroup = "Fats/Sugars";
                            break;
                        case "6":
                            foodGroup = "Other";
                            break;
                        default:
                            Console.WriteLine("Please select a valid option");
                            SaveIngredients(IngList, ingCounter);
                            break;
                    }

                    if (IngName.Length == 0)
                    {

                        //Error Handling
                        Console.WriteLine("Please add a valid word:");
                        SaveIngredients(IngList, ingCounter);
                    }

                    //Turned to a double to allow for usage of commas if values are less than 1
                    Console.WriteLine("Please enter quantity of: " + IngName + "\n");
                    double IngQuantity = Convert.ToDouble(Console.ReadLine());

                    //Allows user to select from custom units of measurment or to enter own
                    Console.WriteLine("Please select a Unit of Measurment for: " + IngName + "\n" +
                    "1. - Gram/s (g)" + "\n" +
                    "2. - Kilogram/s (kg)" + "\n" +
                    "3. - Milliliter/s (ml)" + "\n" +
                    "4. - Liter/s (L)" + "\n" +
                    "5. - Teaspoon/s" + "\n" +
                    "6. - Tablespoon/s" + "\n" +
                    "7. - Cup/s" + "\n" +
                    "8. - Custom Value\n");
                    string UoM = Console.ReadLine();

                    //Prompts user to enter a valid option
                    bool UomCheck = false;
                    while (UomCheck == false)
                    {
                        if (!(UoM.Length == 1 && (UoM[0] >= '1' || UoM[0] <= '8')))
                        {
                            Console.WriteLine("Please select a valid option (1-8).\n");
                            UoM = Console.ReadLine();
                        }
                        else if (UoM.Length == 1 && (UoM[0] >= '1' || UoM[0] <= '8'))
                        {
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
                                    Console.WriteLine("Please enter custom unit of measurment:\n");
                                    UoM = Console.ReadLine();
                                    Console.WriteLine("Selected Option: " + UoM);
                                    break;
                            }
                            UomCheck = true;
                        }

                    }

                    //Prompts user for calorie count - to see if total exceeds 300
                    Console.WriteLine("Please enter calorie count for: " + IngName + "\n");
                    int calCount = Convert.ToInt32(Console.ReadLine());

                    totalCal += calCount;

                    //Creating a new Ingredient instance
                    Ingredients newIngredient = new Ingredients(IngName, IngQuantity, UoM, totalCal, foodGroup, calCount);

                    newIngredient.CalorieCountCap += CalorieCountReached;

                    //Adding the new ingredient to the List
                    IngList.Add(newIngredient);
                    //Calling calorie delegate
                    newIngredient.CheckCalorieCount();
                }
            }
            catch
            {
                //Error handling
                Console.WriteLine("Oh no! That wasn't correct, please try again");
                //Recall method
                SaveIngredients(IngList, ingCounter);
            }
        }

        //UserSteps prompts user for recipe steps and adds them to the stepList
        public static void UserSteps(List<UserSteps> stepList, int userStepCount)
        {
            int x = 1;
            try
            {
                for (int i = 0; i < userStepCount; i++)
                {
                    //Asks user for next step while displaying step number
                    Console.WriteLine("Please enter step " + x++ + " for this recipe:\n");
                    var stepWritten = Console.ReadLine();
                    stepList.Add(new UserSteps(stepWritten));
                }
            }
            catch
            {
                //Error handling
                Console.WriteLine("That doesn't look right :( lets give it another go\n");
                //Recall method
                UserSteps(stepList, userStepCount);
            }
        }

        //FactorRecipeQuantities reads through 'Recipe' prompting user for which recipe to factor, then goes to factor method
        public static void FactorRecipeQuantities()
        {
            //If no recipes are currently added in system
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes to factor, please add a recipe first \n");
                ProgramStart();
            }

            Console.WriteLine("Enter the name of the recipe you want to factor - '0' to return to menu\n");

            int index = 1;
            //Display available recipes to user
            foreach (var recipe in Recipes)
            {
                Console.WriteLine($"{index++}. {recipe.Key}");
            }

            string recipeName = Console.ReadLine();

            if (recipeName == "0")
            {
                ProgramStart();
                return;
            }
            //If user selects a valid recipe, go to factor method
            if (Recipes.ContainsKey(recipeName))
            {
                Recipe selectedRecipe = Recipes[recipeName];
                FactorIngredients(selectedRecipe.IngList, selectedRecipe.StepList, recipeName);
            }
            else
            {
                Console.WriteLine("Invalid recipe name. please enter a valid recipe");
                FactorRecipeQuantities();
            }
        }

        //CalorieCountReached() Makes use of the delegate, this method simply prints in red when user exceeds 300 calories
        public static void CalorieCountReached(int totalCal)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"\nCalorie Count exceeds 300! Total Calorie Count: {totalCal}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //FactorIngredients() Confirms user input, and prompts for a valid factor option - if recipe is factored, factorUpdate is called
        public static void FactorIngredients(List<Ingredients> IngList, List<UserSteps> stepList, string recName)
        {
            double factorScale;
            bool factorScaleCheck = false;

            Console.WriteLine($"Would you like to scale the factor of the ingredient for recipe '{recName}'? Yes or No\n");
            var factorCheck = Console.ReadLine();
            factorCheck = factorCheck.ToLower();


            //while statment ensuring user loops if incorrect values are used
            while (!factorScaleCheck)
            {
                //if statment checking for valid input and then applying needed factor
                if (factorCheck == "yes" || factorCheck == "y")
                {
                    Console.WriteLine("Please select your factor scale (Enter the corresponding letter):" + "\n" +
                                      "A: x0.5" + "\n" +
                                      "B: x2" + "\n" +
                                      "C: x3\n");
                    string factorChoice = Console.ReadLine().ToUpper();

                    switch (factorChoice)
                    {
                        case "A":
                            factorScale = 0.5;
                            break;
                        case "B":
                            factorScale = 2;
                            break;
                        case "C":
                            factorScale = 3;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter A, B or C.");
                            //Retry until a valid choice has been selected
                            continue;
                    }
                    //Calls FactorUpdate, updating recipe and printing it
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Here is the updated recipe for '{recName}': \n");
                    FactorUpdate(IngList, factorScale);

                    Console.ForegroundColor = ConsoleColor.White;
                    factorScaleCheck = true;
                }
                else if (factorCheck == "no" || factorCheck == "n")
                {
                    Console.WriteLine("No factor applied to recipe.");
                    factorScaleCheck = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please enter 'yes' or 'no'\n");
                    factorCheck = Console.ReadLine();
                }
            }
            //Asks user if theyd like to reset the factor values
            Console.WriteLine($"Would you like to reset the quantities of '{recName}'? Yes or No\n");
            string resetChoice = Console.ReadLine().ToLower();

            if (resetChoice == "yes" || resetChoice == "y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Here is the recipe for {recName} with the original values:\n");
                OriginalRecipe(IngList, stepList, recName);
                Console.ForegroundColor = ConsoleColor.White;

                ProgramStart();
            }
            else
            {
                Console.WriteLine("No reset applied to recipe");
                ProgramStart();
            }
        }

        //FactorUpdate() takes users values and factors them accordingly - scaled so as to convert measurments correctly
        public static void FactorUpdate(List<Ingredients> IngList, double factorScale)
        {
            foreach (var ingredient in IngList)
            {
                double updatedQuantity = ingredient.IngQuantity * factorScale;
                string updatedUoM = ingredient.UoM;
                double updatedCals = ingredient.calCount * factorScale;

                if (updatedUoM == "Gram/s" && updatedQuantity >= 1000)
                {
                    updatedQuantity /= 1000;
                    updatedUoM = "Kilogram/s";
                }

                if (updatedUoM == "Kilogram/s" && updatedQuantity <= 1)
                {
                    updatedQuantity *= 1000;
                    updatedUoM = "Gram/s";
                }

                if (updatedUoM == "Milliliter/s" && updatedQuantity >= 1000)
                {
                    updatedQuantity /= 1000;
                    updatedUoM = "Liter/s";
                }

                if (updatedUoM == "Liter/s" && updatedQuantity <= 1)
                {
                    updatedQuantity *= 1000;
                    updatedUoM = "Milliliter/s";
                }

                if (updatedUoM == "Teaspoon/s")
                {
                    if (updatedQuantity >= 3)
                    {
                        updatedQuantity /= 3;
                        updatedUoM = "Tablespoon/s";
                    }
                    else if (updatedQuantity < 1)
                    {
                        updatedQuantity *= 3;
                        updatedUoM = "Tablespoon/s";
                    }
                }

                if (updatedUoM == "Tablespoon/s")
                {
                    if (updatedQuantity >= 16)
                    {
                        updatedQuantity /= 16;
                        updatedUoM = "Cup/s";
                    }
                    else if (updatedQuantity < 1)
                    {
                        updatedQuantity *= 3;
                        updatedUoM = "Teaspoon/s";
                    }
                }
                //Display recipe to user with updated factor applied
                Console.WriteLine($"{updatedQuantity} {updatedUoM} - {ingredient.IngName}");
                Console.WriteLine($"Food Group: {ingredient.foodGroup}");
                Console.WriteLine($"Calorie Count: {Math.Round(updatedCals)} \n");


            }
        }

        //OriginalRecipe() displays original values, effectively reseting given values.
        public static void OriginalRecipe(List<Ingredients> IngList, List<UserSteps> stepList, string recName)
        {
            //Set text colour to blue
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Recipe: {recName} \n");

            Console.WriteLine("Ingredients:");

            foreach (var ingredient in IngList)
            {
                Console.WriteLine($"{ingredient.IngQuantity} {ingredient.UoM} - {ingredient.IngName}");
                Console.WriteLine($"Food Group: {ingredient.foodGroup}");
                Console.WriteLine($"Calorie Count: {ingredient.calCount} \n");
            }

            Console.WriteLine("Recipe Steps:");
            int stepNum = 1;

            foreach (var step in stepList)
            {
                Console.WriteLine($"Step {stepNum++}: {step.userStepCount}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //ViewRecipe() allows user to enter a created recipe to view it as is.
        public static void ViewRecipe()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("Please add a recipe first before viewing\n");
                ProgramStart();
            }
            else
            {
                Console.WriteLine("Here are the available recipes: Press '0' to return to menu\n");
            }

            int index = 1;
            //Displays avaliable recipes to user
            foreach (var recipe in Recipes)
            {
                Console.WriteLine($"{index++}. {recipe.Key}");
            }

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                ProgramStart();
                return;
            }

            if (Recipes.ContainsKey(choice))
            {
                Recipes[choice].DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Invalid recipe name. please enter a valid recipe");
                ViewRecipe();
            }

            Console.WriteLine("Press any key to return to menu\n");
            Console.ReadKey();
            ProgramStart();
        }

    }
}


