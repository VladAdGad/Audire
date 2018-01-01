using System.Collections;
using System.Collections.Generic;
using Sandbox.Amid.Scripts;
using UnityEngine;

public class AudioTriggerable : ATriggerable
{
    public bool singleTrigger = true;
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