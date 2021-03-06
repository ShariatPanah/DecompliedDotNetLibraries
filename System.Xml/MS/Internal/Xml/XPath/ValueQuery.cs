﻿namespace MS.Internal.Xml.XPath
{
    using System;
    using System.Xml.XPath;

    internal abstract class ValueQuery : Query
    {
        public ValueQuery()
        {
        }

        protected ValueQuery(ValueQuery other) : base(other)
        {
        }

        public sealed override XPathNavigator Advance()
        {
            throw XPathException.Create("Xp_NodeSetExpected");
        }

        public sealed override void Reset()
        {
        }

        public sealed override int Count
        {
            get
            {
                throw XPathException.Create("Xp_NodeSetExpected");
            }
        }

        public sealed override XPathNavigator Current
        {
            get
            {
                throw XPathException.Create("Xp_NodeSetExpected");
            }
        }

        public sealed override int CurrentPosition
        {
            get
            {
                throw XPathException.Create("Xp_NodeSetExpected");
            }
        }
    }
}

