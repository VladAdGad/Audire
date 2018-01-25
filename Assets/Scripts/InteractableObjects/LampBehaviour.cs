using EventManagement;
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
        private bool _isLookingLamp = false;

        private void Start()
        {
            _turningLapmSound = GetComponent<AudioSource>();
        }

        public void OnGazeEnter() => _tooltipGuiSocket.Display(!_lights.activeSelf
            ? $"{_toolTipOn} {_activationButton}"
            : $"{_toolTipOff} {_activationButton}");

        public void OnGazeExit() => _tooltipGuiSocket.Flush();

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _lights.SetActive(!_lights.activeSelf);
            PlaySound();
        }

        private void PlaySound() => _turningLapmSound.Play();

        private void OnValidate()
        {
            Assert.IsTrue(_activationButton != KeyCode.None);
        }
    }
}
