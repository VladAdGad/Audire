using InteractableObjects;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class NoteTriggerAppearingWords : DisplayImageOnPressed
    {
        [SerializeField] private APassiveTriggerable _bloodyText;

        protected override void StopDisplaying()
        {
            base.StopDisplaying();
            _bloodyText.OnTrigger();
        }
    }
}
