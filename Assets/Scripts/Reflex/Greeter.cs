using System.Collections.Generic;
using Reflex.Core;
using UnityEngine;

namespace Reflex
{
    public class Greeter : IStartable
    {
        public Greeter(IEnumerable<string> strings) => 
            Debug.Log(string.Join(" ", strings));

        public void Start() {}
    }
}