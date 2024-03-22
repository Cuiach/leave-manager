﻿using Inewi_Console.Entities;

Console.WriteLine("--- Leaves of employees management app ---");

Console.WriteLine("1 Add employee");
Console.WriteLine("2 Display all employees");
Console.WriteLine("3 Search employee");
Console.WriteLine("4 Remove employee");
Console.WriteLine("5 Add employee's leave");
Console.WriteLine("6 Display all leaves");
Console.WriteLine("7 Remove leave");
Console.WriteLine(" To exit insert 'x'");

var userInput = Console.ReadLine();

var listOfEmployees = new ListOfEmployees();
var allLeavesInStorage = new HistoryOfLeaves();

while (true)
{
    switch (userInput)
    {
        case "1":
            Console.WriteLine("Insert first name");
            var firstName = Console.ReadLine();
            Console.WriteLine("Insert last name");
            var lastName = Console.ReadLine();
            if (firstName != null && lastName != null)
            {
                int idNewEmployee = listOfEmployees.Employees.Count == 0 ? 1 : listOfEmployees.Employees.LastOrDefault().Id + 1;
                
                var newContact = new Employee(firstName, lastName, idNewEmployee);

                listOfEmployees.AddEmployee(newContact);
            }

            break;
        case "2":
            listOfEmployees.DisplayAllEmployees();
            break;
        case "3":
            Console.WriteLine("Insert search phrase");
            var searchPhrase = (Console.ReadLine() ?? ""); //null checker
            listOfEmployees.DisplayMatchingEmployees(searchPhrase);
            break;
        case "4":
            Console.WriteLine("Insert id");
            var idToRemove = (Console.ReadLine() ?? "0");
            int intToRemove;
            bool _ = int.TryParse(idToRemove, out intToRemove);
            if (intToRemove != 0)
            {
                listOfEmployees.RemoveEmployee(intToRemove);
            }
            break;
        case "5":
            Console.WriteLine("Insert employee's id");
            var employeeIdAsString = (Console.ReadLine() ?? "0");
            int employeeId;
            bool __ = int.TryParse(employeeIdAsString, out employeeId);
            if (employeeId != 0)
            {
                allLeavesInStorage.AddLeave(employeeId);
            }
            break;
        case "6":
            allLeavesInStorage.DisplayAllLeaves();
            break;
        case "7":
            Console.WriteLine("Insert id");
            var idOfLeaveToRemove = (Console.ReadLine() ?? "0");
            int intOfLeaveToRemove;
            bool ___ = int.TryParse(idOfLeaveToRemove, out intOfLeaveToRemove);
            if (intOfLeaveToRemove != 0)
            {
                allLeavesInStorage.RemoveLeave(intOfLeaveToRemove);
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