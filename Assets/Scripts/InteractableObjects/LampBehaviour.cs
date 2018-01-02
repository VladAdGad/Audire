using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class LampBehaviour : MonoBehaviour, IPressable, IGazable
    {
        [SerializeField] private GUISkin _skin;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        private AudioSource _turningLapmSound;
        private Light _light;
        private bool _isLampState = false;
        private bool _isLookingLamp = false;

        private void Start()
        {
            _light = gameObject.GetComponentInChildren<Light>();
            _turningLapmSound = GetComponent<AudioSource>();
        }

        private void OnGUI()
        {
            if (_isLookingLamp)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "TO TURN ON/OFF PRESS " + _activationButton);
            }
        }

        private static Rect TipToInteractReactangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 2 + Screen.height / 4,
            Screen.width / 3f,
            Screen.width / 2 - 2 * Screen.width / 5);

        public KeyCode ActivationKeyCode() => _activationButton;

        private void PlaySound() => _turningLapmSound.Play();

        public void OnPress()
        {
            _isLampState = !_isLampState;
            _light.enabled  = _isLampState;
            PlaySound();
        }

        public void OnGazeEnter() => _isLookingLamp = true;
        public void OnGazeExit() => _isLookingLamp = false;

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
            Assert.IsTrue(_activationButton != KeyCode.None);
        }
    }
}