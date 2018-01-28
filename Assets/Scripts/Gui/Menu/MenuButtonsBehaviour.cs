using Gui.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gui.Menu
{
    public class MenuButtonsBehaviour : MonoBehaviour, IButtonBehaviour
    {
        [SerializeField] private CreditsBehaviour _credits;
        [SerializeField] private PauseBehaviour _pause;
        private const int IndexFirstScene = 1;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            Pause();
            Credits();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(IndexFirstScene);
        }

        public void Credits()
        {            
            if (_credits == null) return;
            _credits.StartCredits();
        }

        public void Pause()
        {
            if (_pause == null) return;
            _pause.PauseOrUnpause();
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
