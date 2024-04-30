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
    public void roll_twice_rounds_throwing_all_the_pins_in_the_second_roll_of_the_first_round()
    {
        _game.Roll(7);
        _game.Roll(3);
        _game.Roll(7);
        _game.Roll(1);

        _game.Score().Should().Be(25);
    }

    [Test]
    public void roll_one_round_and_knocks_down_more_pins_than_exist()
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