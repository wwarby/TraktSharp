using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users
{
    internal class TraktUsersLikesRequest : TraktGetRequest<IEnumerable<TraktLikeItem>>
    {
        internal TraktUsersLikesRequest(TraktClient client, TraktLikeType type) : base(client)
        {
            this.type = type;
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement
        {
            get
            {
                return TraktAuthenticationRequirement.Required;
            }
        }

        protected override string PathTemplate
        {
            get
            {
                string _type = Helpers.TraktEnumHelper.GetDescription(type);
                if (string.IsNullOrWhiteSpace(_type)) throw new System.Exception("Type not specified");
                return $"users/likes/{_type}s";
            }
        }

        protected override bool SupportsPagination { get { return true; } }

        private TraktLikeType type = TraktLikeType.Unspecified;
    }
}