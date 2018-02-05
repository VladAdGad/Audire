using System.Collections.Generic;
using System.Linq;
using Assets.Sandbox.Tests.Features.LockDrum.Scripts.Lock;
using Gui.Interfaces;
using UnityEngine;

namespace Assets.Sandbox.Tests.Features.LockDrum.Scripts.GUI
{
    public class DrumLockGuiSocket : MonoBehaviour, IGuiSocket
    {
        [SerializeField] private List<DrumButtonClickHandler> _buttons;

        public void Display(DrumLock drumLock) => _buttons.ForEach(button => button.ActivateButtonWith(drumLock));
        public void Flush() => _buttons.ForEach(button => button.DeactivateButton());

        public void OnActivate() => gameObject.SetActive(true);
        public void OnDeactivate() => gameObject.SetActive(false);

        private void Start() => ApplyButtonIndexNumbers();
        private void ApplyButtonIndexNumbers() =>
            Enumerable
                .Range(0, _buttons.Count)
                .ToList()
                .ForEach(index => _buttons[index].SetButtonIndex(index));
    }
}