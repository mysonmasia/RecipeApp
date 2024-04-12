
using System;
using System.Numerics;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Recipe class
            Recipe recipe = new Recipe();

            // Display a welcome message to the user
            Console.WriteLine("WELCOME TO THE  RECIPE'S APP OF CHEIFS ");
            double factor = 0;

            // Loop indefinitely until the user chooses to exit
            while (true)
            {
                // Display the menu options to the user
                Console.WriteLine("\n This is the Menu:");
                Console.WriteLine("1. Can you please enter recipe details");
                Console.WriteLine("2. Then  Display recipe");
                Console.WriteLine("3.  Then Scale recipe");
                Console.WriteLine("4.  Then Reset quantities");
                Console.WriteLine("5. Then  Clear all data");
                Console.WriteLine("6. Then  Exit");

                // Prompt the user to enter their choice
                Console.Write("\nPlease nter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                // Switch statement to handle user's choice
                switch (choice)
                {
                    case 1:
                        // Call the EnterDetails method of the Recipe class
                        recipe.EnterDetails();
                        break;
                    case 2:
                        // Call the Display method of the Recipe class
                        recipe.Display();
                        break;
                    case 3:
                        // Call the ScaleRecipe method of the Recipe class
                        Console.Write("\nPlese enter scaling factor (0.5, 2, or 3): ");
                        factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;
                    case 4:
                        // Call the ResetQuantities method of the Recipe class
                        Console.WriteLine($"factor {factor}");
                        recipe.ResetQuantities(factor);
                        break;
                    case 5:
                        // Call the ClearData method of the Recipe class
                        recipe.ClearData();
                        break;
                    case 6:
                        // Exit the program
                        Console.WriteLine(" Closing/Exiting the Recipe App of cheifs . bye");
                        Environment.Exit(0);
                        break;
                    default:
                        // Display an error message for invalid choices
                        Console.WriteLine("Invalid choice. Can you please enter a number between 1 and 6.");
                        break;
                }
            }
        }
    }

    class Recipe
    {
        private string[] ingredients;
        private string[] steps;

        // Method to enter recipe details
        public void EnterDetails()
        {
            Console.Write("\n Please enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            ingredients = new string[ingredientCount];

            // Loop to enter details for each ingredient
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Please enter ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($" Please enter quantity of {name}: ");
                string quantity = Console.ReadLine();

                Console.Write($" Please enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                // Combine name, quantity, and unit into a string and store in the ingredients array
                ingredients[i] = $"{quantity} {unit} of {name}";
            }

            Console.Write("\n Please enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            steps = new string[stepCount];

            // Loop to enter details for each step
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Please enter step {i + 1} description: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine(" This are  the recipe details entered successfully!!!!");
        }

        // Method to display recipe details
        public void Display()
        {
            Console.WriteLine("\nThis is the Recipe Details:");

            // Display  the ingredients
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }

            // Display  the steps
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe(double factor)
        {
            // Loop through ingredients to scale quantities
            double quantity = 0;
            for (int i = 0; i < ingredients.Length; i++)
            {
                string[] parts = ingredients[i].Split(' ');
                quantity = double.Parse(parts[0]) * factor;
                ingredients[i] = $"{quantity} {parts[1]} of {string.Join(" ", parts, 3, parts.Length - 3)}";
                Console.WriteLine($"Factor is: {factor}");
            }

            Console.WriteLine("The recipe is  scaled successfully!!!!");
        }

        // Method to reset quantities
        public void ResetQuantities(double factor)
        {
            Console.WriteLine("The Quantities reset to original values.");
            // Reset to original quantities if needed
            for (int i = 0; i < ingredients.Length; i++)
            {
                string[] parts = ingredients[i].Split(' ');
                double quantity = double.Parse(parts[0]) / factor;
                ingredients[i] = $"{quantity} {parts[1]} of {string.Join(" ", parts, 3, parts.Length - 3)}";
            }
        }

        // Method to clear all data that is stred
        public void ClearData()
        {
            ingredients = null;
            steps = null;
            Console.WriteLine("All data cleared that is stored .");
        }
    }
}
