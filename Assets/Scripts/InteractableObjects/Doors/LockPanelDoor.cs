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
        [SerializeField] private string _codeToUnlockDoor;
        
        private IEnumerable<Button> _buttonsOnLockPanel;
        private string _currentCode = "";

        private void Start()
        {
            _buttonsOnLockPanel = GetButtons(_lockPanel.GetComponentsInChildren<Button>());
        }

        public KeyCode ActivationKeyCode() => _activationButton;

        
        public void OnPress()
        {
            ChangeStateSolveCode();
            
            if (IsCodeGood())
            {
                _doorToOpen.UnlockDoor();
                _soundOnPickUpAudioSource.Play();
                _lockPanel.SetActive(false);
                Destroy(this);
            }

            _currentCode = "";
        }

        private void ChangeStateSolveCode()
        {
            PlayerBehaviour.PlayerInteractWith(_lockPanel.activeSelf);
            _lockPanel.SetActive(!_lockPanel.activeSelf);
        }

        private bool IsCodeGood()
        {
            foreach (Button curButton in _buttonsOnLockPanel)
            {
                _currentCode += curButton.GetComponentInChildren<Text>().text;
            }

            return _currentCode.Equals(_codeToUnlockDoor);
        }

        private static IEnumerable<Button> GetButtons(IEnumerable<Button> b)
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
