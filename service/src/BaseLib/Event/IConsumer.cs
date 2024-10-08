﻿namespace BaseLib.Event
{
    public interface IConsumer<T>
    {
        void HandleEvent(T eventMessage);
    }
}