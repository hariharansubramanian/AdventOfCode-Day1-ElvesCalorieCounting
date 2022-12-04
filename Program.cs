Console.WriteLine("Counting calories...");

var calorieEntries = File.ReadLines("calorie_list.txt").ToList();

var elvesCalorieCountList = new List<long>();

long elfCalorieCount = 0;
foreach (var calorieEntry in calorieEntries)
    if (calorieEntry != "")
    {
        elfCalorieCount += long.Parse(calorieEntry);
    }
    else
    {
        elvesCalorieCountList.Add(elfCalorieCount);
        elfCalorieCount = 0;
    }

var elvesCalorieCountListSorted = elvesCalorieCountList.OrderByDescending(x => x).ToList();
var top3Calories = elvesCalorieCountListSorted.Take(3).ToList();
var top3CalorieCount = top3Calories.Sum(x => x);

Console.WriteLine($"The top 3 calories counted are {string.Join(',', top3Calories.Select(x => x))}");
Console.WriteLine($"The total calories counted are {top3CalorieCount}");