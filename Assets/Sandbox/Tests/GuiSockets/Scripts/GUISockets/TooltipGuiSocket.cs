using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class TooltipGuiSocket : MonoBehaviour, IGUISocket
{
    [SerializeField]
    private Text socketText;

    public void Display(String text)
    {
        socketText.text = text;
    }
    
    public void Flush()
    {
        socketText.text = "";
    }
    
    public void Activate()
    {
        enabled = true;
    } 
    
    public void Deactivate()
    {
        enabled = false;
    }
}