namespace day2;

enum Options
{
    Rock, Paper, Scissors
}

abstract class Choice
{
    public abstract Options Option { get; }
    public abstract int Value { get; }

    public abstract Dictionary<Options, int> Score { get; }
}

class RockChoice : Choice
{
    public override Options Option => Options.Rock;
    public override int Value => 1;

    public override Dictionary<Options, int> Score => new() { { Options.Rock, 3 }, { Options.Paper, 0 }, { Options.Scissors, 6 } };
}

class PaperChoice : Choice
{
    public override Options Option => Options.Paper;
    public override int Value => 2;
    public override Dictionary<Options, int> Score => new() { { Options.Rock, 6 }, { Options.Paper, 3 }, { Options.Scissors, 0 } };
}

class ScissorsChoice : Choice
{
    public override Options Option => Options.Scissors;
    public override int Value => 3;
    public override Dictionary<Options, int> Score => new() { { Options.Rock, 0 }, { Options.Paper, 6 }, { Options.Scissors, 3 } };
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

    public int Score => MyChoice.Score[OpponentChoice.Option] + MyChoice.Value;
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
        Options option = outcomeChar switch
        {
            'X' => this.Make(choiceChar).Score.Single(x => x.Value == 6).Key,
            'Y' => this.Make(choiceChar).Score.Single(x => x.Value == 3).Key,
            'Z' => this.Make(choiceChar).Score.Single(x => x.Value == 0).Key,
            _ => throw new ArgumentException("nope")
        };
        return this.MakeByOption(option);
    }

    private Choice MakeByOption(Options option)
    {
        return option switch
        {
            Options.Rock => new RockChoice(),
            Options.Paper => new PaperChoice(),
            Options.Scissors => new ScissorsChoice(),
            _ => throw new ArgumentException("nope")
        };
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
        rounds = lines.Select(x => new Round(factory.Make(x[0], x[2]), factory.Make(x[0]))).ToList();
        Console.WriteLine(rounds.Sum(x => x.Score));
    }
}
