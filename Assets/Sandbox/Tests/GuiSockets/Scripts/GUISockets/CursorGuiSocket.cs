using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class CursorGuiSocket : MonoBehaviour, IGUISocket
{
    [SerializeField] private Image _cursorImage;

    //TODO add lock cursor on/off
    public void Activate()
    {
        _cursorImage.enabled = true;
    }

    public void Deactivate()
    {
        _cursorImage.enabled = false;
    }
}
