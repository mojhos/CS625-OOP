using System.Text.Json.Serialization;
using System;
using PackLibrary;


Person alice = new() { Name = "Alice" };
Person bob = new() { Name = "Bob" };
Person charlie = new() { Name = "Charlie" };
Person mary = new() { Name = "Mary" };

// Marry Alice and Bob
Person.Marry(alice, bob);
Console.WriteLine("Alice and Bob are married now\n");
// Procreate to have a child
Person baby1 = Person.Procreate(alice, bob); // Creates a biological child
Console.WriteLine("Alice and Bob have a baby now by procreation\n");
// Check if they have children
bool hasKids = Person.HasChildren(alice);

// true, because they have baby1
Console.WriteLine($"having a baby is {hasKids}: it should be True as Alice and Bob have a baby\n");
// Attempt to adopt a child
if (!Person.HasChildren(alice))
{
    // This won't execute as they have baby1
    Person adoptedChild = Person.AdoptChild("Adopted Child", alice, bob);
}
else
{
    Console.WriteLine("You are not eligible to adopt a baby.\n");
}

// Check if a child is a stepchild
bool isStepChild = alice.IsStepChild(baby1);

// false, as baby1 is their biological child
Console.WriteLine($"step child check is {isStepChild}: it should be false as the baby1 is their biological child.\n ");

// Get parents of the baby
List<Person> parents = alice.GetParents(baby1); // returns Alice and Bob

foreach (var parent in parents)
{
    Console.WriteLine($"{parent.Name} is one of the parents. ");
}

Person.Marry(charlie, mary);
Console.WriteLine("Charlie and Mary are married now.\n");
// jack is adopted by charlie and mary
Person jack = Person.AdoptChild("jack", charlie, mary);
//it should be true id charly was adopted

bool var = mary.IsStepChild(jack);

Console.WriteLine($"step child check is {var}: it should be True as charlie and mary adopted jack ");
Console.Read();


