using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ImageGuiSocket : MonoBehaviour, IGUISocket
{
    [Header("Image")] [SerializeField] private RectTransform _imageRectTransform;
    [SerializeField] private Image _image;

    private void Start() => _imageRectTransform.SetAsFirstSibling();

    public void Display(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.enabled = true;
    }

    public void Flush()
    {
        _image.enabled = false;
    }

    public void Activate() => enabled = true;
    public void Deactivate() => enabled = false;
}
