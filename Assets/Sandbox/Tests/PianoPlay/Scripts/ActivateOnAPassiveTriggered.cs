using UnityEngine;

namespace Assets.Sandbox.Tests.PianoPlay.Scripts
{
    public class ActivateOnAPassiveTriggered : APassiveTriggerable
    {
        public override void OnTrigger() => gameObject.SetActive(true);
    }
}