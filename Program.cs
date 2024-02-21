using System;

class Sales_Receipt_Calculator
{
    static void Main()
    {
        try
        {
            // Display greeting message
            Console.WriteLine("\n****** Customer Sales Receipt Calculator ******");

            // Variable declarations
            const int numberOfProducts = 5;
            const int numberOfCustomers = 3;

            // Arrays to store customer information and product prices
            string[,] customerInfo = new string[numberOfCustomers, 5];
            double[,] products = new double[numberOfCustomers, numberOfProducts];

            // Arrays defining product names and costs
            string[] productList = { "First Item", "Second Item", "Third Item", "Fourth Item", "Last Item" };
            double[] productCosts = { 10, 20, 30, 40, 50 };

            // Loop for multiple customers
            for (int customerIndex = 0; customerIndex < numberOfCustomers; customerIndex++)
            {
                // Collect customer information
                Console.WriteLine($"\nEnter the following information for Customer {customerIndex + 1}:");

                Console.Write("\nFirst Name: ");
                customerInfo[customerIndex, 0] = Console.ReadLine();

                Console.Write("\nLast Name: ");
                customerInfo[customerIndex, 1] = Console.ReadLine();

                Console.Write("\nPhone Number: ");
                customerInfo[customerIndex, 2] = ValidateInput(Console.ReadLine());

                Console.Write("\nE-mail Address: ");
                customerInfo[customerIndex, 3] = ValidateInput(Console.ReadLine());

                Console.Write("\nStreet Address: ");
                customerInfo[customerIndex, 4] = Console.ReadLine();

                Console.WriteLine("\nSelect items from the following list: ");

                // Display product list
                for (int i = 0; i < numberOfProducts; i++)
                {
                    Console.WriteLine($"{productList[i]}: ${productCosts[i]}");
                }

                // Product selection loop
                for (int productIndex = 0; productIndex < numberOfProducts; productIndex++)
                {
                    Console.Write($"\nSelect quantity for {productList[productIndex]}: ");
                    int quantity = ValidateQuantity(Console.ReadLine());

                    // Calculate and store total cost for each product
                    products[customerIndex, productIndex] = quantity * productCosts[productIndex];
                }
            }

            // Display each customer's final receipt
            for (int customerIndex = 0; customerIndex < numberOfCustomers; customerIndex++)
            {
                double total = 0;

                Console.WriteLine($"\n\n------ Customer {customerIndex + 1} Purchase Receipt ------");
                Console.WriteLine($"Customer Name: {customerInfo[customerIndex, 0]} {customerInfo[customerIndex, 1]}");
                Console.WriteLine($"Phone Number: {customerInfo[customerIndex, 2]}");
                Console.WriteLine($"E-mail Address: {customerInfo[customerIndex, 3]}");
                Console.WriteLine($"Street Address: {customerInfo[customerIndex, 4]}");

                Console.WriteLine("\n****** Items Purchased ******");

                // Display each product and its cost
                for (int productIndex = 0; productIndex < numberOfProducts; productIndex++)
                {
                    Console.WriteLine($"{productList[productIndex]}: ${products[customerIndex, productIndex]}");
                    total += products[customerIndex, productIndex];
                }

                // Calculate and display total, tax, and grand total
                double taxes = 0.04 * total;

                Console.WriteLine($"\nTotal: ${total}");
                Console.WriteLine($"Tax Added: ${taxes}");
                Console.WriteLine($"Grand total including tax: ${total + taxes}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Function to validate non-empty string input
    static string ValidateInput(string input)
    {
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty. Please try again: ");
            input = Console.ReadLine();
        }
        return input;
    }

    // Function to validate integer quantity input
    static int ValidateQuantity(string input)
    {
        int quantity;
        while (!int.TryParse(input, out quantity) || quantity <= 0)
        {
            Console.WriteLine("\nInvalid quantity. Please enter an integer equal to or greater than 0: ");
            input = Console.ReadLine();
        }
        return quantity;
    }
}
