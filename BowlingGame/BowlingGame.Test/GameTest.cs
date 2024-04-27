using FluentAssertions;
using NUnit.Framework;

namespace BowlingGame.Test;

public class GameTest
{
    private Game _game;

    [SetUp]
    public void SetUp()
    {
        _game = new Game();
    }

    [Test]
    public void roll_one_and_not_knocks_down_all_pins()
    {
        _game.Roll(7);

        _game.Score().Should().Be(7);
    }
}