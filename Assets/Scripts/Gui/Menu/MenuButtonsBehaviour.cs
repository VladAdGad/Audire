using Gui.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Gui.Menu
{
    public class MenuButtonsBehaviour : MonoBehaviour, IButtonBehaviour
    {
        [SerializeField] private GameObject _creditsCanvas;
        [SerializeField] private Transform _pauseMenuCanvas;
        [SerializeField] private AudioMixerSnapshot _unpaused;
        [SerializeField] private AudioMixerSnapshot _paused;
        [SerializeField] private AudioMixerSnapshot _credits;
        private const int IndexFirstScene = 1;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            PauseOrUnPause();
            StartCredits();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(IndexFirstScene);
        }

        private void StartCredits()
        {
            _creditsCanvas.SetActive(!_creditsCanvas.activeSelf);
            if (_creditsCanvas.activeSelf)
            {
                _credits.TransitionTo(.01f);
            }
            else
            {
                _unpaused.TransitionTo(.01f);
            }
        }

        public void PauseOrUnPause()
        {
            if (_pauseMenuCanvas == null) return;
            
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
