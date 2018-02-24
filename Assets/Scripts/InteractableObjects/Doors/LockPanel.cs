using System.Collections.Generic;
using System.Linq;
using EventManagement.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace InteractableObjects.Doors
{
    public class LockPanel : MonoBehaviour, IPressable
    {
        [SerializeField] private GameObject _lockPanel;
        [SerializeField] private string _codeToUnlockDoor;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private AudioSource _soundOnPickUpAudioSource;

        private PanelLockedDoor _doorToOpen;
        private IEnumerable<Button> _buttonsOnLockPanel;

        private void Start()
        {
            _doorToOpen = gameObject.GetComponent<PanelLockedDoor>();
            Digits()
                .ToList()
                .ForEach(textComponent => textComponent.text = RandomDigit());
        }

        private static string RandomDigit() => Random.Range(0, 10).ToString();

        public KeyCode ActivationKeyCode() => _activationButton;
        public void OnPress()
        {
            PlayerBehaviour.PlayerInteractWith(_lockPanel.activeSelf);
            _lockPanel.SetActive(!_lockPanel.activeSelf);

            if (IsCodeCorrect())
            {
                _doorToOpen.UnlockDoor();
                _soundOnPickUpAudioSource.Play();
                _lockPanel.SetActive(false);
                Destroy(this);
            }
        }

        private bool IsCodeCorrect() => Digits()
            .Select(child => child.text)
            .Aggregate((first, second) => first + second)
            .Equals(_codeToUnlockDoor);

        private IEnumerable<Text> Digits() => _lockPanel
            .GetComponentsInChildren<Button>()
            .Select(button => button.GetComponentInChildren<Text>());
    }
}
