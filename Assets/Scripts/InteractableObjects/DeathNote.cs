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

        private Action _callStartTriggersOnlyOnce;

        private void Start() => _callStartTriggersOnlyOnce = CallOnlyOnce(StartTriggers);

        protected override void StopDisplaying()
        {
            base.StopDisplaying();
            _callStartTriggersOnlyOnce();
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

        private static Action CallOnlyOnce(Action action)
        {
            ContextCallOnlyOnce context = new ContextCallOnlyOnce();
            
            Action returnAction = () =>
            {
                if (context.AlreadyCalled) return;
                action();
                context.AlreadyCalled = true;
            };

            return returnAction;
        }
    }
}
