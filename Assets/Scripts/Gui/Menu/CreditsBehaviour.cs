using SceneMenager;
using UnityEngine;
using UnityEngine.Audio;

namespace Gui.Menu
{
    public class CreditsBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioMixerSnapshot _unpaused;
        [SerializeField] private AudioMixerSnapshot _credits;

        private void Start() => _credits.TransitionTo(.01f);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) LoadMainLevelAfterCredits();
        }

        private void LoadMainLevelAfterCredits()
        {
            _unpaused.TransitionTo(.01f);
            LoadScene.LoadIndexScene(LoadScene.MainMenuIndex);
        }
    }
}
