# Unity-Basics
Basic Unity games and concepts

## Guitar-Hero-3D
A simple one scene game to simulate a guitar rhythm game.
In this game I've used different concepts of Unity/C# OOD and OOP, such as creating a GameManager to controll the game logic, creating a Static instance of a class so it can be modified by other classes.
The game has 5 different buttons, a look alike guitar with strings, a note spawner, audio and different scoring texts.
All the buttons share the same Script called the [Button_Controller](Guitar_Hero_3D/Assets/Scripts/Button_Controller.cs).
This script is in charge of the color of the button when pressed and when deafult, and also to check if the player pressed the button without hitting any note - a missclick.
The [Notes_Spawner](Guitar_Hero_3D/Assets/Scripts/Notes_Spawner.cs) is in charge of spawning the notes. the spawning happens randomaly on each of the 5 lanes, each lane with the corresponding color.
The [Notes_Behaviour](Guitar_Hero_3D/Assets/Scripts/Notes_Behaviour.cs) is in charge of the behaviour of the spawned notes and checks for collisions in order to detect a hit or a miss.
The [Score](Guitar_Hero_3D/Assets/Scripts/score.cs) is in charge of the score logic and UI. 
The [Game_Manager](Guitar_Hero_3D/Assets/Scripts/Game_Manager.cs) is in charge of the game - starting the game, pausing and resuming the game.
