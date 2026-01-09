using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureReplayAbwehren {
    internal class HighScoreToken {
        public int HighestScore { get; set; }
        public Guid Nonce { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
