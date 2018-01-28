using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Gui.Menu
{
    public class CreditsBehaviour: MonoBehaviour
    {
        [SerializeField] private GameObject _creditsCanvas;
        [SerializeField] private AudioMixerSnapshot _unpaused;
        [SerializeField] private AudioMixerSnapshot _credits;
        private const int MainMenuIndex = 0;

        public void StartCredits()
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
        
        public void LoadMainLevelAfterCredits()
        {
            SceneManager.LoadScene(MainMenuIndex);
        }
    
    }
}
