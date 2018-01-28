# Playable piano scripts

## Scripts

### PianoKeySequenceTriggerer
-Holds key sequence.
-Requires APassiveTriggerable to call on success.

### PianoSequenceKey
-Requires key code to listen when key is pressed.
-Requires PianoKeySequenceTriggerer to call when key is pressed.
-Requires key sound audio source to play when key is pressed.
-Requires some sorte of collider.

## Recomendations
If you want your script to be called when player succesfylly enters sequence - implement APassiveTriggerable, Trigger() method will be called when player succides.
At the moment there is example implementation ActivateOnPassiveTriggered.

# Additional scripts
## TootipOnGaze
-Displays tooltip text, specified in inspector, when player gazes.
-Requires some sort of collider, so player can on gaze it.
-Requires TooltipGuiSocket to display tooltip text.