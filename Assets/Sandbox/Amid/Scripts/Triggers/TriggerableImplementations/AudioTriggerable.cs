using UnityEngine;

namespace Sandbox.Amid.Scripts.Triggers.TriggerableImplementations
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioTriggerable : ATriggerable
    {
        [SerializeField] private bool _singleTrigger = true;
        private bool _wasActivated = false;
        
        private AudioSource _audioSource;

        private void Start() => _audioSource = GetComponent<AudioSource>();

        public override void TriggerEnter(Collider collider)
        {
            if (CanPlaySound)
            {
                _wasActivated = true;
                _audioSource.Play();
            }
        }
    
        private bool CanPlaySound => singleTrigger || _wasActivated;

        public override void TriggerExit(Collider collider)
        {
        }

    }
}
