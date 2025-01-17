﻿namespace NKart.Core.Configuration.Outline
{
    using System.Configuration;

    /// <summary>
    /// A configuration element for pluggable objects.
    /// </summary>
    public class PluggableObjectElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the alias (key) value for the strategies collection element.
        /// </summary>
        [ConfigurationProperty("alias", IsKey = true)]
        public string Alias
        {
            get { return (string)this["alias"]; }
            set { this["alias"] = value; }
        }

        /// <summary>
        /// Gets or sets the type associated with the setting.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }    
    }
}