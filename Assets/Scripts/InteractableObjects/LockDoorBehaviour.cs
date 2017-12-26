using System;
using System.Collections;
using System.Collections.Generic;
using EventManagement;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace InteractableObjects
{
    [RequireComponent(typeof(GameObject))]
    public class LockDoorBehaviour : MonoBehaviour, IGazable, IPressable
    {
        [SerializeField] private GameObject _lockPanel;
        [SerializeField] private GUISkin _skin;
        [SerializeField] private KeyCode _activationButton = KeyCode.E;
        [SerializeField] private string _codeToOpenDoor;
        private string _curCode = "";
        private bool _isCodeMatch = false;
        private bool _isOpeningDoor = false;
        private bool _isLookingAtDoor = false;
        private bool _stateOfDoor = false;
        private Animator _animator;
        private AudioSource _openingDoorAudioSource;
        private IEnumerable<Button> _curButtons;
        private IEnumerator _loadNextScene;

        private void Start()
        {
            _openingDoorAudioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
            _curButtons = GetButtons(_lockPanel.GetComponentsInChildren<Button>());
        }

        private void OnGUI()
        {
            if (_isLookingAtDoor)
            {
                GUI.skin = _skin;
                GUI.TextArea(TipToInteractReactangle(), "FOR OPEN PRESS " + _activationButton);
            }
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

        private static Rect TipToInteractReactangle()
        {
            return new Rect(
                Screen.width / 2 - Screen.width / 6,
                Screen.height / 2 + Screen.height / 4,
                Screen.width / 3f,
                Screen.width / 2 - 2 * Screen.width / 5);
        }

        public void OnGazeEnter() => _isLookingAtDoor = true;
        public void OnGazeExit() => _isLookingAtDoor = false;
        public KeyCode ActivationKeyCode() => _activationButton;

        public void OnPress()
        {
            _isOpeningDoor = !_isOpeningDoor;
            _isCodeMatch = GetStateCurCode();
            
            if (_isCodeMatch)
            {
                _stateOfDoor = !_stateOfDoor;
                _animator.SetBool("open", _stateOfDoor);
                PlaySound();
                _lockPanel.SetActive(false);
                PlayerBehaviour.SetFirstControllerInteract(true);
                Wait(3, () => LoadScene.LoadNextScene(SceneManager.GetActiveScene()));
            }
            else
            {
                _lockPanel.SetActive(_isOpeningDoor);
                PlayerBehaviour.SetFirstControllerInteract(!_isOpeningDoor);
            }
            
            _curCode = "";
        }

        private void PlaySound()
        {
            if (!_openingDoorAudioSource.isPlaying)
            {
                _openingDoorAudioSource.Play();
            }
        }

        private bool GetStateCurCode()
        {
            foreach (Button curButton in _curButtons)
            {
                _curCode += curButton.GetComponentInChildren<Text>().text;
            }
            
            return _curCode.Equals(_codeToOpenDoor);
        }

        private void Wait(float seconds, Action action) => StartCoroutine(_wait(seconds, action));

        private static IEnumerator _wait(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback();
        }

        private void OnValidate()
        {
            Assert.IsNotNull(_skin);
            Assert.AreNotEqual(_activationButton, KeyCode.None);
        }
    }
}
