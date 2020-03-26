using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BusyBee.Models
{
    public class FacebookEvents
    {
        [JsonProperty("data")]
        public List<FacebookEvent> Items { get; set; }
    }

    public class FacebookEvent
    {
        //[JsonProperty("id")]
        //public int Id { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("place")]
        public FacebookPlace Place { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rsvp_status")]
        public string RSVPStatus { get; set; } = string.Empty;

        [JsonProperty("event_times")]
        public List<FacebookEventTime> EventTimes { get; set; }

    }

    public class FacebookEventTime
    {
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class FacebookPlace
    {
        //[JsonProperty("id")]
        //public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public FacebookLocation Location { get; set; }
    }

    public class FacebookLocation
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; } = 0;

        [JsonProperty("latitude")]
        public double Latitude { get; set; } = 0;

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

    }
}
