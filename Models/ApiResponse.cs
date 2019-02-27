using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Integration.ReCaptcha.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public DateTime ChallengeTs { get; set; }

        public string Hostname { get; set; }

        [JsonProperty("error-codes")]
        public string[] ErrorCodes { get; set; }
    }
}
