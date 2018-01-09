using System.Collections;
using InteractableObjects;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenager
{
    public class LoadScene : MonoBehaviour
    {
        private const int NextScene = 1;
        private const int WaitBeforeLoad = 5;

        public static IEnumerator ChangeLevel()
        {
            PlayerBehaviour.SetFirstControllerInteract(false);
            float fadeTime = GameObject.Find("FPSController").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextScene);
        }

        public static IEnumerator ReloadScene()
        {
            PlayerBehaviour.SetFirstControllerInteract(false);
            float fadeTime = GameObject.Find("FPSController").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            yield return new WaitForSeconds(WaitBeforeLoad);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}