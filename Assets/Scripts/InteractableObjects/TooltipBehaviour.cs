using EventManagement;
using UnityEngine;

namespace InteractableObjects
{
    public class TooltipBehaviour : MonoBehaviour, IGazable
    {
        [SerializeField] private GUISkin _skin;
        private bool _isLooking;
                
        public void OnGazeEnter() => _isLooking = true;
        public void OnGazeExit() => _isLooking = false;
        
        private void OnGUI()
        {
            if (_isLooking)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "TO PICK UP PRESS ");
            }
        }
        
        private static Rect TipToInteractReactangle() => new Rect(
            Screen.width / 2 - Screen.width / 6,
            Screen.height / 2 + Screen.height / 4,
            Screen.width / 3f,
            Screen.width / 2 - 2 * Screen.width / 5);
    }
}