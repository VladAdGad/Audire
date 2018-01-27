using EventManagement;
using EventManagement.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class FlashLightBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private Transform _flashlightTipCanvas;
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
        [SerializeField] private GameObject _playerSpotLight;
        [SerializeField] private GUISkin _skin;
        private bool _isLookingAtFlashLight;

        private void OnGUI()
        {
            if (_isLookingAtFlashLight)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "TO PICK UP PRESS " + _activationButton);
            }
        }

        private static Rect TipToInteractReactangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 2 + Screen.height / 4,
            Screen.width / 3f,
            Screen.width / 2 - 2 * Screen.width / 5);

        public void OnGazeEnter() => _isLookingAtFlashLight = true;
        public void OnGazeExit() => _isLookingAtFlashLight = false;
        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _playerSpotLight.SetActive(true);
            Destroy(gameObject);

            FlashlightTip();

        }



        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
            Assert.IsNotNull(_playerSpotLight);
        }

        public void FlashlightTip()
        {
            if (!_flashlightTipCanvas.gameObject.activeSelf)
            {
                _flashlightTipCanvas.gameObject.SetActive(!_flashlightTipCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerOnPause(false);
                Time.timeScale = 0;
            }
            else
            {
                _flashlightTipCanvas.gameObject.SetActive(!_flashlightTipCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerOnPause(true);
                Time.timeScale = 1;
            }
        }
    }
}