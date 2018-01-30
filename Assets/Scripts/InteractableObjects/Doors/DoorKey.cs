using EventManagement.Interfaces;
using Triggers.TriggerableImplementations;
using UnityEngine;

namespace InteractableObjects.Doors
{
    public class DoorKey : MonoBehaviour, IPressable
    {
        [SerializeField] private KeyLockedDoor _doorToOpen;
        [SerializeField] private AudioTriggerable _triggerPickUpKey;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;

        public KeyCode ActivationKeyCode() => _activationButton;

        public virtual void OnPress()
        {
            _doorToOpen.UnlockDoor();
            _triggerPickUpKey.OnTrigger();
            Destroy(gameObject);
        }
    }
}
