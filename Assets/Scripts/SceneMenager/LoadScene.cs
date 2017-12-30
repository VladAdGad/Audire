using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenager
{
    public class LoadScene : MonoBehaviour
    {
        public static IEnumerator ChangeLevel()
        {
            float fadeTime = GameObject.Find("FPSController").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}