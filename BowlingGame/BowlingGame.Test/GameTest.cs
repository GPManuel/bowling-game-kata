using FluentAssertions;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
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
    public void roll_once_and_not_knocks_down_all_pins()
    {
        _game.Roll(7);

        _game.Score().Should().Be(7);
    }

    [Test]
    public void roll_once_and_knocks_down_all_pins()
    {
        _game.Roll(10);

        _game.Score().Should().Be(10);
    }

    [Test]
    public void get_bonus_from_next_roll_when_make_a_spare()
    {
        _game.Roll(7);
        _game.Roll(3);
        _game.Roll(7);
        _game.Roll(1);

        _game.Score().Should().Be(25);
    }

    [Test]
    public void do_not_knocks_down_more_pins_than_exist()
    {
        _game.Roll(8);

        var action = () => _game.Roll(3);

        action.Should().Throw<NoPinsLeftException>();
    }

    //[Test]
    //public void play_11_frames_without_spares_or_strikes()
    //{
    //    _game.Roll(7);

    //    _game.Score().Should().Be(7);
    //}
}