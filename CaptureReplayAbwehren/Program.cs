using CaptureReplayAbwehren;

HighScoreToken token1 = new HighScoreToken() {
    HighestScore = 8888,
    Nonce = Guid.NewGuid(),
    CreationTime = DateTime.UtcNow,
};
HighScoreToken token2 = new HighScoreToken() {
    HighestScore = 1001,
    Nonce = Guid.NewGuid(),
    CreationTime = DateTime.UtcNow,
};
HighScoreToken token3 = new HighScoreToken() {
    HighestScore = 5055,
    Nonce = Guid.NewGuid(),
    CreationTime = DateTime.UtcNow.AddSeconds(-500),
};


TokenValidator validator = new TokenValidator();

Console.WriteLine(validator.ValidateToken(token1));
Console.WriteLine(validator.ValidateToken(token1));
Console.WriteLine(validator.ValidateToken(token2));
Console.WriteLine(validator.ValidateToken(token3));