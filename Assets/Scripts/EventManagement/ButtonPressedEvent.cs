using UnityEngine;

namespace EventManagement
{
    public class ButtonPressedEvent
    {
        private readonly KeyCode _pressedButtonCode;

        public ButtonPressedEvent(KeyCode keyCode)
        {
            _pressedButtonCode = keyCode;
        }

        public KeyCode PressedButtonCode
        {
            get { return _pressedButtonCode; }
        }
    }
}