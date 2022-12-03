namespace day3;
class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("../day3input");
        int sum = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string a = new string(lines[i].Substring(0, lines[i].Length / 2).Distinct().ToArray());
            string b = new string(lines[i].Substring((lines[i].Length / 2)).Distinct().ToArray());

            for (int j = 0; j < a.Length; j++)
            {
                if (b.Contains(a[j]))
                {
                    int val = (int)a[j];
                    if (97 <= val && val <= 122) val -= 96;
                    if (65 <= val && val <= 90) val -= 38;
                    sum += val;
                    continue;
                }
            }
        }

        Console.WriteLine(sum);
    }
}
