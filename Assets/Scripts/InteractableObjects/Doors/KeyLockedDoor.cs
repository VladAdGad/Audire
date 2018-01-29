using EventManagement.Interfaces;
using Gui;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Doors
{
    public class KeyLockedDoor : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _lockedStateTooltip;
        [SerializeField] private string _toolTipText;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private AudioSource _openingDoorAudioSource;
        [SerializeField] private AudioSource _closingDoorAudioSource;

        private Animator _animator;
        private bool _doorLocked = true;
        private bool _doorClosed = true;

        private void Start() => _animator = transform.parent.parent.GetComponent<Animator>();

        public void OnGazeEnter() => _tooltipGuiSocket.Display(_doorLocked
            ? $"{_lockedStateTooltip}"
            : $"{_toolTipText} {_activationButton}");
        
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
        
        public KeyCode ActivationKeyCode() => _activationButton;
        
        public void UnlockDoor() => _doorLocked = false;
        public void LockDoor() => _doorLocked = true;
        public bool IdDoorOpen() => !_doorClosed;

        public void OnPress()
        {
            if (_doorLocked) return;

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

        //TODO @Vlad change this costyl na triggery po okonchaniju animacji, sozdaj boolean id door closed i mienaj s
        //pomoshciu metod etot boolin, a w etoj wozwrashchaj sostojanije
        private bool IsDoorInMotion() => _openingDoorAudioSource.isPlaying || _closingDoorAudioSource.isPlaying;

        private void OnValidate() =>
            Assert.AreNotEqual(_activationButton, KeyCode.None, "Door Actiation button must not be null.");
    }
}
