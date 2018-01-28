using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gui.Menu
{
    public class CreditsBehaviour : MonoBehaviour
    {
        private const int MainMenuIndex = 0;

        public void LoadMainLevelAfterCredits()
        {
            SceneManager.LoadScene(MainMenuIndex);
        }
    
    }
}
