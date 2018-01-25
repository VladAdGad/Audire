using EventManagement.Interfaces;
using Gui;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Doors
{
    public class DoorBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _toolTipText;
        [SerializeField] private KeyCode _activationButton = KeyCode.Mouse0;
        [SerializeField] private AudioSource _closingDoorAudioSource;
        [SerializeField] private AudioSource _openingDoorAudioSource;

        private Animator _animator;
        private bool _doorClosed = true;

        private void Start()
        {
            _animator = transform.parent.parent.GetComponent<Animator>();
        }

        public void OnGazeEnter() => _tooltipGuiSocket.Display(_toolTipText);
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
        
        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            if (_doorClosed)
                OpenDoor();
            else
                CloseDoor();
        }  
        
        private void OpenDoor()
        {
            if (IsDoorInMotion()) return;
            
            _animator.SetBool("open", true);
            _openingDoorAudioSource.Play();

            _doorClosed = false;
        }

        private void CloseDoor()
        {
            if (IsDoorInMotion()) return;

            _closingDoorAudioSource.Play();
            _animator.SetBool("open", false);

            _doorClosed = true;
        }

        public bool IsDoorClosed()
        {
            return _doorClosed;
        }
        
        private bool IsDoorInMotion() => _openingDoorAudioSource.isPlaying || _closingDoorAudioSource.isPlaying;

        private void OnValidate()
        {
            Assert.AreNotEqual(_activationButton, KeyCode.None, "Door Actiation button must not be null.");
        }
    }
}
