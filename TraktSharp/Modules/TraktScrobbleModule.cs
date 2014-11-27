using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Scrobble;
using TraktSharp.Entities.Response.Scrobble;
using TraktSharp.Factories;
using TraktSharp.Request.Scrobble;

namespace TraktSharp.Modules {

	public class TraktScrobbleModule : TraktModuleBase {

		public TraktScrobbleModule(TraktClient client) : base(client) { }

		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(string movieId, StringMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StartMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(int movieId, IntMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StartMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(string title, int? year, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StartMovieAsync(TraktMovieFactory.FromTitleAndYear(title, year), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(TraktMovie movie, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktScrobbleStartMovieRequest(Client) {
				RequestBody = new TraktScrobbleMovieRequestBody {
					Movie = movie,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});
		}

		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(string episodeId, StringEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StartEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(int episodeId, IntEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StartEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(string showTitle, int? showYear, int season, int episode, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StartEpisodeAsync(TraktEpisodeFactory.FromSeasonAndNumber(season, episode), TraktShowFactory.FromTitleAndYear(showTitle, showYear), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(TraktEpisode episode, TraktShow show, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktScrobbleStartEpisodeRequest(Client) {
				RequestBody = new TraktScrobbleEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate,
				},
				Extended = extended
			});
		}

		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(string movieId, StringMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PauseMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(int movieId, IntMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PauseMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(string title, int? year, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PauseMovieAsync(TraktMovieFactory.FromTitleAndYear(title, year), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(TraktMovie movie, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktScrobblePauseMovieRequest(Client) {
				RequestBody = new TraktScrobbleMovieRequestBody {
					Movie = movie,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});
		}

		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(string episodeId, StringEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PauseEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(int episodeId, IntEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PauseEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(string showTitle, int? showYear, int season, int episode, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PauseEpisodeAsync(TraktEpisodeFactory.FromSeasonAndNumber(season, episode), TraktShowFactory.FromTitleAndYear(showTitle, showYear), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(TraktEpisode episode, TraktShow show, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktScrobblePauseEpisodeRequest(Client) {
				RequestBody = new TraktScrobbleEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate,
				},
				Extended = extended
			});
		}

		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(string movieId, StringMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StopMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(int movieId, IntMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StopMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(string title, int? year, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StopMovieAsync(TraktMovieFactory.FromTitleAndYear(title, year), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(TraktMovie movie, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktScrobbleStopMovieRequest(Client) {
				RequestBody = new TraktScrobbleMovieRequestBody {
					Movie = movie,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});
		}

		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(string episodeId, StringEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StopEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(int episodeId, IntEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StopEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(string showTitle, int? showYear, int season, int episode, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await StopEpisodeAsync(TraktEpisodeFactory.FromSeasonAndNumber(season, episode), TraktShowFactory.FromTitleAndYear(showTitle, showYear), progress, appVersion, appDate, extended);
		}

		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(TraktEpisode episode, TraktShow show, float progress, string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktScrobbleStopEpisodeRequest(Client) {
				RequestBody = new TraktScrobbleEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate,
				},
				Extended = extended
			});
		}

	}

}