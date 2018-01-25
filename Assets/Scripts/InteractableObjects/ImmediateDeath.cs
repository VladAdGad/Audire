using InteractableObjects.Doors;
using Player;
using UnityEngine;

namespace InteractableObjects
{
    public class ImmediateDeath : MonoBehaviour
    {
        [SerializeField] private string _deathText = "";
        [SerializeField] [Range(0, 10)] private float _secondsBeforeDeath = .0f;
        [SerializeField] private PlayerDeathBehaviour _playerDeathBehaviour;
        [SerializeField] private DoorBehaviour _lockDoorBehaviour;
        [SerializeField] private GameObject _sprite;

        private void StartEventImmediateDeath()
        {
            if (_lockDoorBehaviour.IsDoorClosed()) return;
            _sprite.SetActive(true);
            _playerDeathBehaviour.StartProcessOfDeath(_secondsBeforeDeath, _deathText);
            DestroyGameObject();
        }

        private void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}
