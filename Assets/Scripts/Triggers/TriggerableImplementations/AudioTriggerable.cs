﻿using System.Collections;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioTriggerable : ATriggerable
    {
        [SerializeField] private bool _singleTrigger;
        [SerializeField] private int _delay = 0;
        private bool _multiTrigger;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _multiTrigger = !_singleTrigger;
        }

        public override void TriggerEnter(Collider collider)
        {
            if (CanPlaySound)
            {
                StartCoroutine(Wait(_delay));
            }
        }

        private bool CanPlaySound => _singleTrigger || _multiTrigger;

        public override void TriggerExit(Collider collider)
        {
        }

        private IEnumerator Wait(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            _singleTrigger = false;
            _audioSource.Play();
        }
    }
}