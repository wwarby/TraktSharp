using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Modules;
using TraktSharp.Request;

namespace TraktSharp {

	public class TraktClient {

		public event BeforeRequestEventHandler BeforeRequest;
		public event AfterRequestEventHandler AfterRequest;

		private readonly HttpMessageHandler _handler;

		public TraktClient(HttpMessageHandler handler = null) { _handler = handler; }

		public HttpMessageHandler HttpMessageHandler { get { return _handler; } }

		private TraktConfiguration _configuration;
		public TraktConfiguration Configuration {
			get {
				_configuration = _configuration ?? new TraktConfiguration(this);
				return _configuration;
			}
			set { _configuration = value; }
		}

		private TraktAuthentication _authentication;
		public TraktAuthentication Authentication {
			get {
				_authentication = _authentication ?? new TraktAuthentication(this);
				return _authentication;
			}
			set { _authentication = value; }
		}

		private TraktOAuthModule _oauth;
		public TraktOAuthModule OAuth {
			get {
				_oauth = _oauth ?? (TraktOAuthModule)RegisterModule(new TraktOAuthModule(this));
				return _oauth;
			}
			set { _oauth = value; }
		}

		private TraktAuthModule _auth;
		public TraktAuthModule Auth {
			get {
				_auth = _auth ?? (TraktAuthModule)RegisterModule(new TraktAuthModule(this));
				return _auth;
			}
			set { _auth = value; }
		}

		private TraktCalendarsModule _calendars;
		public TraktCalendarsModule Calendars {
			get {
				_calendars = _calendars ?? (TraktCalendarsModule)RegisterModule(new TraktCalendarsModule(this));
				return _calendars;
			}
			set { _calendars = value; }
		}

		private TraktCheckinModule _checkin;
		public TraktCheckinModule Checkin {
			get {
				_checkin = _checkin ?? (TraktCheckinModule)RegisterModule(new TraktCheckinModule(this));
				return _checkin;
			}
			set { _checkin = value; }
		}

		private TraktCommentsModule _comments;
		public TraktCommentsModule Comments {
			get {
				_comments = _comments ?? (TraktCommentsModule)RegisterModule(new TraktCommentsModule(this));
				return _comments;
			}
			set { _comments = value; }
		}

		private TraktGenresModule _genres;
		public TraktGenresModule Genres {
			get {
				_genres = _genres ?? (TraktGenresModule)RegisterModule(new TraktGenresModule(this));
				return _genres;
			}
			set { _genres = value; }
		}

		private TraktMoviesModule _movies;
		public TraktMoviesModule Movies {
			get {
				_movies = _movies ?? (TraktMoviesModule)RegisterModule(new TraktMoviesModule(this));
				return _movies;
			}
			set { _movies = value; }
		}

		private TraktPeopleModule _people;
		public TraktPeopleModule People {
			get {
				_people = _people ?? (TraktPeopleModule)RegisterModule(new TraktPeopleModule(this));
				return _people;
			}
			set { _people = value; }
		}

		private TraktRecommendationsModule _recommendations;
		public TraktRecommendationsModule Recommendations {
			get {
				_recommendations = _recommendations ?? (TraktRecommendationsModule)RegisterModule(new TraktRecommendationsModule(this));
				return _recommendations;
			}
			set { _recommendations = value; }
		}

		private TraktScrobbleModule _scrobble;
		public TraktScrobbleModule Scrobble {
			get {
				_scrobble = _scrobble ?? (TraktScrobbleModule)RegisterModule(new TraktScrobbleModule(this));
				return _scrobble;
			}
			set { _scrobble = value; }
		}

		private TraktSearchModule _search;
		public TraktSearchModule Search {
			get {
				_search = _search ?? (TraktSearchModule)RegisterModule(new TraktSearchModule(this));
				return _search;
			}
			set { _search = value; }
		}

		private TraktShowsModule _shows;
		public TraktShowsModule Shows {
			get {
				_shows = _shows ?? (TraktShowsModule)RegisterModule(new TraktShowsModule(this));
				return _shows;
			}
			set { _shows = value; }
		}

		private TraktSeasonsModule _seasons;
		public TraktSeasonsModule Seasons {
			get {
				_seasons = _seasons ?? (TraktSeasonsModule)RegisterModule(new TraktSeasonsModule(this));
				return _seasons;
			}
			set { _seasons = value; }
		}

		private TraktEpisodesModule _episodes;
		public TraktEpisodesModule Episodes {
			get {
				_episodes = _episodes ?? (TraktEpisodesModule)RegisterModule(new TraktEpisodesModule(this));
				return _episodes;
			}
			set { _episodes = value; }
		}

		private TraktSyncModule _sync;
		public TraktSyncModule Sync {
			get {
				_sync = _sync ?? (TraktSyncModule)RegisterModule(new TraktSyncModule(this));
				return _sync;
			}
			set { _sync = value; }
		}

		private TraktUsersModule _users;
		public TraktUsersModule Users {
			get {
				_users = _users ?? (TraktUsersModule)RegisterModule(new TraktUsersModule(this));
				return _users;
			}
			set { _users = value; }
		}

		private ITraktModule RegisterModule(ITraktModule module) {
			module.BeforeRequest += (sender, e) => {
				if (BeforeRequest != null) { BeforeRequest(sender, e); }
			};
			module.AfterRequest += (sender, e) => {
				if (AfterRequest != null) { AfterRequest(sender, e); }
			};
			return module;
		}

	}

}