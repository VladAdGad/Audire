using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Optional<T>
    {
        private readonly T _value;

        private Optional(T value)
        {
            _value = value;
        }

        private Optional()
        {
            _value = default(T);
        }

        public static Optional<T> Of(T value) => new Optional<T>(value);
        public static Optional<T> Empty() => new Optional<T>();

        public Optional<V> Map<V>(Func<T, V> function) => IsPresent ? new Optional<V>(function.Invoke(_value)) : new Optional<V>();
        public Optional<T> Filter(Predicate<T> predicate) => IsPresent && predicate.Invoke(_value) ? this : Empty();
        public IEnumerable<V> FlatMap<V>(Func<T, IEnumerable<V>> function) => IsPresent ? function.Invoke(_value) : new List<V>();

        public T OrElse(T secondary) => IsPresent ? _value : secondary;

        public Optional<V> Cast<V>() where V : class => new Optional<V>(_value as V);

        public Optional<T> Do(Action<T> action)
        {
            IfPresent(action);

            return this;
        }

        public void IfPresent(Action<T> action)
        {
            if (IsPresent)
            {
                action.Invoke(_value);
            }
        }

        private bool IsPresent => _value != null;
    }
}
