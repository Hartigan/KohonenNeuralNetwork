using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
	public class Neuron
	{
		public Link[] IncomingLinks { get; set; }

		public double Power { get; set; }
	}
}
