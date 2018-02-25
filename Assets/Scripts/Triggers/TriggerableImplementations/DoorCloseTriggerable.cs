using System.Collections;
using InteractableObjects.Doors;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DoorCloseTriggerable : ATriggerable
    {
        [SerializeField] [Tooltip("seconds")] private int _delay;
        [SerializeField] private DoorBehaviour _doorBehaviour;

        public override void TriggerEnter(Collider collider) => StartCoroutine(CloseDoorWithDelay(_delay));

        public override void TriggerExit(Collider collider)
        {
        }

        public void OnTrigger() => StartCoroutine(CloseDoorWithDelay(_delay));

        private IEnumerator CloseDoorWithDelay(int seconds)
        {
            if (seconds == 0) seconds = 1;
            yield return new WaitForSeconds(seconds);
            if (_doorBehaviour.IsDoorClosed == false)
                _doorBehaviour.CloseDoor();
        }
    }
}
