using Assets.Sandbox.Tests.Features.LockDrum.Scripts.Unlockables;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.DoorObsticle.Scripts
{
    public class ObsticleClamp : AUnlockable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _unlockAnimationName;
        [SerializeField] private DoorObsticleBehaviuor _doorObsticle;
        public override void Unlock() => _animator.Play(_unlockAnimationName);

        public void UnlockObsticle() => _doorObsticle.UnlockObsticle();
    }
}