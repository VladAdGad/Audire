using Gui.Interfaces;
using SceneMenager;
using UnityEngine;

namespace Gui.Menu
{
    public class MenuButtonsBehaviour : MonoBehaviour, IButtonBehaviour
    {
        [SerializeField] private PauseBehaviour _pause;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) OnPause();
        }

        public void OnGameStart() => LoadScene.LoadIndexScene(LoadScene.NextScene);

        public void Credits() => LoadScene.LoadIndexScene(LoadScene.IndexCreditsScene);

        public void OnPause() => _pause?.PauseOrUnpause();

        public void OnExit() => Application.Quit();
    }
}
