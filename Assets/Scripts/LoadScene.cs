using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static void LoadNextScene(Scene currentScene)
    {
        string nameCurrentScene = currentScene.name;
        int index = (nameCurrentScene[nameCurrentScene.Length-1] - '0') + 1;
        if (index == 5)
        {
            SceneManager.LoadScene("lvl" + index, LoadSceneMode.Single);
        }
        else
        {
            print("This is the end, my old friend");
        }
    }
}