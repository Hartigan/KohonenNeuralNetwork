using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Logic
{
	public class KohonenNetwork
	{
		private Input[] _inputs;

		private Neuron[] _neurons;

		public KohonenNetwork(int inputsCount, int neuronsCount)
		{
			_inputs = new Input[inputsCount];
			_neurons = new Neuron[neuronsCount];

			for (int i = 0; i < inputsCount; i++)
			{
				_inputs[i] = new Input();
			}

			for (int i = 0; i < neuronsCount; i++)
			{
				_neurons[i] = new Neuron();
			}

			Init(inputsCount, neuronsCount);
		}

		private void Init(int inputsCount, int neuronsCount)
		{
			foreach (Neuron neuron in _neurons)
			{
				neuron.IncomingLinks = new Link[inputsCount];
			}

			Random rnd = new Random(0);
			for (int i = 0; i < inputsCount; i++)
			{
				Link[] outgoingLinks = new Link[neuronsCount];
				_inputs[i].OutgoingLinks = outgoingLinks;
				for (int j = 0; j < neuronsCount; j++)
				{
					outgoingLinks[j] = new Link();
					outgoingLinks[j].Neuron = _neurons[j];
					outgoingLinks[j].Weight = rnd.NextDouble()/1000;
					_neurons[j].IncomingLinks[i] = outgoingLinks[j];
				}
			}
		}

		public int Handle(int[] input)
		{
			for (int i = 0; i < _inputs.Length; i++)
			{
				Input inputNeuron = _inputs[i];
				foreach (Link outgoingLink in inputNeuron.OutgoingLinks)
				{
					outgoingLink.Neuron.Power += outgoingLink.Weight*input[i];
				}
			}

			int maxIndex = 0;
			for (int i = 1; i < _neurons.Length; i++)
			{
				if (_neurons[i].Power > _neurons[maxIndex].Power)
				{
					maxIndex = i;
				}
			}

			foreach (Neuron outputNeuron in _neurons)
			{
				outputNeuron.Power = 0;
			}

			return maxIndex;
		}

		public void Study(int[] input, int correctAnswer)
		{
			Neuron neuron = _neurons[correctAnswer];
			for (int i = 0; i < neuron.IncomingLinks.Length; i++)
			{
				Link incomingLink = neuron.IncomingLinks[i];
				incomingLink.Weight = incomingLink.Weight + 0.5 * (input[i] - incomingLink.Weight);
			}
		}
	}
}
