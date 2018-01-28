using Player;
using UnityEngine;
using UnityEngine.Audio;

namespace Gui.Menu
{
    public class PauseBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _pauseMenuCanvas;
        [SerializeField] private AudioMixerSnapshot _unpaused;
        [SerializeField] private AudioMixerSnapshot _paused;

        public void PauseOrUnpause()
        {            
            if (!_pauseMenuCanvas.gameObject.activeSelf)
            {
                _pauseMenuCanvas.gameObject.SetActive(!_pauseMenuCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerOnPause(false);
                Time.timeScale = 0;
                _paused.TransitionTo(.01f);
            }
            else
            {
                _pauseMenuCanvas.gameObject.SetActive(!_pauseMenuCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerOnPause(true);
                Time.timeScale = 1;
                _unpaused.TransitionTo(.01f);
            }
        }
    }
}
