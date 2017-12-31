using InteractableObjects;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace GUInterface
{
    public class MenusBehaviour : MonoBehaviour, IButtonBehaviour
    {
        [SerializeField] private Transform _pauseMenuCanvas;
        [SerializeField] private bool _setPauseMenuActive;
        private readonly int _firstScene = 1;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_setPauseMenuActive)
                    PauseOrUnPause();
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene(_firstScene);
        }

        public void PauseOrUnPause()
        {
            if (_pauseMenuCanvas.gameObject.activeInHierarchy == false)
            {
                _pauseMenuCanvas.gameObject.SetActive(true);
                PlayerBehaviour.SetFirstControllerInteract(false);
                Time.timeScale = 0;
            }
            else
            {
                _pauseMenuCanvas.gameObject.SetActive(false);
                PlayerBehaviour.SetFirstControllerInteract(true);
                Time.timeScale = 1;
            }
        }

        public void Exit()
        {
            Application.Quit();
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_pauseMenuCanvas);
        }
    }
}