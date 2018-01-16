using UnityEngine;
using UnityEngine.Assertions;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player
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

        public static void PlayerOnPause(bool value)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<FirstPersonController>().GetMouseLook().SetCursorLock(value);
            player.GetComponent<FirstPersonController>().enabled = value;
            player.GetComponent<PlayerEventBehaviour>().enabled = value;
            GameObject firstPersonCharacter = GameObject.FindGameObjectWithTag("MainCamera");
            firstPersonCharacter.GetComponent<AudioListener>().enabled = value;
        }

        public static void PlayerDisable()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<PlayerDeathBehaviour>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<PlayerEventBehaviour>().enabled = false;
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_playerCursorOfCentreMonitor);
            Assert.IsTrue(_cursorSizeX >= 0);
            Assert.IsTrue(_cursorSizeY >= 0);
        }
    }
}
