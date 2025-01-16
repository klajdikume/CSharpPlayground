using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Interview
{
    #region

    public interface IReady<out T>
    {
        public T Value { get; }
    }

    public interface ISetup<T>
    {
        IReady<T> Initialize(T value);
    }

    public class State : IReady<int>, ISetup<int>
    {
        public int Value { get; private set; }

        public IReady<int> Initialize(int value) 
        {
            Value = value;
            return this;
        }
    }

    public class UsingTheThing
    {
        public UsingTheThing(ISetup<int> setup)
        {
            var ready = setup.Initialize(5);
        }
    }

    #endregion

    #region Traits / Roles

    public class Actor : Context.IRole
    {
        public int Name { get; }
    }

    public class Context
    {
        private readonly IRole _role;

        public Context(IRole role)
        {
            _role = role;
        }

        public interface IRole
        {
            int Name { get; }
            void Do()
            {
                Console.WriteLine(Name);
            }
        }

        public void SomethingHappens()
        {

        }
    }

    #endregion

}
