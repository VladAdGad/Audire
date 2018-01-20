using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ImageGuiSocket : MonoBehaviour, IGUISocket
{
    [Header("Image")]
    [SerializeField] private RectTransform _imageRectTransform;
    [SerializeField] private Image _image;

    private void Start() => _imageRectTransform.SetAsFirstSibling();

    public void Display(Sprite sprite)
    {
        _image.sprite = sprite;
        _imageRectTransform.sizeDelta = sprite.rect.size;
    }

    public void Flush() => _imageRectTransform.sizeDelta = Vector2.zero;

    public void Activate() => enabled = true;
    public void Deactivate() => enabled = false;
}
