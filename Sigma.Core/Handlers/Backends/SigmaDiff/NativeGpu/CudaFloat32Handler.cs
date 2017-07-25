﻿/* 
MIT License

Copyright (c) 2016-2017 Florian Cäsar, Michael Plainer

For full license see LICENSE in the root directory of this project. 
*/

using System;
using Sigma.Core.Data;
using Sigma.Core.MathAbstract;
using Sigma.Core.MathAbstract.Backends.SigmaDiff.NativeGpu;
using Sigma.Core.Utils;

namespace Sigma.Core.Handlers.Backends.SigmaDiff.NativeGpu
{
	public class CudaFloat32Handler : DiffSharpFloat32Handler
	{
		private CudaFloat32BackendHandle _cudaBackendHandle;

		public CudaFloat32Handler(int deviceId = 0) : base(new CudaFloat32BackendHandle(deviceId, backendTag: -1))
		{
			_cudaBackendHandle = (CudaFloat32BackendHandle) DiffsharpBackendHandle;
		}

		/// <summary>The underlying data type processed and used in this computation handler.</summary>
		public override IDataType DataType { get; }

		/// <summary>
		/// Called after this object was de-serialised. 
		/// </summary>
		public override void OnDeserialised()
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override void InitAfterDeserialisation(INDArray array)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override long GetSizeBytes(params INDArray[] array)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override bool IsInterchangeable(IComputationHandler otherHandler)
		{
			return this.GetType() == otherHandler.GetType();
		}

		/// <inheritdoc />
		public override INDArray NDArray(params long[] shape)
		{
			long backendTag = _cudaBackendHandle.BackendTag;

			return AssignTag(new CudaFloat32NDArray(backendTag, new CudaSigmaDiffDataBuffer<float>(ArrayUtils.Product(shape), backendTag, _cudaBackendHandle.CudaContext), shape));
		}

		/// <inheritdoc />
		public override INDArray NDArray<TOther>(TOther[] values, params long[] shape)
		{
			long backendTag = _cudaBackendHandle.BackendTag;
			float[] convertedValues = new float[values.Length];
			Type floatType = typeof(float);

			for (int i = 0; i < values.Length; i++)
			{
				convertedValues[i] = (float)System.Convert.ChangeType(values[i], floatType);
			}

			return AssignTag(new CudaFloat32NDArray(backendTag, new CudaSigmaDiffDataBuffer<float>(convertedValues, backendTag, _cudaBackendHandle.CudaContext), shape));
		}

		/// <inheritdoc />
		public override INumber Number(object value)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override IDataBuffer<T> DataBuffer<T>(T[] values)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override INDArray AsNDArray(INumber number)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override INumber AsNumber(INDArray array, params long[] indices)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override bool CanConvert(INDArray array, IComputationHandler otherHandler)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override INDArray Convert(INDArray array, IComputationHandler otherHandler)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override void Fill(INDArray filler, INDArray arrayToFill)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override void Fill(INDArray filler, INDArray arrayToFill, long[] sourceBeginIndices, long[] sourceEndIndices, long[] destinationBeginIndices, long[] destinationEndIndices)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override void Fill<T>(T[] filler, INDArray arrayToFill, long[] destinationBeginIndices, long[] destinationEndIndices)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public override void Fill<TOther>(TOther value, INDArray arrayToFill)
		{
			throw new NotImplementedException();
		}
	}
}
