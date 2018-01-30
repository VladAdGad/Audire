using Assets.Sandbox.Tests.Features.LockDrum.Scripts.GUI;
using Assets.Sandbox.Tests.Features.LockDrum.Scripts.Unlockables;
using EventManagement.Interfaces;
using InteractableObjects.Doors;
using Player;
using Triggers;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts.Lock
{
    public class DrumLock : MonoBehaviour, IPressable
    {
        [SerializeField] private DrumLockGuiSocket _drumLockGuiSocket;
        [SerializeField] private AUnlockable _aUnlockable;
        [SerializeField] private APassiveTriggerable _triggbleOnUnlock;
        [SerializeField] private KeyCode _activationKeyCode;
        [SerializeField] private LockCode _unlockCode;
        [SerializeField] private LockCode _currentCode;

        private bool _interactingWithLock = false;
        
        public string GetCurrentCodeAt(int index) => _currentCode.GetCodeAt(index);
        
        public KeyCode ActivationKeyCode() => _activationKeyCode;
        public void OnPress()
        {
            if (IsRightCodeEntered()) return;
            
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


        public void DrumChanged(int buttonIndex, string drumNumber)
        {
            _currentCode.ChangeSequenceMember(buttonIndex, drumNumber);

            if (IsRightCodeEntered())
                ReleaseLock();
        }
        
        private bool IsRightCodeEntered() => _currentCode.IsEqualTo(_unlockCode);
        private void ReleaseLock()
        {
            _aUnlockable.Unlock();
            _triggbleOnUnlock.OnTrigger();
            _drumLockGuiSocket.Flush();
            gameObject.SetActive(false);
            PlayerBehaviour.PlayerInteractWith(true);
        }
    }
}