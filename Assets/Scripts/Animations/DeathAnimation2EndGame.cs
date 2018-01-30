using SceneMenager;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Animations
{
    public class DeathAnimation2EndGame : MonoBehaviour
    {
        public void Credits()
        {
            gameObject.GetComponentInParent<FirstPersonController>().GetMouseLook().SetCursorLock(false);
            LoadScene.LoadIndexScene(LoadScene.IndexCreditsScene);
        }
    }
}
