using System.Collections;
using InteractableObjects.Doors;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    [RequireComponent(typeof(DoorBehaviour))]
    public class DoorCloseTriggerable : ATriggerable
    {
        [SerializeField] private int _delay = 0;
        private bool _canClosed = true;
        private DoorBehaviour _doorBehaviour;

        private void Start() => _doorBehaviour = GetComponent<DoorBehaviour>();

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
