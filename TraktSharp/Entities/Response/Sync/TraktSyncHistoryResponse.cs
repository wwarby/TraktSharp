﻿using Newtonsoft.Json;
using System;
using TraktSharp.Enums;

namespace TraktSharp.Entities.Response.Sync
{
    public class TraktSyncHistoryResponse
    {
        public long Id { get; set; }

        [JsonProperty(PropertyName = "watched_at")]
        public DateTimeOffset WatchedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        public TraktWatchingItemType Type { get; set; }

        [JsonProperty(PropertyName = "action")]
        public TraktHistoryAction Action { get; set; }

        public TraktEpisode Episode { get; set; }
        public TraktSeason Season { get; set; }
        public TraktShow Show { get; set; }
        public TraktMovie Movie { get; set; }

        public override string ToString()
        {
            return $"{Show.Title} - {Episode.Title}: {WatchedAt.LocalDateTime.ToString()}";
        }
    }
}