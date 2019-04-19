using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Modules;
using TraktSharp.Request;

namespace TraktSharp {

	/// <summary>A client providing all the consumable functionality of this library</summary>
	public class TraktClient {

		private TraktAuthModule _auth;

		private TraktAuthentication _authentication;

		private TraktCalendarsModule _calendars;

		private TraktCheckinModule _checkin;

		private TraktCommentsModule _comments;

		private TraktConfiguration _configuration;

		private TraktEpisodesModule _episodes;

		private TraktGenresModule _genres;

		private TraktMoviesModule _movies;

		private TraktOAuthModule _oauth;

		private TraktPeopleModule _people;

		private TraktRecommendationsModule _recommendations;

		private TraktScrobbleModule _scrobble;

		private TraktSearchModule _search;

		private TraktSeasonsModule _seasons;

		private TraktShowsModule _shows;

		private TraktSyncModule _sync;

		private TraktUsersModule _users;

		/// <summary>Default constructor</summary>
		/// <param name="handler">Used for unit testing to issue fake responses. Do not use otherwise.</param>
		public TraktClient(HttpMessageHandler handler = null) { HttpMessageHandler = handler; }

		/// <summary> Used for unit testing to issue fake responses. Do not use otherwise.</summary>
		public HttpMessageHandler HttpMessageHandler { get; }

		/// <summary>Configuration settings for the <see cref="TraktClient" /></summary>
		public TraktConfiguration Configuration {
			get {
				_configuration = _configuration ?? new TraktConfiguration(this);
				return _configuration;
			}
			set => _configuration = value;
		}

		/// <summary>Encapsulates functionality related to authentication</summary>
		public TraktAuthentication Authentication {
			get {
				_authentication = _authentication ?? new TraktAuthentication(this);
				return _authentication;
			}
			set => _authentication = value;
		}

		/// <summary>Provides API methods in the OAuth namespace</summary>
		public TraktOAuthModule OAuth {
			get {
				_oauth = _oauth ?? (TraktOAuthModule) RegisterModule(new TraktOAuthModule(this));
				return _oauth;
			}
			set => _oauth = value;
		}

		/// <summary>Provides API methods in the Auth namespace</summary>
		public TraktAuthModule Auth {
			get {
				_auth = _auth ?? (TraktAuthModule) RegisterModule(new TraktAuthModule(this));
				return _auth;
			}
			set => _auth = value;
		}

		/// <summary>Provides API methods in the Calendars namespace</summary>
		public TraktCalendarsModule Calendars {
			get {
				_calendars = _calendars ?? (TraktCalendarsModule) RegisterModule(new TraktCalendarsModule(this));
				return _calendars;
			}
			set => _calendars = value;
		}

		/// <summary>Provides API methods in the Checkin namespace</summary>
		public TraktCheckinModule Checkin {
			get {
				_checkin = _checkin ?? (TraktCheckinModule) RegisterModule(new TraktCheckinModule(this));
				return _checkin;
			}
			set => _checkin = value;
		}

		/// <summary>Provides API methods in the Comments namespace</summary>
		public TraktCommentsModule Comments {
			get {
				_comments = _comments ?? (TraktCommentsModule) RegisterModule(new TraktCommentsModule(this));
				return _comments;
			}
			set => _comments = value;
		}

		/// <summary>Provides API methods in the Genres namespace</summary>
		public TraktGenresModule Genres {
			get {
				_genres = _genres ?? (TraktGenresModule) RegisterModule(new TraktGenresModule(this));
				return _genres;
			}
			set => _genres = value;
		}

		/// <summary>Provides API methods in the Movies namespace</summary>
		public TraktMoviesModule Movies {
			get {
				_movies = _movies ?? (TraktMoviesModule) RegisterModule(new TraktMoviesModule(this));
				return _movies;
			}
			set => _movies = value;
		}

		/// <summary>Provides API methods in the People namespace</summary>
		public TraktPeopleModule People {
			get {
				_people = _people ?? (TraktPeopleModule) RegisterModule(new TraktPeopleModule(this));
				return _people;
			}
			set => _people = value;
		}

		/// <summary>Provides API methods in the Recommendations namespace</summary>
		public TraktRecommendationsModule Recommendations {
			get {
				_recommendations = _recommendations ?? (TraktRecommendationsModule) RegisterModule(new TraktRecommendationsModule(this));
				return _recommendations;
			}
			set => _recommendations = value;
		}

		/// <summary>Provides API methods in the Scrobble namespace</summary>
		public TraktScrobbleModule Scrobble {
			get {
				_scrobble = _scrobble ?? (TraktScrobbleModule) RegisterModule(new TraktScrobbleModule(this));
				return _scrobble;
			}
			set => _scrobble = value;
		}

		/// <summary>Provides API methods in the Search namespace</summary>
		public TraktSearchModule Search {
			get {
				_search = _search ?? (TraktSearchModule) RegisterModule(new TraktSearchModule(this));
				return _search;
			}
			set => _search = value;
		}

		/// <summary>Provides API methods in the Shows namespace</summary>
		public TraktShowsModule Shows {
			get {
				_shows = _shows ?? (TraktShowsModule) RegisterModule(new TraktShowsModule(this));
				return _shows;
			}
			set => _shows = value;
		}

		/// <summary>Provides API methods in the Seasons namespace</summary>
		public TraktSeasonsModule Seasons {
			get {
				_seasons = _seasons ?? (TraktSeasonsModule) RegisterModule(new TraktSeasonsModule(this));
				return _seasons;
			}
			set => _seasons = value;
		}

		/// <summary>Provides API methods in the Episodes namespace</summary>
		public TraktEpisodesModule Episodes {
			get {
				_episodes = _episodes ?? (TraktEpisodesModule) RegisterModule(new TraktEpisodesModule(this));
				return _episodes;
			}
			set => _episodes = value;
		}

		/// <summary>Provides API methods in the Sync namespace</summary>
		public TraktSyncModule Sync {
			get {
				_sync = _sync ?? (TraktSyncModule) RegisterModule(new TraktSyncModule(this));
				return _sync;
			}
			set => _sync = value;
		}

		/// <summary>Provides API methods in the Users namespace</summary>
		public TraktUsersModule Users {
			get {
				_users = _users ?? (TraktUsersModule) RegisterModule(new TraktUsersModule(this));
				return _users;
			}
			set => _users = value;
		}

		/// <summary>Executes immediately before an HTTP request is issued</summary>
		public event BeforeRequestEventHandler BeforeRequest;

		/// <summary>Executes immediately after an HTTP response is received</summary>
		public event AfterRequestEventHandler AfterRequest;

		private ITraktModule RegisterModule(ITraktModule module) {
			module.BeforeRequest += (sender, e) => { BeforeRequest?.Invoke(sender, e); };
			module.AfterRequest += (sender, e) => { AfterRequest?.Invoke(sender, e); };
			return module;
		}

	}

}