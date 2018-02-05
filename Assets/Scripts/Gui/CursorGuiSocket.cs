using Gui.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class CursorGuiSocket : MonoBehaviour, IGuiSocket
    {
        [SerializeField] private Image _cursorImage;

        public void Activate() => _cursorImage.enabled = true;
        public void Deactivate() => _cursorImage.enabled = false;
    }
}
