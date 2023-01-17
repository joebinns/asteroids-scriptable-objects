# Game Settings Tool
A tool for modifying game settings, made for Futuregames' course "Development Tools in Game Projects". The tool utilises a custom editor window and scriptable objects, and is applied to an Asteroids remake.

## Reflection
This project has served well to guide my independent learning of Unity's recent UI Toolkit. Initially, I set out creating a modular ship creator -- as a tool that could be used by both designers and players alike.

<img alt="Modular Ship Builder" width="503" src="https://joebinns.com/documents/gifs/modular_ship_builder.gif" />

However, after encoutnering constant hurdles over just a few days work and seeing many more on the horizon, I came to the realisation that I had likely aimed too high. The unsuspecting UI Toolkit was ill equipped to take on such a tool, leaving me with a daunting list of features to implement. With a tight deadline and a growing assortment of non-Futuregames tasks accruing, I made the tough decision to restart and rescope on something slightly less impressive.

What I ended up creating was a tool for modifying game settings. The tool acts as a window for editting game settings which are stored in a scriptable object. The tool is content aware, automatically detecting instances of of-interest MonoBehaviours in the scene and updating their appropriate serialized fields.

<img alt="Game Settings Tool" width="503" src="https://joebinns.com/documents/gifs/game_settings_tool.gif" />

Having implemented this tool, I have learned more than just how to use the UI Toolkit. Crucially, I have become aware of SerializedObjects in Unity and a developed a understanding for where they are appropriate and how they should be used.
Whilst it didn't present itself as in issue during testing of the tool, there is one problem which I have substituted for another, rather than answered. That is 'in which EditorWindow Message I should use to apply the game settings to the fields of MonoBehaviours'. Ideally, I would apply changes whenever they are made. However, a method alike OnValidate does not exist for EditorWindows, and so I have instead placed this behaviour in OnLostFocus -- similar functionality, but not quite correct.
