using UnityEngine;

namespace Sandbox.Vlad.Scripts
{
	public class DeathOnTriggered : MonoBehaviour
	{
		[SerializeField] private string _deathText = "";
		private PlayerDeathBehaviour _playerDeathBehaviour;

		public void OnTriggerEnter(Collider collider)
		{
			_playerDeathBehaviour = collider.GetComponentInChildren<PlayerDeathBehaviour>();
			if (_playerDeathBehaviour != null)
			{
				_playerDeathBehaviour.ChangeTextOfDeathCause(_deathText);
				StartCoroutine(_playerDeathBehaviour.ProcessOfDeath());
			}
		}
	
	}
}
