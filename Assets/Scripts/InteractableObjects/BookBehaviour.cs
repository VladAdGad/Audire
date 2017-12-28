using System;
using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class BookBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] private GUISkin _skin;
        [SerializeField][TextArea]private string _bookText;
        private bool _isLookingAtBook;
        private AudioSource _readingBookAudioSource;
        private bool _isReadingBook = false;

        private void Start() => _readingBookAudioSource = GetComponent<AudioSource>();

        private void OnGUI()
        {
            if (_isReadingBook)
            {
                GUI.skin = _skin;
                GUI.Box(BookRectangle(), _bookText);
                _isLookingAtBook = false;
            }

            if (_isLookingAtBook)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "TO PICK UP PRESS " + _activationButton);
            }
        }

        private static Rect BookRectangle() => new Rect(
            Screen.width / 6f,
            Screen.height / 24f,
            Screen.width / 2f + Screen.width / 6,
            Screen.height - Screen.height / 18);

        private static Rect TipToInteractReactangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 2 + Screen.height / 4,
            Screen.width / 3f,
            Screen.width / 2 - 2 * Screen.width / 5);

        public void OnGazeEnter()
        {
            _isLookingAtBook = true;
        }

        public void OnGazeExit()
        {
            _isLookingAtBook = false;
        }
        private void PlaySound() => _readingBookAudioSource.Play();

        public KeyCode ActivationKeyCode()
        {
            return _activationButton;
        }

        public void OnPress()
        {
            _isReadingBook = !_isReadingBook;
            PlayerBehaviour.SetFirstControllerInteract(!_isReadingBook);
            PlaySound();
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
        }
    }
}
