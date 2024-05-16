using System;
using System.Collections.Generic;

class Asset
{
    public string ProductName { get; set; }
    public string EmployeeName { get; set; }
    public string InitialCondition { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? DateReturned { get; set; }
    public string ReturnCondition { get; set; }

    public Asset(string productName, string employeeName, string initialCondition, DateTime dateIssued)
    {
        ProductName = productName;
        EmployeeName = employeeName;
        InitialCondition = initialCondition;
        DateIssued = dateIssued;
    }

    public void Return(DateTime dateReturned, string returnCondition)
    {
        DateReturned = dateReturned;
        ReturnCondition = returnCondition;
    }
}

class Program
{
    static void Main()
    {
        List<Asset> assets = new List<Asset>();

        while (true)
        {
            // Enter details about product
            Console.WriteLine("Enter details about the product:");
            Console.Write("Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Employee Name: ");
            string employeeName = Console.ReadLine();

            Console.Write("Initial Condition: ");
            string initialCondition = Console.ReadLine();

            Console.Write("Date Issued (yyyy-mm-dd): ");
            DateTime dateIssued = DateTime.Parse(Console.ReadLine());

            Console.Write("Date Returned (yyyy-mm-dd) or leave blank if not returned: ");
            string dateReturnedInput = Console.ReadLine();
            DateTime? dateReturned = null;
            string returnCondition = null;
            if (!string.IsNullOrWhiteSpace(dateReturnedInput))
            {
                dateReturned = DateTime.Parse(dateReturnedInput);
                Console.Write("Condition when Returned: ");
                returnCondition = Console.ReadLine();
            }

            Asset asset = new Asset(productName, employeeName, initialCondition, dateIssued);
            if (dateReturned != null)
            {
                asset.Return(dateReturned.Value, returnCondition);
            }
            assets.Add(asset);

            // Continue option
            Console.WriteLine("Do you want to continue entering data for other employees? (Y/N)");
            string continueOption = Console.ReadLine();
            if (continueOption.ToUpper() != "Y")
                break;
        }

        // Display device checkout and return logs
        Console.WriteLine("Employee-wise Asset Details:");
        Console.WriteLine("----------------------------");
        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "Employee Name", "Product Name", "Initial Condition", "Final Condition", "Issued Date", "Returned Date");
        foreach (var asset in assets)
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}",
                asset.EmployeeName,
                asset.ProductName,
                asset.InitialCondition,
                asset.ReturnCondition ?? "Not returned",
                asset.DateIssued.ToString("yyyy-MM-dd"),
                asset.DateReturned?.ToString("yyyy-MM-dd") ?? "Not returned");
        }
    }
}