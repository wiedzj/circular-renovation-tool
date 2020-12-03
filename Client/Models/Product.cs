using System;
using Newtonsoft.Json;

namespace BuildingFutureCities
{
	public class Product
	{
		public double EmbodiedEnergy { get; set; }
		public double EmbodiedCO2 { get; set; }
		public int Category { get; }
		public int Durability { get; set; }
		public int Releasability { get; set; }

		public Product(int category)
		{
			Category = category;
		}

		[JsonConstructor] // Tell JSON which constructor to use
		public Product(double embodiedEnergy, double embodiedCO2, int category)
		{
			EmbodiedEnergy = embodiedEnergy;
			EmbodiedCO2 = embodiedCO2;
			Category = category;

		}
	}
}
