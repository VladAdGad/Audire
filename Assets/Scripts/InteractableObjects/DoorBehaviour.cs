using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class DoorBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private GUISkin _skin;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        private bool _isOpeningDoor = false;
        private bool _isLookingAtDoor = false;
        private bool _stateOfDoor = false;
        private Animator _animator;
        private AudioSource _openingDoorAudioSource;

        private void Start()
        {
            _openingDoorAudioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }

        private void OnGUI()
        {
            if (_isLookingAtDoor)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "FOR OPEN PRESS " + _activationButton);
            }
        }

        private static Rect TipToInteractReactangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 2 + Screen.height / 4,
            Screen.width / 3f,
            Screen.width / 2 - 2 * Screen.width / 5);

        public void OnGazeEnter() => _isLookingAtDoor = true;
        public void OnGazeExit() => _isLookingAtDoor = false;
        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _isOpeningDoor = !_isOpeningDoor;
            _stateOfDoor = !_stateOfDoor;
            _animator.SetBool("open", _stateOfDoor);
            PlaySound();
        }

        private void PlaySound()
        {
            if (!_openingDoorAudioSource.isPlaying)
            {
                _openingDoorAudioSource.Play();
            }
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
            Assert.AreNotEqual(_activationButton, KeyCode.None);
        }
    }
}