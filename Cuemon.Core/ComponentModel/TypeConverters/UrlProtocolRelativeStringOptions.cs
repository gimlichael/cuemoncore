﻿namespace Cuemon.ComponentModel.TypeConverters
{
    /// <summary>
    /// Configuration options for <see cref="UrlProtocolRelativeStringConverter"/>.
    /// </summary>
    public class UrlProtocolRelativeStringOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlProtocolRelativeStringOptions"/> class.
        /// </summary>
        /// <remarks>
        /// The following table shows the initial property values for an instance of <see cref="UrlProtocolRelativeStringOptions"/>.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Property</term>
        ///         <description>Initial Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Protocol"/></term>
        ///         <description><see cref="UriScheme.Https"/></description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Protocol"/></term>
        ///         <description><see cref="StringUtility.NetworkPathReference"/></description>
        ///     </item>
        /// </list>
        /// </remarks>
        public UrlProtocolRelativeStringOptions()
        {
            Protocol = UriScheme.Https;
            RelativeReference = StringUtility.NetworkPathReference;
        }

        /// <summary>
        /// Gets or sets the protocol to replace the relative reference.
        /// </summary>
        /// <value>The protocol to replace the relative reference.</value>
        public UriScheme Protocol { get; set; }

        /// <summary>
        /// Gets or sets the protocol relative reference that needs to be replaced.
        /// </summary>
        /// <value>The protocol relative reference that needs to be replaced.</value>
        public string RelativeReference { get; set; }
    }
}