using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Modules;

namespace TraktSharp {

	public class TraktClient {

		private HttpMessageHandler _handler;

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
				_oauth = _oauth ?? new TraktOAuthModule(this);
				return _oauth;
			}
			set { _oauth = value; }
		}

		private TraktAuthModule _auth;
		public TraktAuthModule Auth {
			get {
				_auth = _auth ?? new TraktAuthModule(this);
				return _auth;
			}
			set { _auth = value; }
		}

		private TraktCalendarsModule _calendars;
		public TraktCalendarsModule Calendars {
			get {
				_calendars = _calendars ?? new TraktCalendarsModule(this);
				return _calendars;
			}
			set { _calendars = value; }
		}

		private TraktCheckinModule _checkin;
		public TraktCheckinModule Checkin {
			get {
				_checkin = _checkin ?? new TraktCheckinModule(this);
				return _checkin;
			}
			set { _checkin = value; }
		}

		private TraktCommentsModule _comments;
		public TraktCommentsModule Comments {
			get {
				_comments = _comments ?? new TraktCommentsModule(this);
				return _comments;
			}
			set { _comments = value; }
		}

		private TraktGenresModule _genres;
		public TraktGenresModule Genres {
			get {
				_genres = _genres ?? new TraktGenresModule(this);
				return _genres;
			}
			set { _genres = value; }
		}

		private TraktMoviesModule _movies;
		public TraktMoviesModule Movies {
			get {
				_movies = _movies ?? new TraktMoviesModule(this);
				return _movies;
			}
			set { _movies = value; }
		}

		private TraktPeopleModule _people;
		public TraktPeopleModule People {
			get {
				_people = _people ?? new TraktPeopleModule(this);
				return _people;
			}
			set { _people = value; }
		}

		private TraktRecommendationsModule _recommendations;
		public TraktRecommendationsModule Recommendations {
			get {
				_recommendations = _recommendations ?? new TraktRecommendationsModule(this);
				return _recommendations;
			}
			set { _recommendations = value; }
		}

		private TraktScrobbleModule _scrobble;
		public TraktScrobbleModule Scrobble {
			get {
				_scrobble = _scrobble ?? new TraktScrobbleModule(this);
				return _scrobble;
			}
			set { _scrobble = value; }
		}

		private TraktSearchModule _search;
		public TraktSearchModule Search {
			get {
				_search = _search ?? new TraktSearchModule(this);
				return _search;
			}
			set { _search = value; }
		}

		private TraktShowsModule _shows;
		public TraktShowsModule Shows {
			get {
				_shows = _shows ?? new TraktShowsModule(this);
				return _shows;
			}
			set { _shows = value; }
		}

		private TraktSeasonsModule _seasons;
		public TraktSeasonsModule Seasons {
			get {
				_seasons = _seasons ?? new TraktSeasonsModule(this);
				return _seasons;
			}
			set { _seasons = value; }
		}

		private TraktEpisodesModule _episodes;
		public TraktEpisodesModule Episodes {
			get {
				_episodes = _episodes ?? new TraktEpisodesModule(this);
				return _episodes;
			}
			set { _episodes = value; }
		}

		private TraktSyncModule _sync;
		public TraktSyncModule Sync {
			get {
				_sync = _sync ?? new TraktSyncModule(this);
				return _sync;
			}
			set { _sync = value; }
		}

		private TraktUsersModule _users;
		public TraktUsersModule Users {
			get {
				_users = _users ?? new TraktUsersModule(this);
				return _users;
			}
			set { _users = value; }
		}
	}

}