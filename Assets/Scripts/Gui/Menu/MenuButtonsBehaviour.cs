using Gui.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Gui.Menu
{
    public class MenuButtonsBehaviour : MonoBehaviour, IButtonBehaviour
    {
        [SerializeField] private Transform _pauseMenuCanvas;
        [SerializeField] private AudioMixerSnapshot _unpaused;
        [SerializeField] private AudioMixerSnapshot _paused;
        private const int IndexFirstScene = 1;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseOrUnPause();
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene(IndexFirstScene);
        }

        public void StartCredits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void PauseOrUnPause()
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

        public void Exit()
        {
            Application.Quit();
        }
    }
}
