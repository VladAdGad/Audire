using InteractableObjects;
using Triggers;
using UnityEngine;

namespace Sandbox.Dariia
{
    public class NoteAppearingWords : DisplayImageOnPressed
    {
        [SerializeField] private APassiveTriggerable _bloodyText;

        protected override void StopDisplaying()
        {
            base.StopDisplaying();
            _bloodyText.OnTrigger();
        }
    }
}
