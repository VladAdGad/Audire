using InteractableObjects;
using Triggers;
using UnityEngine;

public class AppearingWords : DisplayImageOnPressed
{

    [SerializeField] private APassiveTriggerable _triggerOnSuccess1;
    [SerializeField] private APassiveTriggerable _triggerOnSuccess2;
    [SerializeField] private APassiveTriggerable _triggerOnSuccess3;
    [SerializeField] private APassiveTriggerable _triggerOnSuccess4;


        protected override void StopDisplaying()
        {
        _triggerOnSuccess1.OnTrigger();
            _triggerOnSuccess2.OnTrigger();
            _triggerOnSuccess3.OnTrigger();
            _triggerOnSuccess4.OnTrigger();
        }
}

