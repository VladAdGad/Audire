using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GUInterface
{
    public class MenusBehaviour : MonoBehaviour, IButtonBehaviour
    {
        [SerializeField] private Transform _pauseMenuCanvas;
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

        public void PauseOrUnPause()
        {
            if (!_pauseMenuCanvas.gameObject.activeSelf)
            {
                _pauseMenuCanvas.gameObject.SetActive(!_pauseMenuCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerOnPause(false);
                Time.timeScale = 0;
            }
            else
            {
                _pauseMenuCanvas.gameObject.SetActive(!_pauseMenuCanvas.gameObject.activeSelf);
                PlayerBehaviour.PlayerOnPause(true);
                Time.timeScale = 1;
            }
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
