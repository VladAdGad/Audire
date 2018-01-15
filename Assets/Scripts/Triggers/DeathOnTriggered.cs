using Player;
using UnityEngine;

namespace Triggers
{
    public class DeathOnTriggered : MonoBehaviour
    {
        [SerializeField] private string _deathText = "";
        [SerializeField] [Range(0, 10)] private float _secondsBeforeDeath = .0f;
        private PlayerDeathBehaviour _playerDeathBehaviour;

        public void OnTriggerEnter(Collider collider)
        {
            _playerDeathBehaviour = collider.GetComponentInChildren<PlayerDeathBehaviour>();
            if (_playerDeathBehaviour != null)
            {
                _playerDeathBehaviour.ChangeTextOfDeathCause(_deathText);
                StartProcessOfDeath();
            }
        }

        private void StartProcessOfDeath()
        {
            StartCoroutine(_secondsBeforeDeath != .0f
                ? _playerDeathBehaviour.ProcessOfDeath(_secondsBeforeDeath)
                : _playerDeathBehaviour.ProcessOfDeath());
        }
    }
}
