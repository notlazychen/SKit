
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Reflection;
using System.Threading;

namespace SKit.AOP
{

    class EntityNotifier<T> : DynamicObject where T : new()
    {
        public class ObjectChangedEventArgs : EventArgs
        {
            public string PropertyName { get; set; }
            public object OldValue { get; private set; }
            public ObjectChangedEventArgs(string name, object value)
            {
                PropertyName = name;
                OldValue = value;
            }
        }

        private T innerObject { get; set; }

        public EntityNotifier()
        {
            innerObject = new T();
        }

        public EntityNotifier(T obj)
        {
            innerObject = obj;
        }

        public static implicit operator EntityNotifier<T>(T obj)
        {
            return new EntityNotifier<T>(obj);
        }

        public static implicit operator T(EntityNotifier<T> obj)
        {
            return obj.innerObject;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var p = typeof(T).GetProperties().SingleOrDefault(x => x.Name == binder.Name);
            if (p == default(PropertyInfo))
            {
                result = null;
                return false;
            }
            else
            {
                result = p.GetValue(innerObject, new object[] { });
                return true;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var p = typeof(T).GetProperties().SingleOrDefault(x => x.Name == binder.Name);
            if (p == default(PropertyInfo))
            {
                return false;
            }
            else
            {
                object oldvalue = p.GetValue(innerObject, new object[] { });
                p.SetValue(innerObject, value, new object[] { });
                if (ObjectChanged != null) ObjectChanged(this, new ObjectChangedEventArgs(binder.Name, oldvalue));
                return true;
            }
        }

        public event EventHandler<EntityNotifier<T>.ObjectChangedEventArgs> ObjectChanged;
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //dynamic person = new EntityNotifier<Person>();
            //person.ObjectChanged += new EventHandler<EntityNotifier<Person>.ObjectChangedEventArgs>((x, y) =>
            //{
            //    Console.WriteLine("obj.{0} changed.", y.PropertyName);
            //});
            //person.Name = "张三";
            //person.Name = "李四";
            //person.ID = 1;
            //Person p = person;
            //Console.WriteLine(p.Name);
            MonitorSample();
        }

        static void MonitorSample()
        {
            var obj = new object();
            Monitor.Enter(obj);
            Console.WriteLine(DateTime.Now);
            Thread t = new Thread(() => {
                Thread.Sleep(2000);
                Monitor.Enter(obj);
                Thread.Sleep(2000);
                Monitor.Pulse(obj);
                Thread.Sleep(2000);
                Monitor.Exit(obj);
            });
            t.Start();
            Monitor.Wait(obj);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine("over");
            Console.ReadKey();
        }

        static void RandomArenaRankPlayers()
        {
            Random random = new Random();
            while (true)
            {
                int cur = int.Parse(Console.ReadLine());
                int step = (int)Math.Ceiling(cur / 3d);
                int from = cur - step;
                if (from > cur - 5)
                {
                    from = cur - 5;
                }
                int to = cur;
                int wei = (int)Math.Ceiling(step / 5d);

                Console.WriteLine($"{from} - {to} / {wei}");
                Console.WriteLine($"-------------------");
                for (int i = 0; i < 5; i++)
                {
                    int a = @from + i * wei;
                    int b = @from + i * wei + wei;
                    int r = random.Next(a, b);
                    Console.WriteLine($"{a} - {b} / {r}");
                }
                Console.WriteLine($"-------------------");
            }
        }
    }

}
