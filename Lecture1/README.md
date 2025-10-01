# Introduction

# Sources

- [Godot Docs](https://docs.godotengine.org/en/stable/)

# Installation

## Godot Engine

- Go to <https://godotengine.org/download/windows/> and download „Godot Engine - .NET", as this version supports C# language
  - Digital Store version **DOES NOT** include C# support
  - You might also have to download .NET SDK at <https://dotnet.microsoft.com/en-us/download> for Godot to work
- Unzip the downloaded file into your directory. After that it should work fine.

# Interface

## Project Manager

When you open Godot the first window you see is the **Project Manager**. Here you can browse through projects, import existing ones or create entirely new projects.

In the **Settings** menu you can change the editor's language, interface theme, display scale, network mode and directory naming convention.

### Asset library

You can access community made projects by opening the **Asset Library** tab. On the first launch you will be prompted to give Godot the permission to search online for privacy reasons.

### Creating new projects

You can edit the name, location of project, and select an initial renderer: **Mobile**,**Forward+**,**Compatibility**. Different renderers are recommended depending on the release platform and targeted hardware you choose for your game. The renderer can be changed later as well, but it can require some reconfiguration of parts of your game.

### Editor

You can search for documentations in Godot directly with **F1** button combination.

On the window editor you can see the following tabs:

- The **main menu** on the top-left side which consists of:
  - **Scene**: open and close scenes
  - **Project**: change the settings of the project, export the project or setup version control (highly recommended to work with version control)
  - **Debug**: editor debugging tools like collision body and navigation visualization
  - **Editor**: change the settings of the editor
  - **Help**: search about Godot features and look up the official documentation
- The workspace switching buttons on the top middle side, you can see the following buttons:
  - **2D**: view the scene in 2D editor mode
  - **3D**: view the scene in 3D editor mode
  - **Script**: open the built-in script editor of Godot (we won't be using it much, instead we will be using Visual Studio)
  - **AssetLib**: open the built-in asset library of Godot (first you must give internet access permission for Godot)
- On the top-right side of the interface, you can see the following buttons:
  - Build project
  - Run project
  - Pause running project
  - Stop running the project

  - Run current scene: Runs the currently open and visible scene.
    - Run default scene: Runs the main scene of the project.

The editor has the following 4 main parts:

- **Viewport**: See the composition of the scene
  - It also has a toolbar on top of it

- **FileSystem**: See project files, scripts, asset files (audio, images, etc.)
- **Scene**: See active scene nodes

- **Inspector**: See the properties of a selected node
- **Bottom panel**: Hosts various interfaces (Debug console, Animation editor, Audio mixer, Shader editor, etc.)

![](/Images/lec1_01.png)

# Structure

## Scenes

Scenes are basically the custom components of our game. They consist of at least a root node, which can possibly hold other nodes and even other scenes too. Scenes inside other scenes are called "Instances", which can be created through the editor (e.g.for implementing player movement) or programmatically (e.g. for creating a wave of enemies).

## Nodes

The predefined building blocks of every game. They have different attributes, and functions, which we can use to build our own game components. The editor makes some of these available for us to adjust quickly, and through code we can call their available functions.  
Nodes come in 4 sets of categories: 3D nodes, 2D nodes, UI nodes, and base nodes. These distinctions are important for when you are working in 2D or 3D, or making the UI itself.  
Nodes can be attached to other nodes, forming a "child" and "parent" relationship.

## Signals

Signals are used for communication between nodes (for example, button pressed emits a signal to start a game/go to settings tab). The available signals can be listed in the Inspector's Node section. Godot supports creating custom signals for our own nodes, and returning some kind of additional value with them.

## Singletons/Global Scenes

Global Scenes are special scenes that get created at the very start of our game, and only one of each can exist at a time. Useful for implementing game logic that is necessary to be accessible from anywhere inside our game(code) (e.g. setting values). Can be accessed from **Project->Project Settings->Globals** menu.

# "Hello Godot"

Let's write a simple script that prints "Hello Godot!" onto the debug console. We are doing it the following way:

- Create a new 3D scene
- Create a script and attach it to the root node
- Write **GD.Print("Hello Godot!")** command into the **\_Ready()** method.

```C#
public override void \_Ready()
{
	GD.Print("Hello Godot!");
}
```

![](/Images/lec1_02.png)