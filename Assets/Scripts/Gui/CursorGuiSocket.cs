using Gui.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class CursorGuiSocket : MonoBehaviour, IGuiSocket
    {
        [SerializeField] private Image _cursorImage;

        public void OnActivate() => _cursorImage.enabled = true;
        public void OnDeactivate() => _cursorImage.enabled = false;
    }
}
