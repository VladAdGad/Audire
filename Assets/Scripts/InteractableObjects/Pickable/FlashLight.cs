using EventManagement.Interfaces;
using Gui;
using InteractableObjects.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Pickable
{
    public class FlashLight : MonoBehaviour, IGazable, IPressable, IHowToolTipWithObject
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _toolTipToPickUp;
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] private GameObject _playerSpotLight;
        [SerializeField] private Transform _flashlightTipCanvas;

        public void OnGazeEnter() => _tooltipGuiSocket.Display($"{_toolTipToPickUp} {_activationButton}");
        public void OnGazeExit() => _tooltipGuiSocket.Flush();

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _playerSpotLight.SetActive(true);
            HotToInteractToolTip();
        }

        public void HotToInteractToolTip()
        {
            if (!_flashlightTipCanvas.gameObject.activeSelf)
            {
                _flashlightTipCanvas.gameObject.SetActive(!_flashlightTipCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerInteractWith(false);
                Time.timeScale = 0;
            }
            else
            {
                _flashlightTipCanvas.gameObject.SetActive(!_flashlightTipCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerInteractWith(true);
                Time.timeScale = 1;
                Destroy(gameObject);
                Destroy(_flashlightTipCanvas.gameObject);
            }
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_playerSpotLight);
        }
    }
}
