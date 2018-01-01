using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractableObjects
{
    public class TwilingLightBiheviour : MonoBehaviour
    {
        public List<GameObject> Lights;
        [SerializeField] private float _minWaitTime;
        [SerializeField] private float _maxWaitTime;
        private bool _state;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(BlinkingLights());
            }
        }

        private IEnumerator BlinkingLights()
        {
            while (true)
            {
                foreach (GameObject light in Lights)
                {
                    light.SetActive(false);
                    yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
                    light.SetActive(true);
                }
            }
        }
    }
}
