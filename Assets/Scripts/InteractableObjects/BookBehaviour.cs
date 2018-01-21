using EventManagement;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class BookBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] private GUISkin _skin;
        [SerializeField] [TextArea] private string _bookText;
        private AudioSource _readingBookAudioSource;
        private bool _isReadingBook = false;


        private void Start() => _readingBookAudioSource = GetComponent<AudioSource>();

        private void OnGUI()
        {
            if (_isReadingBook)
            {
                GUI.skin = _skin;
                GUI.Box(BookRectangle(), _bookText);
            }
        }

        private static Rect BookRectangle() => new Rect(
            Screen.width / 6f,
            Screen.height / 24f,
            Screen.width / 2f + Screen.width / 6,
            Screen.height - Screen.height / 18);

        public void OnGazeEnter()
        {
            _tooltipGuiSocket.Display("TO PICK UP PRESS " + _activationButton);
        }

        public void OnGazeExit()
        {
            _tooltipGuiSocket.Flush();
        }

        private void PlaySound() => _readingBookAudioSource.Play();

        public KeyCode ActivationKeyCode()
        {
            return _activationButton;
        }

        public void OnPress()
        {
            _isReadingBook = !_isReadingBook;
            
            if(_isReadingBook)
                _tooltipGuiSocket.Deactivate();
            else
                _tooltipGuiSocket.Activate();
            
            PlayerBehaviour.SetFirstControllerInteract(!_isReadingBook);
            PlaySound();
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
        }
    }
}