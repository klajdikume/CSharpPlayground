using System;

namespace Playground.Interview
{
    public interface ICache
    {
        void Store(string key, byte[] payload);
        byte[] Get(string key);
        byte[] GetPrefixed(string key, string prefix) => Get($"{prefix}-{key}");
    }

    public class Space : ICache
    {
        public void MyMethod()
        {
            var space = new Space();
            ICache cache = space;
        }

        public byte[] Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, byte[] payload)
        {
            throw new NotImplementedException();
        }
    }
}
