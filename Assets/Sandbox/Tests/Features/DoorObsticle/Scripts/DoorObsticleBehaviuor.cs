using EventManagement.Interfaces;
using Gui;
using InteractableObjects.Doors;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.DoorObsticle.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class DoorObsticleBehaviuor : MonoBehaviour, IPressable, IGazable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _onClosedTooltip;
        [SerializeField] private string _onOpenTooltip;
        [SerializeField] private string _whenDoorIsOpenTooltip;
        [SerializeField] private KeyCode _activationKeyCode = KeyCode.E;
        [SerializeField] private KeyLockedDoor _lockedDoor;
        [SerializeField] private bool _isClosed = true;
        [SerializeField] private bool _isBlockedByLock;

        private Animator _obsticleAnimator;
        private bool _animationInProgress;

        private void Start()
        {
            _obsticleAnimator = GetComponent<Animator>();
            SetAnimationInProgress(false);
            if (_isClosed)
                BlockDoor();
        }

        public KeyCode ActivationKeyCode() => _activationKeyCode;
        public void OnPress() => ChangeMovingState();

        public void OnGazeEnter() => _tooltipGuiSocket.Display(ObsticleTooltip());
        private string ObsticleTooltip() => _isBlockedByLock ? _onClosedTooltip : ObsticleTooltipDependingOnDoorState();
        private string ObsticleTooltipDependingOnDoorState() => _lockedDoor.IsDoorOpen() ? _whenDoorIsOpenTooltip : _onOpenTooltip;

        public void OnGazeExit() => _tooltipGuiSocket.Flush();

        public void UnlockObsticle() => _isBlockedByLock = false;

        private void ChangeMovingState()
        {
            if (_animationInProgress || _isBlockedByLock || _lockedDoor.IsDoorOpen()) return;
        
            if (_isClosed)
                StartOpeningRotation();
            else
                StartClosingRotation();
        }

        private void StartOpeningRotation()
        {
            _isClosed = false;
            _obsticleAnimator.Play("ObsticleRotationOpen");
        }

        private void StartClosingRotation()
        {
            _isClosed = true;
            _obsticleAnimator.Play("ObsticleRotationClose");
        }

        private void EnterdAnimationEvent() => SetAnimationInProgress(true);

        private void ExitedAnimationEvent()
        {
            if (_isClosed)
                BlockDoor();
            else
                UnBlockDoor();
            SetAnimationInProgress(false);
        }

        private void BlockDoor() => _lockedDoor.LockDoor();
        private void UnBlockDoor() => _lockedDoor.UnlockDoor();
    
        private void SetAnimationInProgress(bool value) => _animationInProgress = value;
    }
}
