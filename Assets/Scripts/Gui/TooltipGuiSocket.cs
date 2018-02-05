﻿using Gui.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class TooltipGuiSocket : MonoBehaviour, IGuiSocket
    {
        [SerializeField] private Text _socketText;

        private const string Empty = "";

        public void Display(string text) => _socketText.text = text;
        public void Flush() => _socketText.text = Empty;

        public void OnActivate() => _socketText.enabled = true;
        public void OnDeactivate() => _socketText.enabled = false;
    }
}
