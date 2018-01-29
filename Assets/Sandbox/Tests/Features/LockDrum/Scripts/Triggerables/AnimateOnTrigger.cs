using Triggers;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts.Triggerables
{
    public class AnimateOnTrigger : APassiveTriggerable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationStateName;
        public override void OnTrigger() => _animator.Play(_animationStateName);
    }
}