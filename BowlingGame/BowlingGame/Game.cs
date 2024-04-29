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
        if (_rounds.Last().PinsLeft() - pinsKnocked >= PinsByRound) return;
        foreach (var round in _rounds.Where(x => x.IsRoundActive()))
        {
            round.Roll(pinsKnocked);
        }

        if (_rounds.Last().RollsLeft() == 0)
        {
            _rounds.Add(new Round(PinsByRound, RollsByRound));
        }

        if (_rounds.Count > 1 && _rounds[^2].PinsLeft() == 0)
        {
            _rounds[^2].AddExtraRound(_rounds[^2].RollsLeft() + 1);
        }
    }

    public int Score()
    {
        return _rounds.Sum(x => x.GetRoundScore());
    }
}

public class Round(int pins, int rolls)
{
    private int _roundScore;
    private bool IsActiveRound => rolls > 0 ;

    public void Roll(int pinsKnocked)
    {
        pins -= pinsKnocked;
        rolls--;
        _roundScore += pinsKnocked;
    }

    public void AddExtraRound(int extraRolls)
    {
        rolls += extraRolls;
    }

    public bool IsRoundActive()
    {
        return IsActiveRound;
    }

    public int PinsLeft()
    {
        return pins;
    }

    public int RollsLeft()
    {
        return rolls;
    }

    public int GetRoundScore()
    {
        return _roundScore;
    }
}