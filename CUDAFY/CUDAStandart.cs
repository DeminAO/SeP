using System;
using Cudafy;
using Cudafy.Atomics;
using Cudafy.Compilers;
using Cudafy.DynamicParallelism;
using Cudafy.Host;
using Cudafy.IntegerIntrinsics;
using Cudafy.Maths;
using Cudafy.Rand;
using Cudafy.SIMDFunctions;
using Cudafy.Translator;
using Cudafy.Types;
using Cudafy.WarpShuffleFunctions;

namespace CudaLybrary
{
	public static class CUDAStandart
	{
		private static readonly GPGPU device;

		static CUDAStandart()
		{
			device = CudafyHost.GetDevice(eGPUType.Cuda, 0);
			device.LoadModule(CudafyTranslator.Cudafy());
		}
	}
}
