using System.ComponentModel;

namespace TraktSharp.Enums
{
    /// <summary>Options for the rating parameter on supporting request types</summary>
    public enum TraktHistoryItemType {
        /// <summary>Unspecified</summary>
        [Description("")]
        Unspecified,
        /// <summary>Movie</summary>
        [Description("movies")]
        Movie,
        /// <summary>Show</summary>
        [Description("shows")]
        Show,
        /// <summary>Episode</summary>
        [Description("episodes")]
        Episode,
        /// <summary>Episode</summary>
        [Description("seasons")]
        Season
    }
}