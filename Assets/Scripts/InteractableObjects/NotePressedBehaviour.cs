using EventManagement;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    [RequireComponent(typeof(AudioSource))]
    public class NotePressedBehaviour : MonoBehaviour, IPressable, IGazable
    {
        [SerializeField] private GUISkin _skin;
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] [TextArea] private string _noteText;
        private AudioSource _readingNoteAudioSource;
        private bool _isReadingNote = false;
        private bool _isLockingNote = false;

        private void Start() => _readingNoteAudioSource = GetComponent<AudioSource>();

        private void OnGUI()
        {
            //Are we reading a note? If so draw it.
            if (_isReadingNote)
            {
                GUI.skin = _skin;
                //Draw the note on screen, Set And Change the GUI Style To Make the Text Appear The Way you Like (Even on an image background like paper)
                GUI.Box(NoteRectangle(), _noteText);
                _isLockingNote = false;
            }

            if (_isLockingNote)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "TO PICK UP PRESS " + _activationButton);
            }
        }

        private static Rect NoteRectangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 24f,
            Screen.width / 3f,
            Screen.height - Screen.height / 18);

        private static Rect TipToInteractReactangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 2 + Screen.height / 4,
            Screen.width / 3f,
            Screen.width / 2 - 2 * Screen.width / 5);

        private void PlaySound() => _readingNoteAudioSource.Play();
        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _isReadingNote = !_isReadingNote;
            PlayerBehaviour.PlayerInteractWith(!_isReadingNote);
            PlaySound();
        }

        public void OnGazeEnter() => _isLockingNote = true;
        public void OnGazeExit() => _isLockingNote = false;

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
            Assert.IsTrue(_activationButton != KeyCode.None);
        }
    }
}