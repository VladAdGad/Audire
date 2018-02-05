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
            if (Input.GetKeyDown(KeyCode.Escape)) Pause();
        }

        public void StartGame() => LoadScene.LoadIndexScene(LoadScene.NextScene);

        public void Credits() => LoadScene.LoadIndexScene(LoadScene.IndexCreditsScene);

        public void Pause() => _pause?.PauseOrUnpause();

        public void Exit() => Application.Quit();
    }
}
