using UnityEngine;

namespace EventManagement
{
    public interface IPressable : IIteractable
    {
        KeyCode ActivationKeyCode();
        
        void OnPress();
    }
}
