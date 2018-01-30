using Assets.Sandbox.Tests.Features.LockDrum.Scripts.Lock;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts.GUI
{
    public class DrumButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _pauseSocket;
        private DrumLock _drumLock;
        private int _drumIndex;
        private Text _buttonText;

        private void Awake() => _buttonText = GetComponentInChildren<Text>();
        public void SetButtonIndex(int index) => _drumIndex = index;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsGamePaused()) return;
            ChangeDrumNumber(eventData);
        }
        private bool IsGamePaused() => _pauseSocket.activeSelf;
        
        private void ChangeDrumNumber(PointerEventData eventData)
        {
            string newDrumNumber = NumberRollingUtility.RollNextNumber(eventData.button, _buttonText.text);
            _buttonText.text = newDrumNumber;
            _drumLock.DrumChanged(_drumIndex, newDrumNumber);
        }

        public void ActivateButtonWith(DrumLock drumLock)
        {
            gameObject.SetActive(true);
            _drumLock = drumLock;
            _buttonText.text = drumLock.GetCurrentCodeAt(_drumIndex);
        }
        
        public void DeactivateButton()
        {
            gameObject.SetActive(false);
            _drumLock = null;
        }
    }
}