using InteractableObjects;
using UnityEngine;

namespace Sandbox.Amid.Scripts.Triggers.TriggerableImplementations
{
    [RequireComponent(typeof(DoorBehaviour))]
    public class DoorCloseTriggerable : ATriggerable
    {
        private bool _canClosed = true;
        private DoorBehaviour _doorBehaviour;

        void Start() => _doorBehaviour = GetComponent<DoorBehaviour>();

        public override void TriggerEnter(Collider collider)
        {
            if (_canClosed)
            {
                _doorBehaviour.OnPress();
                _canClosed = false;
            }
        }

        public override void TriggerExit(Collider collider)
        {
        }
    }
}
