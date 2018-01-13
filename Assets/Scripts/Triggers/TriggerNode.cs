using System.Collections.Generic;
using UnityEngine;

namespace Triggers
{
    public class TriggerNode : MonoBehaviour
    {
        [SerializeField] private List<ATriggerable> _triggerables;

        private void OnTriggerEnter(Collider other) => _triggerables.ForEach(it => it.TriggerEnter(other));
        private void OnTriggerExit(Collider other) => _triggerables.ForEach(it => it.TriggerExit(other));
    }
}