using System;
using EventManagement;
using UnityEngine;

namespace Assets.Sandbox.Tests.PianoPlay.Scripts
{
    public class TooltipOnGaze : MonoBehaviour, IGazable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private String _tooltip;
        
        public void OnGazeEnter() => _tooltipGuiSocket.Display(_tooltip);
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
    }
}