using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class TooltipGuiSocket : MonoBehaviour, IGUISocket
{
    [SerializeField] private Text socketText;

    private static readonly String EMPTY = "";

    public void Display(String text) => socketText.text = text;
    public void Flush() => socketText.text = EMPTY;

    public void Activate() => socketText.enabled = true;
    public void Deactivate() => socketText.enabled = false;
}
