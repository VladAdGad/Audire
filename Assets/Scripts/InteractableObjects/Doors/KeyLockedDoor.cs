using UnityEngine;
using UnityEngine.Assertions;

namespace InteractableObjects.Doors
{
    public class KeyLockedDoor : DoorBehaviour
    {
        [SerializeField] private string _lockedStateTooltip;

        private bool _doorLocked = true;

        public override void OnGazeEnter() => TooltipGuiSocket.Display(
            _doorLocked
                ? $"{_lockedStateTooltip}"
                : DoorClosed
                    ? $"{ToolTipOpenText} {ActivationButton}"
                    : $"{ToolTipCloseText} {ActivationButton}");

        public void UnlockDoor() => _doorLocked = false;
        public void LockDoor() => _doorLocked = true;
        public bool IdDoorOpen() => !DoorClosed;

        public override void OnPress()
        {
            if (_doorLocked) return;
            base.OnPress();
        }

        private void OnValidate() =>
            Assert.AreNotEqual(ActivationButton, KeyCode.None, "Door Actiation button must not be null.");
    }
}
