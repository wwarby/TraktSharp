using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Scrobble;
using TraktSharp.Entities.Response.Scrobble;
using TraktSharp.Enums;
using TraktSharp.Factories;
using TraktSharp.Request.Scrobble;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Scrobble namespace</summary>
	public class TraktScrobbleModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient" />.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient" /></param>
		public TraktScrobbleModule(TraktClient client) : base(client) { }

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(string movieId, TraktTextMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StartMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(int movieId, TraktNumericMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StartMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(string movieTitle, int? movieYear, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StartMovieAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="movie">The movie</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StartMovieAsync(TraktMovie movie, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktScrobbleStartMovieRequest(Client) {
				RequestBody = new TraktScrobbleMovieRequestBody {
					Movie = movie,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(string episodeId, TraktTextEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StartEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StartEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(string showTitle, int? showYear, int seasonNumber, int episodeNumber, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StartEpisodeAsync(TraktEpisodeFactory.FromSeasonAndEpisodeNumber(seasonNumber, episodeNumber), TraktShowFactory.FromTitleAndYear(showTitle, showYear), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video initially starts playing or is unpaused. This will remove any playback progress
		///     if it exists.
		/// </summary>
		/// <param name="episode">The episode</param>
		/// <param name="show">The show</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StartEpisodeAsync(TraktEpisode episode, TraktShow show, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktScrobbleStartEpisodeRequest(Client) {
				RequestBody = new TraktScrobbleEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(string movieId, TraktTextMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await PauseMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(int movieId, TraktNumericMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await PauseMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(string movieTitle, int? movieYear, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await PauseMovieAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="movie">The movie</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> PauseMovieAsync(TraktMovie movie, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktScrobblePauseMovieRequest(Client) {
				RequestBody = new TraktScrobbleMovieRequestBody {
					Movie = movie,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(string episodeId, TraktTextEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await PauseEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await PauseEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(string showTitle, int? showYear, int seasonNumber, int episodeNumber, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await PauseEpisodeAsync(TraktEpisodeFactory.FromSeasonAndEpisodeNumber(seasonNumber, episodeNumber), TraktShowFactory.FromTitleAndYear(showTitle, showYear), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is paused. The playback progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		///     Unpause a video by calling the start method again.
		/// </summary>
		/// <param name="episode">The episode</param>
		/// <param name="show">The show</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> PauseEpisodeAsync(TraktEpisode episode, TraktShow show, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktScrobblePauseEpisodeRequest(Client) {
				RequestBody = new TraktScrobbleEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(string movieId, TraktTextMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StopMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(int movieId, TraktNumericMovieIdType movieIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StopMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(string movieTitle, int? movieYear, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StopMovieAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="movie">The movie</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleMovieResponse> StopMovieAsync(TraktMovie movie, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktScrobbleStopMovieRequest(Client) {
				RequestBody = new TraktScrobbleMovieRequestBody {
					Movie = movie,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(string episodeId, TraktTextEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StopEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StopEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(string showTitle, int? showYear, int seasonNumber, int episodeNumber, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await StopEpisodeAsync(TraktEpisodeFactory.FromSeasonAndEpisodeNumber(seasonNumber, episodeNumber), TraktShowFactory.FromTitleAndYear(showTitle, showYear), progress, appVersion, appDate, extended);

		/// <summary>
		///     Use this method when the video is stopped or finishes playing on its own. If the progress is above 80%, the video
		///     will be scrobbled and the action will be set to scrobble.
		///     If the progress is less than 80%, it will be treated as a pause and the action will be set to pause. The playback
		///     progress will be saved and
		///     <see cref="TraktSyncModule.GetPlaybackStateAsync" /> can be used to resume the video from this exact position.
		/// </summary>
		/// <param name="episode">The episode</param>
		/// <param name="show">The show</param>
		/// <param name="progress">The user's current playback progress through this item as a percentage between 0 and 100</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktScrobbleEpisodeResponse> StopEpisodeAsync(TraktEpisode episode, TraktShow show, float progress, string appVersion = "", DateTime? appDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktScrobbleStopEpisodeRequest(Client) {
				RequestBody = new TraktScrobbleEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Progress = progress,
					AppVersion = appVersion,
					AppDate = appDate
				},
				Extended = extended
			});

	}

}