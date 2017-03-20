﻿using Sigma.Core.Handlers;
using Sigma.Core.MathAbstract;

namespace Sigma.Core.Monitors.WPF.Panels
{
	public interface IInputPanel 
	{
		IComputationHandler handler { get; set; }
		INDArray Values { get; }
	}
}