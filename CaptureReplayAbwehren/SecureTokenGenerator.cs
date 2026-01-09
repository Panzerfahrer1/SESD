using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureReplayAbwehren {
    internal class SecureTokenGenerator {
        void GenerateScoreToken(int score) {
            HighScoreToken token = new HighScoreToken();
            token.HighestScore = score;
            token.Nonce = Guid.NewGuid();
            token.CreationTime = DateTime.UtcNow;
        }
    }
}
