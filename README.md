# CODEQUEST: From Code Novice to Job-Ready Engineer

- Welcome to CODEQUEST Repository

 - [x] [Day One Lesson](/Day1/Lesson.md)
    - Daily coding challenge
        - [ ] May 27, 2024
            ### Create a console app solution in visual studio code that will print your full name, age and gender

            1. You must create a variable that will hold your first name, middle name, and last name
            2. Create a variable to store your age in integer
            3. Create a variable to store your gender in string.
            4. Display your personal information using string interpolation
            
        - [ ] May 28, 2024
            ### Create decision logic with if statement
            
            You'll use the Random.Next() method to simulate rolling three six-sided dice. You'll evaluate the rolled values to calculate the score. If the score is greater than an arbitrary total, then you'll display a winning message to the user. If the score is below the cutoff, you'll display a losing message to the user.

             1. If any two dice you roll result in the same value, you get two bonus points for rolling doubles.
             2. If all three dice you roll result in the same value, you get six bonus points for rolling triples.
             3. If the sum of the three dice rolls, plus any point bonuses, is 15 or greater, you win the game. Otherwise, you lose.

            Sample output
            ```
            Dice roll: 3 + 4 + 5 = 12
            Sorry, you lose.
            ```
        
        - [ ] May 29, 2024
            ### Comparing 3 numbers

            Create a new dotnet console that will compare 3 numbers and display the highest number and the lowest number.

            Start your code by declaring 3 int variables.

            ```c#
            int num1 = 25;
            int num2 = 75;
            int num3 = 10;
            ```

            The output of your code should be like this.
            ```
            Highest Number: 75
            Lowest Number: 10
            ```

             *Extra challenge: Try stroring the 3 numbers in an array and iterate through it to find the highest and lowest number.*

        - [ ] May 30, 2024
            ### Check if even

            Create a program that will check if a number is even.

            Start by declaring a variable
            ```c#
            int numberToCheck = 6;
            ```

            Your output should be like
            ```
            Number 6 is even
            Number 7 is not even
            ```
 - [x] [Day Two Lesson](/Day2/Lesson.md)
    - Daily coding challenge
        - June 3 - 7, 2024
            ### Create new MVC .Net Web App Repository
            
            Create a new model class with the properties FirstName, Middle Name, Last Name and Age

            Create an instace of this class and and display it in a h1 tag 
 - [x] [Day Three Lesson](/Day3/Lesson.md)
    - Coding challenge for the week
        ### Create an inventory list screen
            
        - [ ] Create a new solution for your inventory list screen

        - [ ] Create an inventory model in the Model folder that has the properties ItemID, ItemName, ItemDescription, ItemCode, Quantity, and CreateDate.

        - [ ] Create a new controller and name it InventoryController.

        - [ ] Create a new method in the InventoryController and create a new view.

        - [ ] Create a list of your inventory model and add a dummy data.

            Display the dummy datas in a table in your newly created view. 

 - [x] [Day Four Lesson](/Day4/Lesson.md)
    - Coding challenger
        ### Create a database and edit screen for your inventory list screen

        - [ ] Create a database for your inventory list screen

        - [ ] Create `AppDbContext.cs` and model for your inventory list screen

        - [ ] Create `IInventoryRepository` and `InventoryRespository.cs`

        - [ ] Migrate your models to your database

        - [ ] Update your list screen to display all datas in the database

        - [ ] Create an edit screen

    - Create a repository and all all your coding challenge



