﻿using EventManagement;
using EventManagement.Interfaces;
using Gui;
using UnityEngine;

namespace InteractableObjects
{
    public class TooltipOnGaze : MonoBehaviour, IGazable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _tooltip;

        public void OnGazeEnter() => _tooltipGuiSocket.Display(_tooltip);
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
    }
}
