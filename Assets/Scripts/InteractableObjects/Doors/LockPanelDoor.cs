using System.Collections.Generic;
using EventManagement.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace InteractableObjects.Doors
{
    public class LockPanelDoor : MonoBehaviour, IPressable
    {
        [SerializeField] private GameObject _lockPanel;
        [SerializeField] private LockDoorBehaviour _doorToOpen;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private AudioSource _soundOnPickUpAudioSource;
        [SerializeField] private string _codeToOpenDoor;
        private string _curCode = "";
        private IEnumerable<Button> _buttonsOnLockPanel;
        private bool _kostyl = false;

        private void Start()
        {
            _buttonsOnLockPanel = GetButtons(_lockPanel.GetComponentsInChildren<Button>());
        }

        public KeyCode ActivationKeyCode() => _activationButton;

        
        public void OnPress()
        {
            _kostyl = !_kostyl;
            PlayerBehaviour.PlayerInteractWith(!_kostyl);
            _lockPanel.SetActive(_kostyl);
            
            if (GetStateCurCode())
            {
                _doorToOpen.UnlockDoor();
                _soundOnPickUpAudioSource.Play();
                _lockPanel.SetActive(false);
                Destroy(this);
            }

            _curCode = "";
        }

        private bool GetStateCurCode()
        {
            foreach (Button curButton in _buttonsOnLockPanel)
            {
                _curCode += curButton.GetComponentInChildren<Text>().text;
            }

            return _curCode.Equals(_codeToOpenDoor);
        }
        
        private IEnumerable<Button> GetButtons(IEnumerable<Button> b)
        {
            LinkedList<Button> buttons = new LinkedList<Button>();

            foreach (Button button in b)
            {
                buttons.AddLast(button);
                button.GetComponentInChildren<Text>().text = Random.Range(0, 10).ToString();
            }

            return buttons;
        }
    }
}
