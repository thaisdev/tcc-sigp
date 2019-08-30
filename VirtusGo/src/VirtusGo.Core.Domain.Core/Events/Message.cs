﻿namespace VirtusGo.Core.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public int AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}