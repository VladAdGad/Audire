using EventManagement;
using Sandbox.Tests.DoorLockingMechanism.Scripts;
using UnityEngine;

public class ObsticleLockBehaivuor : MonoBehaviour, IPressable
{
	[SerializeField]
	private DoorObsticleBehaviuor _doorObsticleBehaviuor;
	[SerializeField] private KeyCode _activationButton = KeyCode.E;

	public KeyCode ActivationKeyCode() => _activationButton;

	public void OnPress()
	{
		_doorObsticleBehaviuor.UnlockObsticle();
		transform.gameObject.active = false;
	}
}
