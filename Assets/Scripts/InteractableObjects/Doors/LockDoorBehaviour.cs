using EventManagement.Interfaces;
using Gui;
using SceneMenager;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Doors
{
    public class LockDoorBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _toolTipText;
        [SerializeField] private string _lockedStateTooltip;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;

        [SerializeField] private AudioSource _openingDoorAudioSource;
        [SerializeField] private AudioSource _closingDoorAudioSource;

        private Animator _animator;

        private bool _doorLocked = true;
        private bool _doorClosed = true;

        public void UnlockDoor() => _doorLocked = false;


        public void OnGazeEnter() =>
            _tooltipGuiSocket.Display(
                _doorLocked ? $"{_lockedStateTooltip} {KeyCode.E}" : $"{_toolTipText} {KeyCode.E}");

        public void OnGazeExit() => _tooltipGuiSocket.Flush();


        public KeyCode ActivationKeyCode() => _activationButton;

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

            StartCoroutine(LoadScene.ChangeLevel());
        }

        private void CloseDoor()
        {
            if (IsDoorInMotion()) return;

            _closingDoorAudioSource.Play();
            _animator.SetBool("open", false);

            _doorClosed = true;
        }

        private bool IsDoorInMotion() => _openingDoorAudioSource.isPlaying || _closingDoorAudioSource.isPlaying;

        private void Start() => _animator = transform.parent.parent.GetComponent<Animator>();

        private void OnValidate() =>
            Assert.AreNotEqual(_activationButton, KeyCode.None, "Door Actiation button must not be null.");
    }
}
