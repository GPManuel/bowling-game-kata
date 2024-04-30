namespace BowlingGame;

public class Game
{
    public int PinsByRound = 10;
    public int RollsByRound = 2;
    private readonly List<Round> _rounds;

    public Game()
    {
        _rounds = [new Round(PinsByRound, RollsByRound)];
    }

    public void Roll(int pinsKnocked)
    {
        if (_rounds.Last().PinsLeft() - pinsKnocked < 0) throw new NoPinsLeftException();
        //if (ThereAreNoBowlingPinsLeft(pinsKnocked)) return;
        PlayRoll(pinsKnocked);

        if (_rounds.Last().RollsLeft() == 0)
        {
            _rounds.Add(new Round(PinsByRound, RollsByRound));
        }

        if (_rounds.Count > 1 && _rounds[^2].PinsLeft() == 0)
        {
            _rounds[^2].AddExtraRound(_rounds[^2].RollsLeft() + 1);
        }
    }

    private bool ThereAreNoBowlingPinsLeft(int pinsKnocked)
    {
        return _rounds.Last().PinsLeft() + pinsKnocked >= PinsByRound;
    }

    public int Score()
    {
        return _rounds.Sum(x => x.GetRoundScore());
    }

    private void PlayRoll(int pinsKnocked)
    {
        foreach (var round in _rounds.Where(x => x.IsRoundActive()))
        {
            round.Roll(pinsKnocked);
        }
    }
}