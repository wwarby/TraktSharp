using System;
using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Users {

	internal class TraktUsersLikesRequest : TraktGetRequest<IEnumerable<TraktLikeItem>> {

		private readonly TraktLikeType _likeType;

		internal TraktUsersLikesRequest(TraktClient client, TraktLikeType type) : base(client) { _likeType = type; }

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

		protected override string PathTemplate {
			get {
				var description = TraktEnumHelper.GetDescription(_likeType);
				if (string.IsNullOrWhiteSpace(description)) {
					throw new Exception("Type not specified");
				}

				return $"users/likes/{description}s";
			}
		}

		protected override bool SupportsPagination => true;

	}

}