using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenager
{
    public class LoadScene : MonoBehaviour
    {
        private const int NextScene = 1;

        public static IEnumerator LoadNextLevel()
        {
            PlayerBehaviour.PlayerOnPause(false);
            float fadeTime = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextScene);
        }

        public static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
