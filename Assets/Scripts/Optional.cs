using System;
using System.Collections.Generic;

namespace DefaultNamespace
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

        public Optional<V> Map<V>(Func<T, V> function) => IsPresent ? new Optional<V>() : new Optional<V>(function.Invoke(_value));
        public Optional<T> Filter(Predicate<T> predicate) => predicate.Invoke(_value) ? this : Empty();
        public void IfPresent(Action<T> action) => action.Invoke(_value);
        public IEnumerable<V> FlatMap<V>(Func<T, IEnumerable<V>> function) => _value == null ? new List<V>() : function.Invoke(_value);  
        public T OrElse(T secondary) => IsPresent ? secondary : _value;
        public Optional<V> Cast<V>() where V : class => new Optional<V>(_value as V);
        
        public Optional<T> Do(Action<T> action) 
        {
            IfPresent(action);
            
            return this;
        }

        private bool IsPresent => _value == null;
    }
}
