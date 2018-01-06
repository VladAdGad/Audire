using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox.Vlad
{
    public class BlinkingLightBehaviour : MonoBehaviour
    {
        [SerializeField] private bool _onStart = false;
        [Range(0f, 1f)] [SerializeField] private float _minWaitTime;
        [Range(0f, 1f)] [SerializeField] private float _maxWaitTime;
        public List<GameObject> Lights;

        private void Start()
        {
            if (_onStart)
            {
                StartCoroutine(BlinkingLights());
            }
        }

        private void Update()
        {
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
