using Player;
using UnityEngine;
using UnityEngine.Audio;

namespace Gui.Menu
{
    public class PauseBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioMixerSnapshot _unpaused;
        [SerializeField] private AudioMixerSnapshot _paused;

        public void PauseOrUnpause()
        {            
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                PlayerBehaviour.PlayerOnPause(true);
                Time.timeScale = 1;
                _unpaused.TransitionTo(.01f);
            }
            else
            {
                gameObject.SetActive(true);
                PlayerBehaviour.PlayerOnPause(false);
                Time.timeScale = 0;
                _paused.TransitionTo(.01f);
            }
        }
    }
}
