using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaptureReplayAbwehren {
    internal class TokenValidator {
        Dictionary<Guid, DateTime> tokens = new Dictionary<Guid, DateTime>();
        private const int maxAccepableTime = 5;
        public bool ValidateToken(HighScoreToken token) {
            if (tokens.ContainsKey(token.Nonce)) {
                CreateFailedLog("Already Contains Token");
                return false;
            }

            double tokenAge = (DateTime.UtcNow - token.CreationTime).TotalSeconds;

            if (tokenAge > maxAccepableTime || tokenAge < -2) {
                CreateFailedLog("No");
                return false;
            }

            tokens.Add(token.Nonce, token.CreationTime);
            PruningStrategie();
            return true;
        }

        private void CreateFailedLog(string method) {
            string path = "HallOfMoron.csv";
            Random rand = new Random();
            using (StreamWriter sw = new StreamWriter(path, append: true)) {
                sw.WriteLine($"{DateTime.UtcNow}|{$"172.17.242.{rand.Next(10, 200)}"}| {method}");
            }
        }

        public void PruningStrategie() {
            foreach (var token in tokens) {
                if (token.Value < DateTime.UtcNow.AddSeconds(-maxAccepableTime)) {
                    tokens.Remove(token.Key);
                }
            }
        }
    }
}
