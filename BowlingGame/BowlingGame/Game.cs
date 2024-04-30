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

    public int Score()
    {
        return _rounds.Sum(x => x.GetRoundScore());
    }

    public void Roll(int pinsKnocked)
    {
        if (NotEnoughBowlingPins(pinsKnocked)) throw new NoPinsLeftException();
        PlayRoll(pinsKnocked);
        if (_rounds.Last().PinsLeft() == 0)
        {
            _rounds.Last().AddExtraRound(_rounds.Last().RollsLeft() + 1);
            StartNewRound();
            return;
        }
        IfNoRollsLeftThenStartNewRound();
    }

    private bool NotEnoughBowlingPins(int pinsKnocked)
    {
        return _rounds.Last().PinsLeft() - pinsKnocked < 0;
    }

    private void StartNewRound()
    {
        _rounds.Add(new Round(PinsByRound, RollsByRound));
    }

    private void IfNoRollsLeftThenStartNewRound()
    {
        if (_rounds.Last().RollsLeft() == 0)
        {
            StartNewRound();
        }
    }

    private void PlayRoll(int pinsKnocked)
    {
        foreach (var round in _rounds.Where(x => x.IsRoundActive()))
        {
            round.Roll(pinsKnocked);
        }
    }
}