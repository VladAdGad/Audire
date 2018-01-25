using UnityEngine;
using UnityEngine.UI;

namespace Sandbox.Tests.GuiSockets.Scripts.GUISockets
{
    public class CursorGuiSocket : MonoBehaviour, IGuiSocket
    {
        [SerializeField] private Image _cursorImage;

        public void Activate() => _cursorImage.enabled = true;
        public void Deactivate() => _cursorImage.enabled = false;
    }
}
