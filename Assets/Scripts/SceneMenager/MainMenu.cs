using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMenager
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private bool _quit = false;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        private void OnMouseEnter()
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        private void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        private void OnMouseUp()
        {
            if (_quit)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}