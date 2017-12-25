using System;
using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects
{
    public class BookBehaviour : MonoBehaviour, IGazable, IPressable
    {
        
        [SerializeField] private KeyCode _activationButton = KeyCode.F;
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
        
        private static Rect TipToInteractReactangle()
        {
            return new Rect(
                Screen.width / 2 - Screen.width / 6,
                Screen.height / 2 + Screen.height / 4,
                Screen.width / 3,
                Screen.width / 2 - 2 * Screen.width / 5);
        }

        public void OnGazeEnter()
        {
            _isLookingAtFlashLight = true;
        }

        public void OnGazeExit()
        {
            _isLookingAtFlashLight = false;
        }

        public KeyCode ActivationKeyCode()
        {
            return _activationButton;
        }

        public void OnPress()
        {
            throw new NotImplementedException();
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
        }
    }
}