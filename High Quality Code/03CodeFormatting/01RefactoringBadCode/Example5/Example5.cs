﻿namespace Example5
{
    using System;

    public class Example5
    {
        public static void Main(string[] args)
        {
        }

        public static void Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            TKey eventKey,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> handler)
        {
            handlers[eventKey] -= handler;
        }
    }
}
