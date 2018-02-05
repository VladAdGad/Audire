using System;
using Triggers;
using Triggers.TriggerableImplementations;
using UnityEngine;
using Utilities;

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

        private OneTimeAction _oneTimeAction;

        private void Start() => _oneTimeAction = new OneTimeAction(StartTriggers);

        protected override void StopDisplaying()
        {
            base.StopDisplaying();
            _oneTimeAction.Invoke();
        }

        private void StartTriggers()
        {
            _deathTrigger.OnTrigger();
            _triggerSound.OnTrigger();
            _triggerCollisionZone.OnTrigger();
            _triggerCloseDoor.OnTrigger();
            _triggerKnockSound.OnTrigger();
            _triggerBreathPanicSound.OnTrigger();
        }
    }
}
