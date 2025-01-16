using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Interview
{
    #region

    public abstract class Notification
    {
        public bool Notify(int number)
        {
            var execute = Check(number);

            if (execute)
            {
                Execute(number);
            }

            return execute;
        }

        protected abstract bool Check(int number);
        protected abstract void Execute(int number);
    }

    public class AlertAdmin : Notification
    {
        protected override bool Check(int number) => number is > 10 and < 100;
        protected override void Execute(int number) => Console.WriteLine(number);
    }

    public class NotifySeetSpot : Notification
    {
        protected override bool Check(int number) => number == 69;
        protected override void Execute(int number) => Console.WriteLine(number);
    }

    #endregion

    public interface IConstraint
    {
        bool Check(int number);
    }

    public interface INotification
    {
        void Notify(int number);
    }

    public class PerformNotification
    {
        private readonly IConstraint _constraint;
        private readonly INotification _notification;

        public PerformNotification(IConstraint constraint, INotification notification)
        {
            _constraint = constraint;
            _notification = notification;
        }

        public bool Notify(int number)
        {
            var execute = _constraint.Check(number);

            if (execute)
            {
                _notification.Notify(number);
            }

            return execute;
        }
    }

    public class AdminConstraint : IConstraint
    {
        public bool Check(int number) => number is > 10 and < 100;
    }

    public class SweetSpot : IConstraint
    {
        public bool Check(int number) => number == 69;
    }

    public class Print : INotification
    {
        public void Notify(int number) => Console.WriteLine(number);
    }

    public class Usage
    {
        public Usage()
        {
            var alertAdmin = new PerformNotification(
                    new AdminConstraint(),
                    new Print()
                );

            var notifySweetSpot = new PerformNotification(
                    new SweetSpot(),
                    new Print()
                );
        }
    }
}
