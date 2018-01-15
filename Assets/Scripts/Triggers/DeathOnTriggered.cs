using UnityEngine;

namespace Sandbox.Vlad.Scripts
{
    public class DeathOnTriggered : MonoBehaviour
    {
        [SerializeField] private string _deathText = "";
        private AudioSource _deathRattle;
        private PlayerDeathBehaviour _playerDeathBehaviour;

        private void Start()
        {
            _deathRattle = GetComponent<AudioSource>();
        }

        public void OnTriggerEnter(Collider collider)
        {
            _playerDeathBehaviour = collider.GetComponentInChildren<PlayerDeathBehaviour>();
            if (_playerDeathBehaviour != null)
            {
                _playerDeathBehaviour.ChangeTextOfDeathCause(_deathText);
                _deathRattle.Play();
                StartCoroutine(_playerDeathBehaviour.ProcessOfDeath());
            }
        }
    }
}