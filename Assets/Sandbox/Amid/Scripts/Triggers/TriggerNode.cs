using System.Collections.Generic;
using UnityEngine;

namespace Sandbox.Amid.Scripts.Triggers
{
    public class TriggerNode : MonoBehaviour
    {
        [SerializeField] private List<ATriggerable> _triggerables;

        void OnTriggerEnter(Collider other) => _triggerables.ForEach(it => it.TriggerEnter(other));
        void OnTriggerExit(Collider other) => _triggerables.ForEach(it => it.TriggerExit(other));
    }
}