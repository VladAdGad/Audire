using EventManagement.Interfaces;
using Triggers;
using UnityEngine;

namespace InteractableObjects.Doors
{
    public class DoorKey : MonoBehaviour, IPressable
    {
        [SerializeField] private KeyLockedDoor _doorToOpen;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private APassiveTriggerable _triggerOnSuccess1;

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _doorToOpen.UnlockDoor();
            Destroy(gameObject);
            _triggerOnSuccess1.OnTrigger();
        }
    }
}
