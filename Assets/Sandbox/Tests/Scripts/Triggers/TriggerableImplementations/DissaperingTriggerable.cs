using UnityEngine;

namespace Sandbox.Amid.Scripts.Triggers.TriggerableImplementations
{
    public class DissaperingTriggerable : ATriggerable
    {
        public override void TriggerEnter(Collider collider) => transform.gameObject.SetActive(false);
        public override void TriggerExit(Collider collider) => transform.gameObject.SetActive(true);
    }
}