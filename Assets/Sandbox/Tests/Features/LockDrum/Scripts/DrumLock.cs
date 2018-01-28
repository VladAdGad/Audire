using EventManagement.Interfaces;
using InteractableObjects.Doors;
using Player;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts
{
    public class DrumLock : MonoBehaviour, IPressable
    {
        [SerializeField] private DrumLockGuiSocket _drumLockGuiSocket;
        [SerializeField] private KeyLockedDoor _door;
        [SerializeField] private KeyCode _activationKeyCode;
        [SerializeField] private LockCode _unlockCode;
        [SerializeField] private LockCode _currentCode;

        private bool _interactingWithLock = false;

        public KeyCode ActivationKeyCode() => _activationKeyCode;

        public void OnPress() 
        {
            if (_interactingWithLock)
                StopInteraction();
            else
                StartInteraction();
        }

        private void StopInteraction()
        {
            PlayerBehaviour.PlayerInteractWith(true);
            _drumLockGuiSocket.Flush();
            _interactingWithLock = false;
        }
    
        private void StartInteraction()
        {
            PlayerBehaviour.PlayerInteractWith(false);
            _drumLockGuiSocket.Display(this);
            _interactingWithLock = true;
        }

        public void OnCodeChanged(LockCode newCode)
        {
            _currentCode = newCode;
        
            if (!newCode.IsEqualTo(_unlockCode)) return;

            releaseLock();        
        }

        private void releaseLock()
        {
            _drumLockGuiSocket.Flush();
            PlayerBehaviour.PlayerInteractWith(true);
            transform.parent.gameObject.SetActive(false);
            _door.UnlockDoor();
        }

        public LockCode GetCurrentCode() => _currentCode;
    }
}