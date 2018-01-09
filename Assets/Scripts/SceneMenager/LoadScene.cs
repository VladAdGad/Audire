using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenager
{
    public class LoadScene : MonoBehaviour
    {
        private const int NextScene = 1;

        public static IEnumerator ChangeLevel()
        {
            float fadeTime = GameObject.Find("FPSController").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextScene);
        }
    }
}
