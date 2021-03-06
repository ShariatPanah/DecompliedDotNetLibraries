﻿namespace System.ServiceModel
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ServerTooBusyException : CommunicationException
    {
        public ServerTooBusyException()
        {
        }

        public ServerTooBusyException(string message) : base(message)
        {
        }

        protected ServerTooBusyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ServerTooBusyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

