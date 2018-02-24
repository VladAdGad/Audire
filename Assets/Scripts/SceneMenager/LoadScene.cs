using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenager
{
    public class LoadScene : MonoBehaviour
    {
        public static int NextScene { get; } = 1;
        public static int MainMenuIndex { get; } = 0;
        public static int IndexCreditsScene { get; } = 4;

        public static IEnumerator LoadNextLevel()
        {
            PlayerBehaviour.PlayerOnPause(false);
            float fadeTime = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextScene);
        }

        public static void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public static void LoadIndexScene(int indexScene) => SceneManager.LoadScene(indexScene);
    }
}
