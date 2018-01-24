using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private static GameObject _player;
        private static bool _stateInteract;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public static void PlayerInteractWith(bool stateInteratcWith)
        {
            _stateInteract = !stateInteratcWith;
            _player.GetComponent<FirstPersonController>().GetMouseLook().SetCursorLock(stateInteratcWith);
            _player.GetComponent<FirstPersonController>().enabled = stateInteratcWith;
        }

        public static void PlayerOnPause(bool statePause)
        {
            if (!_stateInteract)
            {
                PlayerInteractWith(statePause);
            }
            _player.GetComponent<PlayerEventBehaviour>().enabled = statePause;
        }

        public static void PlayerDisable()
        {
            _player.GetComponentInChildren<PlayerDeathBehaviour>().enabled = false;
            _player.GetComponent<FirstPersonController>().enabled = false;
            _player.GetComponent<PlayerEventBehaviour>().enabled = false;
        }
    }
}
