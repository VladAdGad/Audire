using UnityEngine;

namespace Sandbox.Amid.Scripts.Triggers
{
    public abstract class ATriggerable : MonoBehaviour
    {
        public abstract void TriggerEnter(Collider collider);
        public abstract void TriggerExit(Collider collider);
    }
}