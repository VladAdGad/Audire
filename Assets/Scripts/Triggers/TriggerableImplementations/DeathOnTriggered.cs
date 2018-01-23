using Player;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DeathOnTriggered : MonoBehaviour
    {
        [SerializeField] private string _deathText = "";
        [SerializeField] [Range(0, 10)] private float _secondsBeforeDeath = .0f;
        private PlayerDeathBehaviour _playerDeathBehaviour;

        public void OnTriggerEnter(Collider collider)
        {
            _playerDeathBehaviour = collider.GetComponentInChildren<PlayerDeathBehaviour>();
            if (_playerDeathBehaviour != null && _playerDeathBehaviour.enabled)
            {
                _playerDeathBehaviour.StartProcessOfDeath(_secondsBeforeDeath, _deathText);
            }
        }

        private void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}
