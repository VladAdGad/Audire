using InteractableObjects.Doors;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DoorKeyTriggerPianoPlaying : DoorKey
    {
        [SerializeField] private APassiveTriggerable _triggerPianoPlaying;
        
        public override void OnPress()
        {
            base.OnPress();
            _triggerPianoPlaying.OnTrigger();
        }
    }
}
