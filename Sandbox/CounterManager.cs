public class CounterManager
{
    public CounterManager(params Counter[] counters)
    {
        Counters = new List<Counter>(counters);
    }
    public List<Counter> Counters { get; set; }

    public int Total() => Counters.Sum(i => i.Count);
    public double TotalPercentage() => Counters.Sum(i => i.GetPercent(Total())); 
    public void AnnounceWinner()
    {
        var excess = Math.Round(100 - TotalPercentage(), 2);

        Console.WriteLine($"Excess: {excess}");
        
        var biggestAmountOfVotes = Counters.Max(i => i.Count);

        var winners = Counters.Where(c => c.Count == biggestAmountOfVotes).ToList();

        if(winners.Count() == 1)
        {
            var winner = winners[0];
            winner.AddExcess(excess);
            Console.WriteLine($"{winner.Name} Won!");
        }
        else 
        {
            if(winners.Count != Counters.Count)
            {
                var lowestAmountOfVotes = Counters.Min(i => i.Count);

                var loser = Counters.First(c => c.Count == biggestAmountOfVotes);
                loser.AddExcess(excess);
            }

            Console.WriteLine($"{string.Join(" -DRAW- ", winners.Select(i => i.Name))}");            
        }

        foreach (var counter in Counters)
        {
            Console.WriteLine($"{counter.Name}: {counter.Count}, Percentage: {Math.Round(counter.GetPercent(Total()), 2)}%");
        }

        Console.WriteLine($"Total Percentage: {Math.Round(TotalPercentage(), 2)}%");
    }   
}