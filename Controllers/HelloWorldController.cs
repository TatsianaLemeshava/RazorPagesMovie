using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace RazorPagesMovie.Controllers
{
	internal class Bacon { }
	internal class Coffee { }
	internal class Egg { }
	internal class Juice { }
	internal class Toast { }

	public class HelloWorldController : Controller
    {
		private string brkf = string.Empty;
		// 
		// GET: /HelloWorld/
		public IActionResult Index()
		{
			return View();
		}
		// 
		// GET: /HelloWorld/Welcome/ 
		public async Task<string> Welcome()
		{
			string welcomeBrkf = await Breakfast();
			return "This is the Welcome action method...\r\n" + welcomeBrkf;
		}

		public async Task<string> Breakfast()
		{
			Task<Coffee> cupTask = PourCoffeeAsync();
			Coffee cup = await cupTask;
			brkf += "Coffee is ready\r\n";
			Task<Bacon> baconTask = FryBaconAsync(3);
			Bacon bac = await baconTask;
			brkf += "Bacon is ready\r\n";
			Task<Egg> eggsTask = FryEggsAsync(2);
			Egg eggs = await eggsTask;
			brkf += "Eggs is ready\r\n";
			return brkf;
		}
		private async Task<Coffee> PourCoffeeAsync()
		{
			brkf += "Pouring coffee\r\n";
			return new Coffee();
		}

		private async Task<Bacon> FryBaconAsync(int slices)
		{
			brkf += $"putting {slices} slices of bacon in the pan\r\n";
			brkf += "cooking first side of bacon...\r\n";
			Task.Delay(300).Wait();
			for (int slice = 0; slice < slices; slice++)
			{
				brkf += "flipping a slice of bacon\r\n";
			}
			brkf += "cooking the second side of bacon...\r\n";
			Task.Delay(3000).Wait();
			Console.WriteLine("Put bacon on plate");

			return new Bacon();
		}

		private async Task<Egg> FryEggsAsync(int howMany)
		{
			brkf += "Warming the egg pan...\r\n";
			Task.Delay(300).Wait();
			brkf += $"cracking {howMany} eggs\r\n";
			Task.Delay(300).Wait();
			brkf += "Put eggs on plate\r\n";

			return new Egg();
		}
	}
}
