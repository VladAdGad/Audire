using UnityEngine;

namespace EventManagement
{
    public class TooltipOnGaze : MonoBehaviour, IGazable
    {
        [SerializeField] private TooltipGuiSocket _tooltipGuiSocket;
        [SerializeField] private string _tooltip;

        public void OnGazeEnter() => _tooltipGuiSocket.Display(_tooltip);
        public void OnGazeExit() => _tooltipGuiSocket.Flush();
    }
}
