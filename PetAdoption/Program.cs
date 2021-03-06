﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PetAdoption
{
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }


        static void Main(string[] args)
        {
            // Add some pets to our database of pets

            // | Species | Gender | Age | Name    | Color  | Size   |
            // | ------- | ------ | --- | ------- | ------ | ------ |
            // | Dog     | Female | 1   | Sadie   | Blonde | Medium |
            var sadie = new Pet
            {
                Name = "Sadie",
                Species = "Dog",
                Gender = "Female",
                Age = 1,
                Color = "Blonde",
                Size = "Medium",
            };

            // | Cat     | Male   | 3   | Russell | Black  | Small  |
            var russell = new Pet
            {
                Name = "Russell",
                Species = "Cat",
                Gender = "Male",
                Age = 3,
                Color = "Black",
                Size = "Small",
            };

            // | Dog     | Male   | 3   | Kodak   | White  | Large  
            var kodak = new Pet
            {
                Name = "Kodak",
                Species = "Dog",
                Gender = "Male",
                Age = 3,
                Color = "White",
                Size = "Large",
            };

            var listOfPets = new List<Pet>();

            listOfPets.Add(sadie);
            listOfPets.Add(russell);
            listOfPets.Add(kodak);


            // Welcome the user to the application
            Console.WriteLine();
            Console.WriteLine($"Welcome to our Pet Adoption site, come on in and find a new friend from our {listOfPets.Count} pets.");
            Console.WriteLine();

            var userHasChosenToQuit = false;

            // While the user hasn't quit the application
            while (userHasChosenToQuit == false)
            {
                // Show them a menu of options they can do
                Console.WriteLine("Choose:");
                // - Add a new pet
                Console.WriteLine("(A)dd a new pet");
                // - See all the pets up for adoption
                Console.WriteLine("(S)ee all the pets");
                // - Input a name of a pet that has been adopted to remove them from the list
                Console.WriteLine("A(d)opt out a pet");
                // - Input a name of a pet and update their size
                Console.WriteLine("(U)pdate a pet");
                // - Quit the application
                Console.WriteLine("(Q)uit the application");
                Console.WriteLine();

                var choice = PromptForString("Choice: ");

                // - If the user entered quit, then mark that they have chosen to Quit
                if (choice == "Q")
                {
                    userHasChosenToQuit = true;
                }

                if (choice == "U")
                {
                    // PEDAC
                    //
                    // Problem - Given a pet's name, find that pet in our list, if found
                    //           ask for a new size and update the pet.
                    //
                    // Example:
                    // Name of pet to update: Sadie
                    // -- print out sadie's details
                    // New size for Sadie: Large
                    //
                    // Data
                    //
                    // Pet name (string), List, finding helper, string (new size)
                    //
                    // Algorithm
                    //
                    // Prompt for the name of the pet
                    var nameOfPetToFind = PromptForString("Name of pet being adopted: ");
                    // Use a searching function to find the pet
                    var foundPet = listOfPets.FirstOrDefault(pet => pet.Name == nameOfPetToFind);

                    // If it is not found, say not found
                    if (foundPet == null)
                    {
                        Console.WriteLine($"There is no pet named {nameOfPetToFind}");
                    }
                    else
                    {
                        // else
                        // - print the details
                        var foundPetDescription = foundPet.Description();
                        Console.WriteLine(foundPetDescription);

                        // - ask for a new size
                        var newPetSize = PromptForString("New size: ");

                        // - update the pet
                        foundPet.Size = newPetSize;
                    }
                }

                if (choice == "d")
                {
                    // PEDAC
                    //
                    // Problem - Given a pet's name, find that pet in our list and remove it to indicate it has been adopted out.
                    //
                    // Example:
                    // Sadie, Russell, Kodak
                    // Name of pet being adopted: Kodak
                    // -- find and remove --
                    // Sadie, Russell
                    //
                    // Data
                    // - Name of the pet, string
                    // - List of pets
                    // - Searching helper...
                    //
                    // Algorithm
                    // - Prompt for the name of the pet
                    var nameOfPetToFind = PromptForString("Name of pet being adopted: ");

                    // - Use a searching function to find the pet
                    // - Where
                    // - Find
                    // - First
                    var foundPet = listOfPets.FirstOrDefault(pet => pet.Name == nameOfPetToFind);

                    // - If there is no pet found, inform the user and return
                    if (foundPet == null)
                    {
                        Console.WriteLine($"There is no pet named {nameOfPetToFind}");
                    }
                    else
                    {
                        // - Show the found pet and confirm this is the right one
                        var foundPetDescription = foundPet.Description();
                        Console.WriteLine(foundPetDescription);

                        var shouldWeAdoptOut = PromptForString("Sure you want to adopt this pet out? (Y/N): ");

                        if (shouldWeAdoptOut == "Y")
                        {
                            // - if yes Remove the found pet from the list
                            listOfPets.Remove(foundPet);
                        }
                    }
                }

                if (choice == "A")
                {
                    // PEDAC
                    //
                    // Problem - Gather all the information about a pet, create a new pet and add them to the list.
                    //
                    // Example:
                    // Name: ____
                    // Species: ___
                    // Gender: ____
                    // Age: ____
                    // Color: ___
                    // Size: ___
                    //
                    // Data:
                    //
                    // Strings and int for our inputs, a new Pet, and our List
                    //
                    // Algorithm:
                    //
                    // Prompt for Name
                    var newName = PromptForString("Name: ");
                    // Prompt for Species
                    var newSpecies = PromptForString("Species: ");
                    var newGender = PromptForString("Gender: ");
                    var newAge = PromptForInteger("Age: ");
                    var newColor = PromptForString("Color: ");
                    var newSize = PromptForString("Size: ");

                    // ...
                    // Use these bits of information to create a new pet
                    var newPet = new Pet
                    {
                        Age = newAge,
                        Color = newColor,
                        Gender = newGender,
                        Name = newName,
                        Size = newSize,
                        Species = newSpecies,
                    };
                    // append that new pet to the list
                    listOfPets.Add(newPet);
                }

                if (choice == "S")
                {
                    Console.WriteLine("Here are all the pets");
                    // PEDAC
                    //
                    // p - Print out all the pets to the user
                    //   - Is there an order? Maybe just in the list order?
                    // E - is our list of three pets. Sadie, Russell, and Kodak
                    //
                    // Name is a Gender Size Color Species that is Age years old.
                    // Sadie is a Female Medium Blonde Dog that is 1 years old.
                    // Russell is a Male Small Black Cat that is 3 years old.
                    //
                    //  D - List of pets, and an individual pet.
                    //
                    //  A
                    //    - For each pet in our list of pets
                    //      - Print out the details of that pet according our example

                    //    - For each pet in our list of pets
                    foreach (var pet in listOfPets)
                    {
                        //      - Print out the details of that pet according our example
                        var description = pet.Description();
                        Console.WriteLine(description);

                    }

                }
            }
        }
    }
}
