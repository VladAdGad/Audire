using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
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
        }

        public static void PlayerDisable()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<PlayerDeathBehaviour>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<PlayerEventBehaviour>().enabled = false;
        }
    }
}
