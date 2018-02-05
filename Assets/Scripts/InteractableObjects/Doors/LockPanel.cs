﻿using System.Collections.Generic;
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
        private string _currentCode = "";

        private void Start()
        {
            _doorToOpen = gameObject.GetComponent<PanelLockedDoor>();
            _buttonsOnLockPanel = PreparedButtons();
        }

        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            ChangeStateSolveCode();

            if (IsCodeCorrect())
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

        private bool IsCodeCorrect()
        {
            foreach (Button currentButton in _buttonsOnLockPanel)
            {
                _currentCode += currentButton.GetComponentInChildren<Text>().text;
            }

            return _currentCode.Equals(_codeToUnlockDoor);
        }

        private IEnumerable<Button> PreparedButtons()
        {
            LinkedList<Button> buttons = new LinkedList<Button>();

            foreach (Button button in _lockPanel.GetComponentsInChildren<Button>())
            {
                buttons.AddLast(button);
                button.GetComponentInChildren<Text>().text = Random.Range(0, 10).ToString();
            }

            return buttons;
        }
    }
}
