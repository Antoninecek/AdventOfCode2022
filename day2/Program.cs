namespace day2;

enum Options
{
    Rock, Paper, Scissors
}

abstract class Choice
{
    public abstract Options Option { get; }
    public abstract int Value { get; }

    public abstract int Score(Choice choice);
}

class RockChoice : Choice
{
    public override Options Option => Options.Rock;
    public override int Value => 1;
    public override int Score(Choice choice)
    {
        return choice.Option switch
        {
            Options.Rock => 3,
            Options.Paper => 0,
            Options.Scissors => 6,
            _ => throw new ArgumentException("nope")
        };
    }
}

class PaperChoice : Choice
{
    public override Options Option => Options.Paper;
    public override int Value => 2;
    public override int Score(Choice choice)
    {
        return choice.Option switch
        {
            Options.Rock => 6,
            Options.Paper => 3,
            Options.Scissors => 0,
            _ => throw new ArgumentException("nope")
        };
    }
}

class ScissorsChoice : Choice
{
    public override Options Option => Options.Scissors;
    public override int Value => 3;
    public override int Score(Choice choice)
    {
        return choice.Option switch
        {
            Options.Rock => 0,
            Options.Paper => 6,
            Options.Scissors => 3,
            _ => throw new ArgumentException("nope")
        };
    }
}

class Round
{
    private Choice MyChoice;
    private Choice OpponentChoice;

    public Round(Choice myChoice, Choice opponentChoice)
    {
        this.MyChoice = myChoice;
        this.OpponentChoice = opponentChoice;
    }

    public int Score => MyChoice.Score(OpponentChoice) + MyChoice.Value;
}

class ChoiceFactory
{
    public Choice Make(char choiceChar)
    {
        return choiceChar switch
        {
            'A' or 'X' => new RockChoice(),
            'B' or 'Y' => new PaperChoice(),
            'C' or 'Z' => new ScissorsChoice(),
            _ => throw new ArgumentException("nope")
        };
    }

    public Choice Make(char choiceChar, char outcomeChar)
    {
        // return outcomeChar switch
        // {
        //     'X' => this.Make(choiceChar).Score
        // }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("../day2input");

        // PART 1
        ChoiceFactory factory = new();
        List<Round> rounds = lines.Select(x => new Round(factory.Make(x[2]), factory.Make(x[0]))).ToList();
        Console.WriteLine(rounds.Sum(x => x.Score));

        // PART 2

    }
}
