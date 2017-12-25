using UnityEngine;
using UnityEngine.Assertions;
using UnityStandardAssets.Characters.FirstPerson;

namespace InteractableObjects
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private Texture _playerCursorOfCentreMonitor;
        [SerializeField] private int _cursorSizeX = 5;
        [SerializeField] private int _cursorSizeY = 5;

        private void OnGUI()
        {
            GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, _cursorSizeX, _cursorSizeY),
                _playerCursorOfCentreMonitor);
        }
        
        public static void SetFirstControllerInteract(bool value)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<FirstPersonController>().GetMouseLook().SetCursorLock(value);
            player.GetComponent<FirstPersonController>().enabled = value;
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_playerCursorOfCentreMonitor);
            Assert.IsTrue(_cursorSizeX >= 0);
            Assert.IsTrue(_cursorSizeY >= 0);
        }
    }
}