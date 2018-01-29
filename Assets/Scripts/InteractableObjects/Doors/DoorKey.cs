using EventManagement.Interfaces;
using Triggers;
using UnityEngine;

namespace InteractableObjects.Doors
{
    public class DoorKey : MonoBehaviour, IPressable
    {
        [SerializeField] private KeyLockedDoor _doorToOpen;
        [SerializeField] private APassiveTriggerable _triggerPianoPlaying;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _doorToOpen.UnlockDoor();
            _triggerPianoPlaying.OnTrigger();
            Destroy(gameObject);
        }
    }
}
