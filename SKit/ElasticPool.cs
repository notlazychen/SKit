using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SKit
{
    public class ElasticPool<T>
    {
        private ConcurrentStack<T> _pool;
        private Func<T> _builder;

        public ElasticPool(Func<T> builder, int preset)
        {
            _pool = new ConcurrentStack<T>();
            _builder = builder;
            for (int i = 0; i< preset; i++)
            {
                var element = _builder.Invoke();
                _pool.Push(element);
            }
        }

        public T Pop()
        {
            T o;
            if(!_pool.TryPop(out o))
            {
                return _builder.Invoke();
            }
            return o;
        }

        public void Push(T element)
        {
            _pool.Push(element);
        }
    }
}
