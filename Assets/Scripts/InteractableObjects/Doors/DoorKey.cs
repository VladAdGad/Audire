using EventManagement.Interfaces;
using UnityEngine;

namespace InteractableObjects.Doors
{
    public class DoorKey : MonoBehaviour, IPressable
    {
        [SerializeField] private KeyLockedDoor _doorToOpen;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private AudioSource _soundOnPickUpAudioSource;

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _doorToOpen.UnlockDoor();
            _soundOnPickUpAudioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
