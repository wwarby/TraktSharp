using System;
using System.Linq;
using TraktSharp.Modules;

namespace TraktSharp {

	public class TraktClient {

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

		private TraktOAuth _oauth;
		public TraktOAuth OAuth {
			get {
				_oauth = _oauth ?? new TraktOAuth(this);
				return _oauth;
			}
			set { _oauth = value; }
		}

		private TraktCalendars _calendars;
		public TraktCalendars Calendars {
			get {
				_calendars = _calendars ?? new TraktCalendars(this);
				return _calendars;
			}
			set { _calendars = value; }
		}

		private TraktShows _shows;
		public TraktShows Shows {
			get {
				_shows = _shows ?? new TraktShows(this);
				return _shows;
			}
			set { _shows = value; }
		}

		private TraktSeasons _seasons;
		public TraktSeasons Seasons {
			get {
				_seasons = _seasons ?? new TraktSeasons(this);
				return _seasons;
			}
			set { _seasons = value; }
		}

		private TraktEpisodes _episodes;
		public TraktEpisodes Episodes {
			get {
				_episodes = _episodes ?? new TraktEpisodes(this);
				return _episodes;
			}
			set { _episodes = value; }
		}

	}

}