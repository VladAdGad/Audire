using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ImageGuiSocket : MonoBehaviour, IGUISocket
{
    [SerializeField]
    private RectTransform _imageRectTransform;
    [SerializeField]
    private Image _image;
    
    public void Display(Sprite sprite)
    {
        _imageRectTransform.sizeDelta = sprite.rect.size;
        _image.sprite = sprite;
    }
    
    public void Flush() => _imageRectTransform.sizeDelta = Vector2.zero;
    
    public void Activate() => enabled = true;
    public void Deactivate() => enabled = false;
}
