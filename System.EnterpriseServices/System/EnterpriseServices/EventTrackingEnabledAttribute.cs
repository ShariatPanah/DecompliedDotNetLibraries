﻿namespace System.EnterpriseServices
{
    using System;
    using System.Collections;
    using System.EnterpriseServices.Admin;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Class, Inherited=true), ComVisible(false)]
    public sealed class EventTrackingEnabledAttribute : Attribute, IConfigurationAttribute
    {
        private bool _value;

        public EventTrackingEnabledAttribute() : this(true)
        {
        }

        public EventTrackingEnabledAttribute(bool val)
        {
            this._value = val;
        }

        bool IConfigurationAttribute.AfterSaveChanges(Hashtable info)
        {
            return false;
        }

        bool IConfigurationAttribute.Apply(Hashtable info)
        {
            ((ICatalogObject) info["Component"]).SetValue("EventTrackingEnabled", this._value);
            return true;
        }

        bool IConfigurationAttribute.IsValidTarget(string s)
        {
            return (s == "Component");
        }

        public bool Value
        {
            get
            {
                return this._value;
            }
        }
    }
}

