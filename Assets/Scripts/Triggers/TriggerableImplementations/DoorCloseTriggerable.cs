using System.Collections;
using InteractableObjects.Doors;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DoorCloseTriggerable : ATriggerable
    {
        [SerializeField] private int _delay = 0;
        [SerializeField] private DoorBehaviour _doorBehaviour;
        private bool _canClosed = true;

        public override void TriggerEnter(Collider collider)
        {
            if (_canClosed)
            {
                StartCoroutine(Wait(_delay));
            }
        }

        public override void TriggerExit(Collider collider)
        {
        }

        private IEnumerator Wait(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            _canClosed = false;
            _doorBehaviour.OnPress();
        }
    }
}
