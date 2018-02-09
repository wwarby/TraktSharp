using System.ComponentModel;

namespace TraktSharp.Enums
{
    public enum TraktCommentSortOrder
    {
        [Description("newest")]
        Newest,

        [Description("oldest")]
        Oldest,

        [Description("likes")]
        Likes,

        [Description("replies")]
        Replies
    }
}