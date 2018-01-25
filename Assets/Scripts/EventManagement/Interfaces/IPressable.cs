using UnityEngine;

namespace EventManagement.Interfaces
{
    public interface IPressable : IInteractable
    {
        KeyCode ActivationKeyCode();

        void OnPress();
    }
}
