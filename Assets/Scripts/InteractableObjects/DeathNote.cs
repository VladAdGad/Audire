using Triggers;
using Triggers.TriggerableImplementations;
using UnityEngine;

namespace InteractableObjects
{
    public class DeathNote : DisplayImageOnPressed
    {
        [SerializeField] private DeathTrigger _deathTrigger;
        [SerializeField] private APassiveTriggerable _triggerSound;
        [SerializeField] private APassiveTriggerable _triggerCollisionZone;
        [SerializeField] private AudioTriggerable _triggerKnockSound;
        [SerializeField] private AudioTriggerable _triggerBreathPanicSound;
        [SerializeField] private DoorCloseTriggerable _triggerCloseDoor;

        protected override void StopDisplaying()
        {
            base.StopDisplaying();
            _deathTrigger.OnTrigger();
            _triggerSound.OnTrigger();
            _triggerCollisionZone.OnTrigger();
            _triggerCloseDoor.OnTrigger();
            _triggerKnockSound.OnTrigger();
            _triggerBreathPanicSound.OnTrigger();
        }
    }
}
