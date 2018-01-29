using System.Collections;
using InteractableObjects.Doors;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DoorCloseTriggerable : ATriggerable
    {
        [SerializeField] private int _delay = 0;
        [SerializeField] private DoorBehaviour _doorBehaviour;

        public override void TriggerEnter(Collider collider)
        {
            StartCoroutine(Wait(_delay));
        }

        public override void TriggerExit(Collider collider)
        {
        }

        public void OnTrigger()
        {
            StartCoroutine(Wait(_delay));
        }

        private IEnumerator Wait(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            _doorBehaviour.OnPress();
        }
    }
}
