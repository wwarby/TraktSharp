using System.ComponentModel;

namespace TraktSharp.Enums
{
    /// <summary>Options for the rating parameter on supporting request types</summary>
    public enum TraktLikeType
    {
        /// <summary>Unspecified</summary>
        [Description("")]
        Unspecified,

        /// <summary>Movie</summary>
        [Description("comment")]
        Comments,

        /// <summary>Show</summary>
        [Description("list")]
        Lists
    }
}