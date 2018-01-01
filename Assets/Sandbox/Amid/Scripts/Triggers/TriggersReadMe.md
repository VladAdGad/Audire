### Triggers
##How to use:
1) Create game object (prefferably empty one)
2) Add collider to placed object
3) Size collider and position object in world
4) Add TriggerNode to created object

5) Add some ATriggerableScripts to desiered objects (DoorCloseTriggerable or DissapearingTriggerable, for example, ussualy they have Triggerable in the end of name)
6) Set number of triggerables in your TriggerNode component
7) Add Triggerables to TriggerNode component

## Description:
You can put your triggerable in many trigger nodes at the same time and they will stay anaware of it and will work as intended, responding to calls from different triger nodes.

The End.