using System.Collections;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class AudioTriggerable : ATriggerable
    {
        [SerializeField] private int _delay = 0;
        
        private AudioSource _audioSource;

        private void Start() => _audioSource = GetComponent<AudioSource>();

        public override void TriggerEnter(Collider collider) => StartCoroutine(Wait(_delay));

        public void OnTrigger() => StartCoroutine(Wait(_delay));

        public override void TriggerExit(Collider collider)
        {
        }

        private IEnumerator Wait(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            _audioSource.Play();
        }
    }
}
