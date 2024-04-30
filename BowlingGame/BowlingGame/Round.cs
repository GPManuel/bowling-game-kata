namespace BowlingGame;

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