namespace BowlingGame;

public class Game
{
    private int _totalPoints;

    public void Roll(int pinsKnocked)
    {
        _totalPoints += pinsKnocked;
    }

    public int Score()
    {
        return _totalPoints;
    }
}