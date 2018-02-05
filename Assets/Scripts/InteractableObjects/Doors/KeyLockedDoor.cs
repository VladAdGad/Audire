using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Doors
{
    public class KeyLockedDoor : DoorBehaviour
    {
        [SerializeField] private string _lockedStateTooltip;

        private bool _doorLocked = true;

        public override void OnGazeEnter() => TooltipGuiSocket.Display(LockedDoorTooltip());

        private string LockedDoorTooltip() => _doorLocked ? $"{_lockedStateTooltip}" : DoorTooltip();

        private string DoorTooltip() => IsDoorClosed ? $"{ToolTipOpenText} {ActivationButton}" : $"{ToolTipCloseText} {ActivationButton}";

        public void UnlockDoor() => _doorLocked = false;
        public void LockDoor() => _doorLocked = true;
        public bool IdDoorOpen() => !IsDoorClosed;

        public override void OnPress()
        {
            if (!_doorLocked) base.OnPress();
        }

        private void OnValidate() => Assert.AreNotEqual(ActivationButton, KeyCode.None, "Door Actiation button must not be null.");
    }
}
