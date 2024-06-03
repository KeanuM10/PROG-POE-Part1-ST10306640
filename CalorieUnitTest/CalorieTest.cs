using NUnit.Framework;
using IngProgram; 
using System.Collections.Generic;

namespace IngProgram
{
    [TestFixture]
    public class IngredientsTests
    {
        [Test]
        public void TestTotalCalorieCalculation()
        {
            // Arrange
            var ingredient1 = new Ingredients("Ingredient1", 100, "Gram/s", 150, "Carbohydrates", 150);
            var ingredient2 = new Ingredients("Ingredient2", 200, "Gram/s", 250, "Protein", 250);
            var ingredient3 = new Ingredients("Ingredient3", 300, "Gram/s", 350, "Fruits/Vegetables", 350);

            var ingredientsList = new List<Ingredients> { ingredient1, ingredient2, ingredient3 };

            // Calculate expected total calorie count
            int expectedTotalCalories = 150 + 250 + 350;

            // Act
            int actualTotalCalories = 0;
            foreach (var ingredient in ingredientsList)
            {
                actualTotalCalories += ingredient.totalCal;
            }

            // Assert
            Assert.AreEqual(expectedTotalCalories, actualTotalCalories);
        }
    }
}
