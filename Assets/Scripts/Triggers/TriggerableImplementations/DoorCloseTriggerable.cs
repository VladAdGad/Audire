using System.Collections;
using InteractableObjects.Doors;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DoorCloseTriggerable : ATriggerable
    {
        [SerializeField] [Tooltip("seconds")] private int _delay;
        [SerializeField] private DoorBehaviour _doorBehaviour;

        public override void TriggerEnter(Collider collider) => StartCoroutine(CloseOpenDoorWithDelay(_delay));
        
        public override void TriggerExit(Collider collider)
        {
        }

        public void OnTrigger() => StartCoroutine(CloseOpenDoorWithDelay(_delay));

        private IEnumerator CloseOpenDoorWithDelay(int seconds)
        {
            if (seconds == 0) seconds = 1;
            yield return new WaitForSeconds(seconds);
            _doorBehaviour.OnPress();
        }
    }
}
