using Player;
using UnityEngine;

namespace Triggers.TriggerableImplementations
{
    public class DeathTrigger : APassiveTriggerable
    {
        [SerializeField] private string _deathText = "";
        [SerializeField] private float _secondsBeforeDeath = .0f;
        [SerializeField] private PlayerDeathBehaviour _playerDeathBehaviour;

        public void OnTriggerEnter(Collider collider)
        {
            if (_playerDeathBehaviour != null && _playerDeathBehaviour.enabled)
            {
                _playerDeathBehaviour.StartProcessOfDeath(_secondsBeforeDeath, _deathText);
            }
        }

        public override void OnTrigger()
        {
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
