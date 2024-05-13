using System;
using Microsoft.VisualBasic;

namespace IngProgram
{
    //Create a delegate for the calorie count cap
    public delegate void CalorieCountEvent (int totalCal);
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
        public List<Ingredients> IngList;
        public List<UserSteps> StepList;

        public Recipe(string name, List<Ingredients> ingList, List<UserSteps> stepList)
        {
            Name = name;
            IngList = ingList;
            StepList = stepList;
        }

        //DisplayRecipe method takes values from both arrays and displays the recipe and steps for recipe in a neat manner.
        public void DisplayRecipe()
        {
            //Set text colour to blue
            Console.ForegroundColor
            = ConsoleColor.Green;

            Console.WriteLine("" +
                              "******************************\n" +
                              "---------------\n" +
                              $"Recipe: {Name}\n" +
                              "---------------\n");

            Console.WriteLine("Ingredients");

            foreach (var ingredient in IngList)
            {
                Console.WriteLine($"{ingredient.IngQuantity} {ingredient.UoM} - {ingredient.IngName}: (Calorie Count: {ingredient.calCount})");
                Console.WriteLine($"Food Group - {ingredient.foodGroup}");
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

            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    class IngredientProgram
    {
        //Created a dictionary
        public static SortedDictionary<string, Recipe> Recipes = new SortedDictionary<string, Recipe>();

        public static void Main(string[] args)
        {
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


        //ProgranStart() Method declares needed arrays and call necessary methods, surrounded in a try catch for error handling.
        public static void ProgramStart()
        {
            //Menu added so program will no longer be sequential
            Console.WriteLine("+-----------------------------------+" +
            "\n" + "| What would you like to do?        |" +
            "\n" + "| 1 - Add a new recipe:             |" +
            "\n" + "| 2 - View a recipe:                |" +
            "\n" + "| 3 - Factor quantities of a recipe:|" +
            "\n" + "| 4 - Exit:                         |" +
            "\n" + "+-----------------------------------+",
            Console.BackgroundColor = ConsoleColor.White,
            Console.ForegroundColor = ConsoleColor.Black
            );
            //Alter colour of text and background so menu appears more vibrant
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please select a valid menu option");
                    ProgramStart();
                    break;
            }
        }

        public static void AddRecipe()
        {
            List<Ingredients> ingList = new List<Ingredients>();
            List<UserSteps> stepList = new List<UserSteps>();

            Console.WriteLine("Please enter the name of your recipe: ");
            string recName = Console.ReadLine();

            if (Recipes.ContainsKey(recName))
            {
                Console.WriteLine("A recipe with this name already exists, please enter a new name");
                AddRecipe();
            }
            Console.WriteLine($"Please enter the number of ingredients in: {recName}");
            int ingCounter = int.Parse(Console.ReadLine());

            SaveIngredients(ingList, ingCounter);

            Console.WriteLine("Please enter the number of steps in the recipe:");
            int userStepCount = int.Parse(Console.ReadLine());

            UserSteps(stepList, userStepCount);

            Recipe newRecipe = new Recipe(recName, ingList, stepList);

            Recipes.Add(recName, newRecipe);

            ProgramStart();
        }

        //SaveIngredients() allows for user input and saves the Ingredients info to the array.
        public static void SaveIngredients(List<Ingredients> IngList, int ingCounter)
        {
            int x = 1;
            int totalCal = 0;
            try
            {
                for (int i = 0; i < ingCounter; i++)
                {
                    Console.WriteLine("Please enter name of ingredient: " + x++);
                    string IngName = Console.ReadLine();

                    //Prompts user for calorie count - to see if total exceeds 300
                    Console.WriteLine("Please enter calorie count for: " + IngName);
                    int calCount = Convert.ToInt32(Console.ReadLine());

                    totalCal = totalCal + calCount;

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

                    //Turned to a double to allow for usage of commas if values are les than 1
                    Console.WriteLine("Please enter quantity of: " + IngName);
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
                    "8. - Custom Value");
                    string UoM = Console.ReadLine();

                    //Prompts user to enter a valid option
                    bool UomCheck = false;
                    while (UomCheck == false)
                    {
                        if (!(UoM.Length == 1 && (UoM[0] >= '1' || UoM[0] <= '8')))
                        {
                            Console.WriteLine("Please select a valid option (1-8).");
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
                                    Console.WriteLine("Please enter custom unit of measurment:");
                                    UoM = Console.ReadLine();
                                    Console.WriteLine("Selected Option: " + UoM);
                                    break;
                            }
                            UomCheck = true;
                        }

                    }

                    //Creating a new Ingredient instance
                    Ingredients newIngredient = new Ingredients(IngName, IngQuantity, UoM, totalCal, foodGroup, calCount);

                    newIngredient.CalorieCountCap += CalorieCountReached;

                    //Adding the new ingredient to the List
                    IngList.Add(newIngredient);
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

        //UserSteps methods uses stepCount and saves user's steps to system temporarily (while running).
        public static void UserSteps(List<UserSteps> stepList, int userStepCount)
        {
            int x = 1;
            try
            {
                for (int i = 0; i < userStepCount; i++)
                {
                    //Asks user for next step while displaying step number
                    Console.WriteLine("Please enter step " + x++ + " for this recipe:");
                    var stepWritten = Console.ReadLine();
                    stepList.Add(new UserSteps(stepWritten));
                }
            }
            catch
            {
                //Error handling
                Console.WriteLine("That doesn't look right :( lets give it another go");
                //Recall method
                UserSteps(stepList, userStepCount);
            }
        }

        public static void FactorRecipeQuantities()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes to factor, please add a recipe first \n");
                ProgramStart();
            }

            Console.WriteLine("Enter the name of the recipe you want to factor - '0' to return to menu");
            string recipeName = Console.ReadLine();

            if (recipeName == "0")
            {
                ProgramStart();
                return;
            }

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

        public static void CalorieCountReached(int totalCal)
        {
            Console.WriteLine($"Calorie Count exceeds 300! Total Calorie Count: {totalCal}");
        }

        //FactorIngredients() allows user to scale the factor of IngQuantity or follows necessary actions (exit or proceed to steps).
        //UoM is scaled accordingly here, measurements are converted to more appropriate values.
        public static void FactorIngredients(List<Ingredients> IngList, List<UserSteps> stepList, string recName)
        {
            double factorScale;
            bool factorScaleCheck = false;

            Console.WriteLine($"Would you like to scale the factor of the ingredient for recipe '{recName}'? Yes or No");
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
                                      "C: x3");
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
                    Console.WriteLine("Invalid choice, please enter 'yes' or 'no'");
                    factorCheck = Console.ReadLine();
                }
            }

            Console.WriteLine($"Would you like to reset the quantities of '{recName}'? Yes or No");
            string resetChoice = Console.ReadLine().ToLower();

            if (resetChoice == "yes" || resetChoice == "y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Here is the recipe for {recName} with the original values:");
                OriginalRecipe(IngList, stepList, recName);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("No reset applied to recipe");
            }
        }

        public static void FactorUpdate(List<Ingredients> IngList, double factorScale)
        {
            foreach (var ingredient in IngList)
            {
                double updatedQuantity = ingredient.IngQuantity * factorScale;
                string updatedUoM = ingredient.UoM;

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

                    Console.WriteLine("***************");
                    Console.WriteLine($"{updatedQuantity} {updatedUoM} - {ingredient.IngName}");
                    Console.WriteLine("---------------");
                }
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

        //ClearData clears data from IngArray and UserSteps, allowing for a clean start.
        public static void ViewRecipe()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("Please add a recipe first before viewing\n");
                ProgramStart();
            }
            else
            {
                Console.WriteLine("Here are the avliable recipes: Press '0' to return to menu");
            }

            int index = 1;

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

            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            ProgramStart();
        }

    }
}


