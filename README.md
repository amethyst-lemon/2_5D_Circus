# 2_5D_Circus
Unity 2.5d Circus project, demonstrates how to use UI elements and animate them. Basics of C# scripting.

## To-do list:
- [X] Create script to change cursor
- [X] Add and animate UI elements 
- [X] Add background music and sounds
- [X] Add animated characters and prefabs
- [X] Create character selection screen
- [X] Learn about player prefs and saving in json
- [X] Add background cloud animation
- [X] Create Settings
- [X] Settings functional buttons
- [X] Settings music volume change
- [X] Settings sound effects volume change
- [X] Settings resolution change
- [X] Create Leaderboard
- [ ] Leaderboards functional buttons
- [ ] Leaderboard display functionality
- [X] Create Pause
- [X] Pause functional buttons
- [X] Add 7 characters to choose from
- [X] Add idle animations to charaters
- [X] Add idle animations to charaters (level 1 screen)
- [X] Add walking animations to charaters
- [X] Game logic
- and other things not listed

## Game description


## Game elements
### Game screens
**Main menu**

Main game screen has a menu with the following options: Start, Leaderboard, Settings, Exit.

<img src="https://i.imgur.com/3RCZZNd.png" width="800">

**Settings**

Settings has options to change or mute the music and sound effects value. This menu has a reset button to change the value settings back to their default values.

<img src="https://i.imgur.com/7rJAiU8.png" width="800">

**Leaderboard**

Leaderboard is used to display best player scores. Currently displayed as an empty game screen.

<img src="https://i.imgur.com/sWjFmGO.png" width="800">

**Game character selection**

Game character selection screen includes 7 different character to choose from. It also has a player name input field.

<img src="https://i.imgur.com/k5dHiEz.png" width="800">
  
**Game board play field**

Game play board is displayed in 3D with a static camera. Players move on it based on dice roll. The Dice is in it's own seperate area next to the board.


<img src="https://i.imgur.com/fWx5X2o.png" width="800">


### Game board spots
**Normal spot**

Passing the normal spot, player is rewarded with 10 points.

<img src="https://i.imgur.com/x0KacIA.png" width="200">

**Good Spot**

Landing on a Good spot, rewards the player with 50 points.

<img src="https://i.imgur.com/FsgjiFk.png" width="200">

**Bad spot**

Landing on a Bad spot, punishes the player by removing 30 points. Players can have negative points.

<img src="https://i.imgur.com/jWlRbSt.png" width="200">


## How to play
### To start the game
Select play from main menu and choose one of the player characters. Enter your player name and press on the play button. 

### Playing on the game board
When on the game board, wait for your turn and click on the dice. Your character will move automatically according to the dice roll. 

### Gameplay elements
There are Good and Bad spots on the game board. Each of them gives a different number of points. Good spots add points but the Bad spots remove them


## Future update ideas
- Polish the game way more
- Add an in-game option to change game player count and add names for each character
- Add more game elements like item pick-ups, shortcuts and player interactions
- Game board generation to make the game re-playable

