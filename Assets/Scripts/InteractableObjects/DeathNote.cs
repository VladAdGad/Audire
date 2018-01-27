using Triggers.TriggerableImplementations;
using UnityEngine;

namespace InteractableObjects
{
    public class DeathNote : DisplayImageOnPressed
    {
        [SerializeField] private DeathTrigger _deathTrigger;
        
        protected override void StopDisplaying()
        {
            base.StopDisplaying();
            _deathTrigger.OnTrigger();
        }
    }
}
