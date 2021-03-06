﻿namespace Microsoft.Transactions.Wsat.Messaging
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Xml;

    internal class RegisterResponseMessage : CoordinationMessage
    {
        private RegisterResponse response;

        public RegisterResponseMessage(MessageVersion version, ref RegisterResponse response) : base(CoordinationStrings.Version(response.ProtocolVersion).RegisterResponseAction, version)
        {
            this.response = response;
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            if (writer == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
            }
            this.response.WriteTo(writer);
        }
    }
}

