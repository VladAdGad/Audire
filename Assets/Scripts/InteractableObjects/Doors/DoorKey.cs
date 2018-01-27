using EventManagement.Interfaces;
using UnityEngine;

namespace InteractableObjects.Doors
{
    public class DoorKey : MonoBehaviour, IPressable
    {
        [SerializeField] private KeyLockedDoor _doorToOpen;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _doorToOpen.UnlockDoor();
            Destroy(gameObject);
        }
    }
}
