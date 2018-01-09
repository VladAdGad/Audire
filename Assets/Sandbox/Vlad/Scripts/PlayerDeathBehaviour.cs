using SceneMenager;
using UnityEngine;

namespace Sandbox.Vlad.Scripts
{
    public class PlayerDeathBehaviour : MonoBehaviour
    {
        private void Start()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(LoadScene.ReloadScene());
            }
        }
    }
}