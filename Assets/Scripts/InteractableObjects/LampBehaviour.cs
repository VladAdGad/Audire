using EventManagement.Interfaces;
using Gui;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class LampBehaviour : MonoBehaviour, IPressable, IGazable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _toolTipOn;
        [SerializeField] private string _toolTipOff;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private GameObject _lights;
        
        private AudioSource _turningLapmSound;
        private bool _isLampOn = false;

        private void Start()
        {
            _turningLapmSound = GetComponent<AudioSource>();
            _isLampOn = _lights.activeSelf;
        }

        public void OnGazeEnter() => _tooltipGuiSocket.Display(!_lights.activeSelf
            ? $"{_toolTipOn} {_activationButton}"
            : $"{_toolTipOff} {_activationButton}");

        public void OnGazeExit() => _tooltipGuiSocket.Flush();

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            if (_isLampOn)
                LampOff();
            else
                LampOn();

            ChangeLampState();
            PlaySound();
        }

        private void LampOn()
        {
            _tooltipGuiSocket.Display($"{_toolTipOff} {_activationButton}");
            _lights.SetActive(true);
        }

        private void LampOff()
        {
            _tooltipGuiSocket.Display($"{_toolTipOn} {_activationButton}");
            _lights.SetActive(false);
        }

        private void ChangeLampState() => _isLampOn = !_isLampOn;

        private void PlaySound() => _turningLapmSound.Play();

        private void OnValidate() => Assert.IsTrue(_activationButton != KeyCode.None);
    }
}
