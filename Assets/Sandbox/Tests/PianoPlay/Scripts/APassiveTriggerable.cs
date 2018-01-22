using Triggers;
using UnityEngine;

namespace Assets.Sandbox.Tests.PianoPlay.Scripts
{
    public abstract class APassiveTriggerable : MonoBehaviour
    {
       public abstract void OnTrigger();
    }
}