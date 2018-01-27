using EventManagement.Interfaces;
using Gui;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class DisplayImageOnPressed : MonoBehaviour, IGazable, IPressable
    {
        [Header("Gui Sockets")] [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private ImageGuiSocket _imageSocket;
        [Space(10)] [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private AudioSource _readingBookAudioSource;

        [SerializeField] private Sprite _displayImage;

        private bool ReadingBook { get; set; } = false;

        public void OnGazeEnter() => _tooltipGuiSocket.Display($"To read press {_activationButton}");
        public void OnGazeExit() => _tooltipGuiSocket.Flush();

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            if (ReadingBook)
                StopDisplaying();
            else
                StartDisplaying();

            ChangeReadingState();
            PlaySound();
        }

        private void ChangeReadingState() => ReadingBook = !ReadingBook;

        private void PlaySound() => _readingBookAudioSource.Play();

        private void StartDisplaying()
        {
            _tooltipGuiSocket.Display($"To exit press {_activationButton}");
            _imageSocket.Display(_displayImage);
            PlayerBehaviour.PlayerInteractWith(false);
        }

        protected virtual void StopDisplaying()
        {
            OnGazeEnter();
            _imageSocket.Flush();
            PlayerBehaviour.PlayerInteractWith(true);
        }
    }
}
