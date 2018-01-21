using EventManagement;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class ReadingImageDisplay : MonoBehaviour, IGazable, IPressable
    {
        [Header("Gui Sockets")]
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private ImageGuiSocket _imageGuiSocket;
        [Space(10)]
        
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] private AudioSource _readingBookAudioSource;

        [SerializeField] private Sprite displayImage;
        
        private bool _isReadingBook = false;


        
        private void Start() => _readingBookAudioSource = GetComponent<AudioSource>();


        public void OnGazeEnter() => _tooltipGuiSocket.Display($"TO PICK UP PRESS {_activationButton}");
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
        
    
        public KeyCode ActivationKeyCode() => _activationButton;
        
        public void OnPress()
        {
            ChangeReadingState();
            PlaySound();
            
            if (_isReadingBook)
                StartReadingBook();
            else
                StopReadingBook();
 
        }

        private void ChangeReadingState() => _isReadingBook = !_isReadingBook;
        
        private void PlaySound() => _readingBookAudioSource.Play();

        private void StartReadingBook()
        {
            _tooltipGuiSocket.Deactivate();
            PlayerBehaviour.SetFirstControllerInteract(false);
        }

        private void StopReadingBook()
        {
            _tooltipGuiSocket.Activate();
            PlayerBehaviour.SetFirstControllerInteract(true);
        }

        
        
//        private void OnValidate()
//        {
//            Assert.IsNotNull(_tooltipGuiSocket, "Tooltip socket is null!");
//            Assert.IsNotNull(_imageGuiSocket, "Image gui socket is null!");
//            Assert.IsNotNull(displayImage, "DisplayImage is null!");
//        }
        
    }
}