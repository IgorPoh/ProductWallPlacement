using System;
using System.Collections;
using System.Collections.Generic;

namespace WallFitter
{

    public class EventArgs<T> : EventArgs
    {
        public T Value;

        public EventArgs(T value)
        {
            Value = value;
        }
    }
}