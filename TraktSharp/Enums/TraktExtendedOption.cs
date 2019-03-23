using System.ComponentModel;

namespace TraktSharp.Enums {
    /// <summary>Options for the extended parameter on supporting request types</summary>
    public enum TraktExtendedOption {
        /// <summary>Unspecified</summary>
        [Description("")]
        Unspecified,
        /// <summary>No Seasons </summary>
        [Description("noseasons")]
        NoSeasons,
        /// <summary>Include Depisodes</summary>
        [Description("episodes")]
        Episodes,
        /// <summary>Full</summary>
        [Description("full")]
        Full,
        /// <summary>Metadata</summary>
        [Description("metadata")]
        Metadata
    }
}