using System;
using System.Collections.Generic;
using System.Linq;
using Gui.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts
{
    public class DrumLockGuiSocket : MonoBehaviour, IGuiSocket
    {
        private static readonly IDictionary<string, string> NextNumber = NumbersWith(x => x + 1);
        private static readonly IDictionary<string, string> PreviousNumber = NumbersWith(x => x + 9);
        private static readonly IDictionary<PointerEventData.InputButton, Func<string, string>> DrumRollingMap = CreateDrumRollingMap();

        [SerializeField] private List<DrumButtonClickHandler> _buttons;

        private DrumLock _drumLock;

        private static IDictionary<string, string> NumbersWith(Func<int, int> func) =>
            Enumerable
                .Range(0, 10)
                .ToDictionary(x => x.ToString(), x => (func(x) % 10).ToString());


        private static IDictionary<PointerEventData.InputButton, Func<string, string>> CreateDrumRollingMap()
        {
            IDictionary<PointerEventData.InputButton, Func<string, string>> map = new Dictionary<PointerEventData.InputButton, Func<string, string>>();
            map.Add(PointerEventData.InputButton.Left, number => NextNumber[number]);
            map.Add(PointerEventData.InputButton.Right, number => PreviousNumber[number]);

            return map;
        }

        public void Display(DrumLock drumLock)
        {
            _drumLock = drumLock;
            ActivateButtons();
            ApplyCodeOnButtons(drumLock.GetCurrentCode());
        }

        private void ActivateButtons() => _buttons.ForEach(button => button.ActivateButton());
        private void ApplyCodeOnButtons(LockCode lockCode) => _buttons.ForEach(button => button.SetButtonText(lockCode.GetCodeAt(button.GetButtonIndex())));

        public void Flush()
        {
            _drumLock = null;
            DeactivateButtons();
        }

        private void DeactivateButtons() => _buttons.ForEach(button => button.DeactivateButton());

        public void OnButtonClick(PointerEventData eventData, int buttonIndex, Text buttonText)
        {
            string code = DrumRollingMap[eventData.button].Invoke(buttonText.text);
            LockCode lockCode = _drumLock.GetCurrentCode().ChangeSequenceMember(buttonIndex, code);
            _drumLock.OnCodeChanged(lockCode);
            buttonText.text = code;
        }


        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);


        private void Start() => InitialiseButtons();
        private void InitialiseButtons()
        {
            _buttons
                .ForEach(button => button.SetDrumLockGuiSocket(this));

            Enumerable
                .Range(0, _buttons.Count)
                .ToList()
                .ForEach(index => _buttons[index].SetButtonIndex(index));
        }
    }
}