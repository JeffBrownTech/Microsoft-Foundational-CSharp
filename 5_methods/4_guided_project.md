# Guided project - Plan a Petting Zoo Visit

You're developing an application for the Contoso Petting Zoo that coordinates school visits. The Contoso Petting Zoo is home to 18 different species of animals. At the zoo, visiting students are assigned to groups, and each group has a set of animals assigned to it. After visiting their set of animals, the students will rotate groups until they've seen all the animals at the petting zoo.

By default, the students are divided into 6 groups. However, there are some classes that have a small or large number of students, so the number of groups must be adjusted accordingly. The animals should also be randomly assigned to each group, so as to keep the experience unique.

The design specification for the Contoso Petting Zoo application is as follows:

- There are currently three visiting schools
  - School A has six visiting groups (the default number)
  - School B has three visiting groups
  - School C has two visiting groups

- For each visiting school, perform the following tasks
  - Randomize the animals
  - Assign the animals to the correct number of groups
  - Print the school name
  - Print the animal groups

- Example Output:
    ```
    School A
    Group 1: kangaroos  lemurs  pigs  
    Group 2: alpacas  sheep  chickens  
    Group 3: ducks  geese  capybaras  
    Group 4: ponies  iguanas  tortoises  
    Group 5: ostriches  llamas  rabbits  
    Group 6: macaws  goats  emus  
    
    School B
    Group 1: llamas  ducks  ponies  geese  chickens  goats
    Group 2: iguanas  capybaras  macaws  kangaroos  rabbits  sheep
    Group 3: lemurs  tortoises  alpacas  pigs  emus  ostriches
    
    School C
    Group 1: sheep  ducks  pigs  macaws  kangaroos  ostriches  rabbits  goats  lemurs
    Group 2: iguanas  capybaras  chickens  emus  tortoises  geese  ponies  alpacas  llamas
    ```

- Starter code:
    ```csharp
    using System;

    string[] pettingZoo = 
    {
        "alpacas", "capybaras", "chickens", "ducks", "emus", "geese", 
        "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws", 
        "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
    };
    ```

- [Solution](./solutions/zoo_visit/Program.cs)]