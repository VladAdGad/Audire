using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox.Vlad
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BlinkingLightBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _lights;
        [SerializeField] private bool _onStart = false;
        [Range(0f, 1f)] [SerializeField] private float _minWaitTime;
        [Range(0f, 1f)] [SerializeField] private float _maxWaitTime;
        [SerializeField] private Material _material1;
        [SerializeField] private Material _material2;
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            if (_onStart)
            {
                StartCoroutine(BlinkingLights());
            }
        }

        private IEnumerator BlinkingLights()
        {
            while (true)
            {
                _lights.SetActive(false);
                _meshRenderer.material = _material1;
                yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
                _lights.SetActive(true);
                _meshRenderer.material = _material2;
                yield return new WaitForSeconds(Random.Range(_minWaitTime, _maxWaitTime));
            }
        }
    }
}
