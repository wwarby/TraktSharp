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

	}

}