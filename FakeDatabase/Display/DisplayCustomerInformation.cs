
using FakeDatabase.Models;
using Spectre.Console;

namespace FakeDatabase.Display;

public class DisplayCustomerInformation
{
    public static void ShowAllCustomers(List<Customer> myCustomers)
    {
        foreach (Customer customer in myCustomers)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(customer.GetFullName());
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var order in customer.Orders)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ordernummer: " + order.OrderId);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Datum: " + order.OrderDate);

                foreach (var product in order.Items)
                {
                    Console.WriteLine("ProduktId: " + product.ProductId);
                    Console.WriteLine("ProduktId: " + product.ProductName);
                }

                Console.WriteLine("Total kostnad: " + order.CalculateTotal() + " kr");
                Console.WriteLine("Förfallosdatum: " + order.Invoice.DueDate);
                
            }
            Console.WriteLine("======================================");
        }
    }

    public static void ShowAllCustomersSpectre(List<Customer> myCustomers)
    {
        var table = new Spectre.Console.Table();
        table.Border = Spectre.Console.TableBorder.Double;
        table.AddColumn("[bold white on green]Ordernummer[/]");
        table.AddColumn("[blue]Namn[/]");
        table.AddColumn("[blue]Datum[/]");
        table.AddColumn("[blue]Produkter[/]");
        table.AddColumn("[blue]Total kostnad[/]");
        table.AddColumn("[blue]Förfallodatum[/]");

        foreach (var customer in myCustomers)
        {
            foreach (var order in customer.Orders)
            {
                var productNames = string
                    .Join(", ", order.Items
                    .Select(i => i.ProductName));

                table.AddRow(
                    order.OrderId.ToString(),
                    customer.GetFullName(),
                    order.OrderDate.ToString("yyyy-MM-dd"), 
                    productNames,
                    $"{order.CalculateTotal()} kr",
                    order.Invoice.DueDate.ToString("yyyy-MM-dd")
                );
            }
        }

        Spectre.Console.AnsiConsole.Write(table);
    }

}
