using System.Collections;
using EventManagement;
using InteractableObjects;
using UnityEngine;
using Utilities;

[RequireComponent(typeof(Animator))]
public class DoorObsticleBehaviuor : MonoBehaviour, IPressable
{
    [SerializeField] private KeyCode activationKeyCode = KeyCode.E;

    [SerializeField] private DoorBehaviour _doorBehaviour;
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

    private void ChangeMovingState()
    {
        if (_animationInProgress || _blockedByLock) return;
        
        if (_closed)
            startOpeningRotation();
        else
            startClosingRotation();
    }


    private void startOpeningRotation()
    {
        _closed = false;
        _obsticleAnimator.Play("ObsticleRotationOpen");
    }

    private void startClosingRotation()
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

    private void BlockDoor() => _doorBehaviour.gameObject.active = false;
    private void UnBlockDoor() => _doorBehaviour.gameObject.active = true;

    public void UnlockObsticle()
    {
        _blockedByLock = false;
    }
    
    private void SetAnimationInProgress(bool value) => _animationInProgress = value;
}