using System;

namespace Utilities
{
    public class OneTimeAction
    {
        private bool _isUsed;
        private readonly Action _action;

        public OneTimeAction(Action action)
        {
            _action = action;
        }

        public void Invoke()
        {
            if (!_isUsed)
            {
                _isUsed = true;
                _action.Invoke();
            }
        }
    }
}
