namespace day1.part2;

class Elf
{
    private List<int> Calories;

    public Elf(List<int> calories)
    {
        this.Calories = calories;
    }

    public int SumCalories => this.Calories.Sum();
}

interface IInputParser<T>
{
    List<T> Parse();
}

class ElfInputParser : IInputParser<Elf>
{
    private string FilePath;

    public ElfInputParser(string filePath)
    {
        this.FilePath = filePath;
    }

    public List<Elf> Parse()
    {
        string text = File.ReadAllText(this.FilePath);
        List<string> lines = text.Split("\n\n").ToList();
        return lines.Select(x => new Elf(x.Split("\n").Where(y => !string.IsNullOrWhiteSpace(y)).Select(y => int.Parse(y)).ToList())).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IInputParser<Elf> parser = new ElfInputParser("../day1input");
        List<Elf> elves = parser.Parse();
        int result = elves.OrderByDescending(x => x.SumCalories).Take(3).Sum(x => x.SumCalories);
        Console.WriteLine(result);
    }
}
