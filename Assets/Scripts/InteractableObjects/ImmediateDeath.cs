using InteractableObjects.Doors;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace InteractableObjects
{
    public class ImmediateDeath : MonoBehaviour
    {
        [SerializeField] private string _deathText = "";
        [SerializeField] [Range(0, 10)] private float _secondsBeforeDeath = .0f;
        [SerializeField] private PlayerDeathBehaviour _playerDeathBehaviour;
        [SerializeField] private DoorBehaviour _lockDoorBehaviour;
        [SerializeField] private Image _ghostImage;
        [SerializeField] private AudioSource _screamSoundaudioSource;

        private void StartEventImmediateDeath()
        {
            if(_lockDoorBehaviour.IsDoorOpen())
            {
                _playerDeathBehaviour.StartProcessOfDeath(_deathText, _ghostImage, _screamSoundaudioSource);
                DestroyGameObject();
            }
        }

        private void DestroyGameObject() => Destroy(gameObject);
    }
}
