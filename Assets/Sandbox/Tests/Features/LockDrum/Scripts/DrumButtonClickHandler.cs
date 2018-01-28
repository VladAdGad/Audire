using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts
{
    public class DrumButtonClickHandler : MonoBehaviour, IPointerClickHandler
    {
        private DrumLockGuiSocket _drumLockGuiSocket;
        private int _buttonIndex;
        private Text _buttonText;

        private void Awake() => _buttonText = GetComponentInChildren<Text>();

        public void OnPointerClick(PointerEventData eventData) => _drumLockGuiSocket.OnButtonClick(eventData, _buttonIndex, _buttonText);
        
        public void SetButtonText(string text) => _buttonText.text = text;
        public void SetButtonIndex(int index) => _buttonIndex = index;
        public void SetDrumLockGuiSocket(DrumLockGuiSocket socket) => _drumLockGuiSocket = socket;
        public int GetButtonIndex() => _buttonIndex;

        public void ActivateButton() => gameObject.SetActive(true);
        public void DeactivateButton() => gameObject.SetActive(false);
    }
}