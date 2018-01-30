using InteractableObjects.Doors;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts.Unlockables
{
    public class UnlockableDoor : AUnlockable
    {
        [SerializeField]
        private KeyLockedDoor _keyLockedDoor;
        public override void Unlock() => _keyLockedDoor.UnlockDoor();
    }
}