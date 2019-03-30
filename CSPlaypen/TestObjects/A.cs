using System;
using System.Collections.Generic;
using System.Text;

namespace CSPlaypen.TestObjects
{
    public class A
    {
        public int State { get; set; }

        public EventHandler Called { get; set; } = (_, __) => { };

        public void OnCall()
        {
            Called(this, null);
        }
    }
}
