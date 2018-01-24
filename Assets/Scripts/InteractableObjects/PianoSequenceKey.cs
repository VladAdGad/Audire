using EventManagement;
using Triggers.TriggerableImplementations;
using UnityEngine;

namespace InteractableObjects
{
    public class PianoSequenceKey : MonoBehaviour, IPressable
    {
        [SerializeField] private PianoKeySequenceTriggerer _pianoKeySequenceTriggerer;
        [SerializeField] private KeyCode _keyToListen;
        [SerializeField] private AudioSource _keySound;

        public KeyCode ActivationKeyCode() => _keyToListen;

        public void OnPress()
        {
            _keySound.Play();
            _pianoKeySequenceTriggerer.OnPianoKeyPressed(_keyToListen);
        }
    }
}
