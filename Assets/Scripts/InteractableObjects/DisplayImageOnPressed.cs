using EventManagement;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class DisplayImageOnPressed : MonoBehaviour, IGazable, IPressable
    {
        [Header("Gui Sockets")] [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private ImageGuiSocket _imageGuiSocket;
        [Space(10)] [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] private AudioSource _readingBookAudioSource;

        [SerializeField] private Sprite _displayImage;

        private bool ReadingBook { get; set; } = false;

        public void OnGazeEnter() => _tooltipGuiSocket.Display($"To read press {_activationButton}");
        public void OnGazeExit() => _tooltipGuiSocket.Flush();

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            if (ReadingBook)
                StopReadingBook();
            else
                StartReadingBook();

            ChangeReadingState();
            PlaySound();
        }

        private void ChangeReadingState() => ReadingBook = !ReadingBook;

        private void PlaySound() => _readingBookAudioSource.Play();

        private void StartReadingBook()
        {
            _tooltipGuiSocket.Display($"To exit press {_activationButton}");
            _imageGuiSocket.Display(_displayImage);
            PlayerBehaviour.SetFirstControllerInteract(false);
        }

        private void StopReadingBook()
        {
            OnGazeEnter();
            _imageGuiSocket.Flush();
            PlayerBehaviour.SetFirstControllerInteract(true);
        }


        private void OnValidate()
        {
            Assert.IsNotNull(_tooltipGuiSocket, "Tooltip socket is null!");
            Assert.IsNotNull(_imageGuiSocket, "Image gui socket is null!");
            Assert.IsNotNull(_displayImage, "DisplayImage is null!");
        }
    }
}
