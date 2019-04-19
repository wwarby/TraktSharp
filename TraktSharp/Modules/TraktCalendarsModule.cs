﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Enums;
using TraktSharp.Request.Calendars;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Calendars namespace</summary>
	public class TraktCalendarsModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient" />.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient" /></param>
		public TraktCalendarsModule(TraktClient client) : base(client) { }

		/// <summary>Returns all shows airing during the time period specified.</summary>
		/// <param name="startDate">Start the calendar on this date. Example: <c>2014-09-01</c>.</param>
		/// <param name="days">Number of days to display. Example: <c>7</c>.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<Dictionary<string, IEnumerable<TraktCalendarsShowsResponseItem>>> GetShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktCalendarsShowsRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});

		/// <summary>Returns all new show premieres (season 1, episode 1) airing during the time period specified.</summary>
		/// <param name="startDate">Start the calendar on this date. Example: <c>2014-09-01</c>.</param>
		/// <param name="days">Number of days to display. Example: <c>7</c>.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<Dictionary<string, IEnumerable<TraktCalendarsShowsResponseItem>>> GetNewShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktCalendarsShowsNewRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});

		/// <summary>Returns all show premieres (any season, episode 1) airing during the time period specified.</summary>
		/// <param name="startDate">Start the calendar on this date. Example: <c>2014-09-01</c>.</param>
		/// <param name="days">Number of days to display. Example: <c>7</c>.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<Dictionary<string, IEnumerable<TraktCalendarsShowsResponseItem>>> GetPremiereShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktCalendarsShowsPremieresRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});

		/// <summary>Returns all movies with a release date during the time period specified.</summary>
		/// <param name="startDate">Start the calendar on this date. Example: <c>2014-09-01</c>.</param>
		/// <param name="days">Number of days to display. Example: <c>7</c>.</param>
		/// <param name="authenticate">If true, authentication headers will be sent with this request</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<Dictionary<string, IEnumerable<TraktCalendarsMoviesResponseItem>>> GetMoviesAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktCalendarsMoviesRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});

	}

}