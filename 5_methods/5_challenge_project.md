# Challenge project - Create a mini-game
This challenge include starter code that requires the learner to complete.

## Project Specification
- The code declares the following variables:
    - Variables to determine the size of the Terminal window.
    - Variables to track the locations of the player and food.
    - Arrays `states` and `foods` to provide available player and food appearances
    - Variables to track the current player and food appearance

- The code provides the following methods:
    - A method to determine if the Terminal window was resized.
    - A method to display a random food appearance at a random location.
    - A method that changes the player appearance to match the food consumed.
    - A method that temporarily freezes the player movement.
    - A method that moves the player according to directional input.
    - A method that sets up the initial game state.

- The code doesn't call the methods correctly to make the game playable. The following features are missing:
    - Code to determine if the player has consumed the food displayed.
    - Code to determine if the food consumed should freeze player movement.
    - Code to determine if the food consumed should increase player movement.
    - Code to increase movement speed.
    - Code to redisplay the food after it's consumed by the player.
    - Code to terminate execution if an unsupported key is entered.
    - Code to terminate execution if the terminal was resized.

- Player appearances can be:
  - ```('-')``` is normal
  - ```(^-^)``` is faster
  - ```(X_X)``` is sick

## Tasks to Complete
In this challenge exercise, you need to update the existing code to support an option to terminate the gameplay if a nondirectional character is entered. You also want to terminate the game if the terminal window was resized. You need to locate the correct methods for your code to use.

### Terminate on resize
This feature must:
- Determine if the terminal was resized before allowing the game to continue
- Clear the Console and end the game if the terminal was resized
- Display the following message before ending the program: Console was resized. Program exiting.

### Add optional termination
- Modify the existing Move method to support an optional boolean parameter
- If true, the optional parameter should determine if nondirectional input terminates the game
- If nondirectional input is detected, allow the game to terminate

### Check if the player consumed the food
- Create a method that uses the existing position variables of the player and food
- The method should return a value
- After the user moves the character, call your method to determine the following:
  - Whether or not to use the existing method that changes player appearance
  - Whether or not to use the existing method to redisplay the food

### Check if the player should freeze
- Create a method that checks if the current player appearance is is sick (```(X_X)```)
- The method should return a value
- Before allowing the user to move the character, call your method to determine the following:
  - Whether or not to use the existing method that freezes character movement
- Make sure the character is only frozen temporarily and the player can still move afterwards

### Add an option to increase player speed
- Modify the existing Move method to support an optional movement speed parameter
- Use the parameter to increase or decrease right and left movement speed by 3
- Create a method that checks if the current player appearance is (^-^)
- The method should return a value
- Call your method to determine if Move should use the movement speed parameter

## Solution
- [Program.cs](./solutions/challenge_mini_game/Program.cs)
- Issues to address:
  - When player laeral movement is faster (speed = 3), the ```FoodConsumed()``` method can return false when the food has been consumed.
    - This bug is due to the way the method checks to see if the food has been consumed when the character is in the exact x,y position the food previously existed.
    - Need another method to determine if the character consumed the food.