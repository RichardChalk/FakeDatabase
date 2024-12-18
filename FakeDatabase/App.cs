﻿using FakeDatabase.Data;
using FakeDatabase.Display;

namespace FakeDatabase;

public class App
{
    public static void Run()
    {
        // Skapa en connection till vår fake Databas
        var dataInitializer = new DataInitializer();
        var DbContext = dataInitializer.MigrateAndSeedData();

        // Skapa en connection till våra kunder i Databasen
        var myCustomers = DbContext.Customers;

        // Visa info kring mina nya kunder
        DisplayCustomerInformation.ShowAllCustomers(myCustomers);

        // Denna lista är NULL. Den fylls aldrig direkt!
        // Detta agerar lite annorlunda med EF-Core.
        // I EF-Core kommer det att finnas data med relevanta foreign keys!
        var myOrders = DbContext.Orders;

        // BONUS! Spectre tables!
        // DisplayCustomerInformation.ShowAllCustomersSpectre(myCustomers);

        // ==========================================================
        // Övning
        // fr1. Visa alla kunder som heter "Anna"

        // fr2. Visa den första kunde som heter "Anna"

        // fr3. Är ALLA fakturor betalda? (svårare)
    }
}
