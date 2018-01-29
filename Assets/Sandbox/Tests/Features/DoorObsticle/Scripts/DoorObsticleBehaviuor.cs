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
        
        [SerializeField] private KeyCode activationKeyCode = KeyCode.E;

        [SerializeField] private KeyLockedDoor _lockedDoor;
        [SerializeField] private bool _closed = true;
        [SerializeField]  private bool _blockedByLock;

        private Animator _obsticleAnimator;
        private bool _animationInProgress;

        private void Start()
        {
            _obsticleAnimator = GetComponent<Animator>();
            SetAnimationInProgress(false);
            if (_closed)
                BlockDoor();
        }

        public KeyCode ActivationKeyCode() => activationKeyCode;
        public void OnPress() => ChangeMovingState();

        public void OnGazeEnter() => _tooltipGuiSocket.Display(_blockedByLock ? _onClosedTooltip : (_lockedDoor.IdDoorOpen() ? _whenDoorIsOpenTooltip : _onOpenTooltip));
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
        
        private void ChangeMovingState()
        {
            if (_animationInProgress || _blockedByLock || _lockedDoor.IdDoorOpen()) return;
        
            if (_closed)
                StartOpeningRotation();
            else
                StartClosingRotation();
        }


        private void StartOpeningRotation()
        {
            _closed = false;
            _obsticleAnimator.Play("ObsticleRotationOpen");
        }

        private void StartClosingRotation()
        {
            _closed = true;
            _obsticleAnimator.Play("ObsticleRotationClose");
        }

        private void EnterdAnimationEvent() => SetAnimationInProgress(true);

        private void ExitedAnimationEvent()
        {
            if (_closed)
                BlockDoor();
            else
                UnBlockDoor();
            SetAnimationInProgress(false);
        }

        private void BlockDoor() => _lockedDoor.LockDoor();
        private void UnBlockDoor() => _lockedDoor.UnlockDoor();

        public void UnlockObsticle()
        {
            _blockedByLock = false;
        }
    
        private void SetAnimationInProgress(bool value) => _animationInProgress = value;
    }
}
