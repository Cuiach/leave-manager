﻿using Leave_Manager.Application;
using Leave_Manager.Leave_Manager.ConsoleApp.Presentation;
using Leave_Manager.Leave_Manager.Core.Interfaces;
using Leave_Manager.Leave_Manager.Core.Services;
using Leave_Manager.Leave_Manager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

// Register Services (DbContext, Repositories, Services)
serviceCollection.AddDbContext<LMDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Leave_Manager_ConsoleDb;Trusted_Connection=True;"));


// 1.2. Register Dependencies (Make sure this is here, BEFORE building the service provider)
serviceCollection.AddScoped<ILeaveManagementService, LeaveManagementService>(); 
serviceCollection.AddScoped<IListOfEmployeesService, ListOfEmployeesService>();
serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
serviceCollection.AddScoped<Application>();

//  Build ServiceProvider
var serviceProvider = serviceCollection.BuildServiceProvider();

// Resolve and Use the LeaveManagementService
var application = serviceProvider.GetRequiredService<Application>();
//var leaveManagementService = serviceProvider.GetRequiredService<ILeaveManagementService>();
//var listOfEmployeesService = serviceProvider.GetRequiredService<IListOfEmployeesService>();

Console.WriteLine("--- Leave management app ---");

Menus.ShowMainMenu();

var userInput = Console.ReadLine();

//    Application application = new();

while (true)
{
    switch (userInput)
    {
        case "M":
        case "m":
            Menus.ShowMainMenu();
            break;
        case "1":
            application.AddEmployee();
            break;
        case "2":
            application.DisplayAllEmployees();
            break;
        case "3":
            Console.WriteLine("Insert search phrase");
            var searchPhrase = (Console.ReadLine() ?? ""); //null checker
            application.DisplayMatchingEmployees(searchPhrase);
            break;
        case "4":
            Console.Write("Employee - ");
            int intToRemove = AuxiliaryMethods.GetId();
            if (intToRemove != 0)
            {
                application.RemoveEmployee(intToRemove);
            }
            break;
        case "5":
            Console.Write("Employee - ");
            int employeeId = AuxiliaryMethods.GetId();
            if (employeeId != 0)
            {
                application.AddLeave(employeeId);
            }
            break;
        case "6":
            application.DisplayAllLeaves();
            break;
        case "6D":
            application.DisplayAllLeavesOnDemand();
            break;
        case "6E":
            Console.Write("Employee - ");
            employeeId = AuxiliaryMethods.GetId();
            if (employeeId != 0)
            {
                application.DisplayAllLeavesForEmployee(employeeId);
            }
            break;
        case "6ED":
        case "6DE":
            Console.Write("Employee - ");
            employeeId = AuxiliaryMethods.GetId();
            if (employeeId != 0)
            {
                application.DisplayAllLeavesForEmployeeOnDemand(employeeId);
            }
            break;
        case "7":
            Console.Write("Leave - ");
            int intOfLeaveToRemove = AuxiliaryMethods.GetId();
            if (intOfLeaveToRemove != 0)
            {
                application.RemoveLeave(intOfLeaveToRemove);
            }
            break;
        case "8":
            Console.Write("Leave - ");
            int intOfLeaveToEdit = AuxiliaryMethods.GetId();
            if (intOfLeaveToEdit != 0)
            {
                application.EditLeave(intOfLeaveToEdit);
            }
            break;
        case "9":
            Console.Write("Employee - ");
            int intOfEmployeeToEdit = AuxiliaryMethods.GetId();
            if (intOfEmployeeToEdit != 0)
            {
                application.EditSettings(intOfEmployeeToEdit);
            }
            break;
        case "x":
            return;
        default:
            Console.WriteLine("Invalid operation");
            break;
    }

    Console.WriteLine("Select operation");
    userInput = Console.ReadLine();
}