using System.Globalization;

namespace YouCanHaveANumberBetween
{
	internal class Program
	{
		// In spite of https://discord.com/channels/283467363729408000/586931790208434203/1215647840886587432
		static string defaultDateFormat = "{0}-{1}-{2}-{3}-{4}-{5}"; // DD-MM-YYYY-HH-MM-SS

		static void Main(string[] args)
		{
			string dateformat = defaultDateFormat;

			if (args.Length < 2)
			{
				using (FileStream fs = File.OpenWrite($"./{GenerateDateString(dateformat, DateTime.Now)}.txt"))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						sw.WriteLine("Hmm? Looks like you're either trying to open the .exe by hand, or you're running it without arguments.");
						sw.WriteLine("To use this program, you open the command line within this direction,");
						sw.WriteLine("then write the name of this program, and leave a whitespace, then put in 2 numbers.");
						sw.WriteLine("The first number will be the smallest number you can randomly get, and the second number is the largest.");
						sw.WriteLine("");
						sw.WriteLine("Like so:");
						sw.WriteLine(@"C:\Program>YouCanHaveANumberBetween 1 100");
						sw.WriteLine("And this will create a text file in the same direction that will give you the output.");
						sw.WriteLine("There are some .bat files packed in the same .zip folder as this .exe file, and you can open them with notepad");
						sw.WriteLine("to see some examples. Now you know who to ask!");
						sw.Close();
					}
				}
				return;
			}

			bool usedouble = false;

			if (args.Length >= 4)
			{
				if (!bool.TryParse(args[3], out usedouble))
				{
					using (FileStream fs = File.OpenWrite($"./{GenerateDateString(dateformat, DateTime.Now)}.txt"))
					{
						using (StreamWriter sw = new StreamWriter(fs))
						{
							sw.WriteLine($"ERROR");
							sw.WriteLine($"Couldn't parse Double option");
							sw.Close();
						}
					}
					return;
				}
			}

			if (args.Length >= 3)
				dateformat = args[2];

			int min, max;
			double min_d, max_d;

			bool mins = int.TryParse(args[0], out min);
			bool maxs = int.TryParse(args[1], out max);
			bool mins_d = double.TryParse(args[0], CultureInfo.InvariantCulture, out min_d);
			bool maxs_d = double.TryParse(args[1], CultureInfo.InvariantCulture, out max_d);

			if (((!mins || !maxs) && !usedouble) || ((!mins_d || !maxs_d) && usedouble))
			{
				using (FileStream fs = File.OpenWrite($"./{GenerateDateString(dateformat, DateTime.Now)}.txt"))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						sw.WriteLine("ERROR");
						sw.WriteLine("Couldn't parse one of the numbers");
						sw.Close();
					}
				}
				return;
			}

			int seed = 0;
			bool seedinput = false;

			if (args.Length >= 5)
			{
				seedinput = true;
				if (!int.TryParse(args[4], out seed))
				{
					using (FileStream fs = File.OpenWrite($"./{GenerateDateString(dateformat, DateTime.Now)}.txt"))
					{
						using (StreamWriter sw = new StreamWriter(fs))
						{
							sw.WriteLine($"ERROR");
							sw.WriteLine($"Couldn't parse seed");
							sw.Close();
						}
					}
					return;
				}
			}

			Random rng = seedinput ? new Random(seed) : new Random();
			int randvalue = rng.Next(min, max);
			double randvalue_d = min_d + rng.NextDouble() * (max_d - min_d);

			using (FileStream fs = File.OpenWrite($"./{GenerateDateString(dateformat, DateTime.Now)}.txt"))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					sw.WriteLine($"Generated a random {(usedouble ? "decimal" : "integer")} value between {(usedouble ? min_d.ToString(CultureInfo.InvariantCulture) : min)} and {(usedouble ? max_d.ToString(CultureInfo.InvariantCulture) : max)}");
					sw.WriteLine($"Returned {(usedouble ? randvalue_d.ToString(CultureInfo.InvariantCulture) : randvalue)}");
					sw.Close();
				}
			}
		}

		static string GenerateDateString(string format, DateTime date)
		{
			string padLeftConv(int num, int width, char c = '0')
			{
				return num.ToString().PadLeft(width, c);
			}

			return string.Format(format,
				padLeftConv(date.Day, 2), padLeftConv(date.Month, 2), padLeftConv(date.Year, 4), 
				padLeftConv(date.Hour, 2), padLeftConv(date.Minute, 2), padLeftConv(date.Second, 2));
		}
	}
}