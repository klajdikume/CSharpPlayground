using System;
using System.Diagnostics;

namespace Playground.Interview
{
    #region interfaces

    public interface IOperation<in TIn, out TOut>
    {
        TOut Execute(TIn argument);
    }

    public class Op : IOperation<int, int>
    {
        public int Execute(int argument) => argument + 1;
    }

    public class ITry<TIn, TOut> : IOperation<TIn, TOut>
    {
        private readonly IOperation<TIn, TOut> _next;

        public ITry(IOperation<TIn, TOut> next) => _next = next;

        public TOut Execute(TIn argument)
        {
            try
            {
                return _next.Execute(argument);
            }
            catch
            {
                return default;
            }
        }
    }

    public class ITime<TIn, TOut> : IOperation<TIn, TOut>
    {
        private readonly IOperation<TIn, TOut> _next;

        public ITime(IOperation<TIn, TOut> next) => _next = next;

        public TOut Execute(TIn argument)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = _next.Execute(argument);
            sw.Start();
            Console.WriteLine(sw.ElapsedMilliseconds);

            return result;
        }
    }

    public class Permutations
    {
        public Permutations()
        {
            var one = new ITime<int, int>(
                new ITry<int, int>(
                    new Op()
                )
            );

            var two = new ITime<int, int>(
               new ITry<int, int>(
                   new Op()
               )
           );
        }
    }

    #endregion

    #region abstract classes

    public abstract class AOp<TIn, TOut>
    {
        public abstract TOut? Operation(TIn argument);
    }

    public class ATry<TIn, TOut> : AOp<TIn, TOut>
    {
        private readonly AOp<TIn, TOut> _next;

        public ATry(AOp<TIn, TOut> next)
        {
            _next = next;
        }

        public override TOut? Operation(TIn argument)
        {
            try
            {
                return _next.Operation(argument);
            }
            catch
            {
                return default;
            }
        }
    }

    public class ATime<TIn, TOut> : AOp<TIn, TOut>
    {
        private readonly AOp<TIn, TOut> _next;

        public ATime(AOp<TIn, TOut> next)
        {
            _next = next;
        }

        public override TOut? Operation(TIn argument)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = _next.Operation(argument);
            sw.Start();
            Console.WriteLine(sw.ElapsedMilliseconds);

            return result;
        }
    }

    public class AbsOp : AOp<int, int>
    {
        public override int Operation(int argument)
        {
            return argument + 1;
        }
    }

    public class APermutations
    {
        public APermutations()
        {
            var one = new ATime<int, int>(
                new ATry<int, int>(
                    new AbsOp()
                )
            );

            var two = new ATime<int, int>(
               new ATry<int, int>(
                   new AbsOp()
               )
           );
        }
    }

    #endregion
}
