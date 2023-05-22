using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Imaging.Helper;
using Jastech.Framework.Imaging.Ipp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon
{
    public partial class AkkonAlgorithm
    {
        public void Test()
        {
         
        }
        public void Run(IntPtr srcPoint, int width, int height, AkkonParameters parameters)
        {
            // 기존 marcon Filter2 =>(sigma : 2, gusWidth : 8, logWidth : 16, scaleFactor : 1.3)
            AkkonFilterParam filterParam = GenerateFilter(2.0, 8, 16, 1.3);

            unsafe
            {
                IntPtr src16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int src16step); // 16비트 메모리 할당
                IntPtr dst16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int dst16step); // 16비트 메모리 할당

                int result = IPPWrapper.ippiScale_8u16s_C1R(srcPoint, width, src16Ptr, src16step, new IppiSize(width, height));

                short[] t = new short[width * height];
                Marshal.Copy(src16Ptr, t, 0, t.Length);
                byte[] rawData = new byte[t.Length * sizeof(short)];
                Buffer.BlockCopy(t, 0, rawData, 0, rawData.Length);

                string filePath = @"D:\123.raw";
                File.WriteAllBytes(filePath, rawData);


                // ppDst 배열 설정
                IntPtr[] ppDst = new IntPtr[height];
                for (int i = 0; i < height; i++)
                {
                    ppDst[i] = srcPoint + i * width * sizeof(short);
                }
                short[] kernel = new short[] { -1, 0, 1 };
                IntPtr kernelPtr = Marshal.AllocHGlobal(kernel.Length * sizeof(short));

                // short[] 배열의 데이터를 IntPtr로 복사
                Marshal.Copy(kernel, 0, kernelPtr, kernel.Length);
                int kernelSize = kernel.Length;
                int xAnchor = kernelSize / 2;
                int borderType = 0;  
                short borderValue = 0;
                IppiSize roiSize = new IppiSize(width, height);

                try
                {
                    //int g123 = IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(src16Ptr, width, ppDst, roiSize, kernelPtr, kernelSize, xAnchor, 1, borderValue, 0, IntPtr.Zero);
                }
                catch (Exception err)
                {

                    throw;
                }
                
            }

        }
        //public void Run(byte[] sourceData, int width, int height, AkkonParameters parameters)
        //{
        //    // 기존 marcon Filter2 =>(sigma : 2, gusWidth : 8, logWidth : 16, scaleFactor : 1.3)
        //    AkkonFilterParam filterParam = GenerateFilter(2.0, 8, 16, 1.3);

        //    // EnhanceY
        //    IntPtr src16Ptr = IntPtr.Zero;
        //    IntPtr dst16Ptr = IntPtr.Zero;
        //    int src16dataSize = height * width * sizeof(short);
        //    int src16step = width * sizeof(short);
        //    int dst16step = width * sizeof(short);

        //    try
        //    {
        //        //src16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out src16step); // 16비트 메모리 할당
        //        //dst16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out dst16step); // 16비트 메모리 할당

        //        short[] src16_Data = new short[width * height];

        //        int result = IPPWrapper.ippiScale_8u16s_C1R(sourceData, width, src16_Data, src16step, new IppiSize(width, height));
        //        if (result != 0)
        //            return;

        //        result = IPPWrapper.ippiAddC_16s_C1IRSfs(-128, src16_Data, src16step, new IppiSize(width, height), 0);
        //        if (result != 0)
        //            return;
        //        //Test();
        //        SepConv16s_rowfirst(src16_Data, src16step, new IppiSize(width, height), filterParam);
        //        //SepConv16s_rowfirst(src16Ptr, src16step,ref dst16Ptr, dst16step, new IppiSize(width, height), filterParam);


        //        //short[] dst16_Data = new short[width * height];
        //        //Marshal.Copy(dst16Ptr, dst16_Data, 0, width * height);

        //        //IntPtr dst8Ptr = IPPWrapper.ippsMalloc_8u(width * height);
        //        //byte[] dst8Array = new byte[width * height];
        //        //Marshal.Copy(dst8Ptr, dst8Array, 0, dst8Array.Length);

        //        //IPPWrapper.ippiScale_16s8u_C1R(src16_Data, src16step, dst8Array, 0, new IppiSize(width, height), 1.0, 128);

        //        //Mat mat = MatHelper.ByteArrayToMat(dst8Array, width, height, 1);
        //        //mat.Save(@"D:\123.bmp");

        //    }
        //    finally
        //    {
        //        if (src16Ptr != IntPtr.Zero)
        //            IPPWrapper.ippiFree(src16Ptr);
        //        if (dst16Ptr != IntPtr.Zero)
        //            IPPWrapper.ippiFree(dst16Ptr);
        //    }
        //}
        private void SepConv16s_rowfirst(short[] src16DataArray, int src16Step, IppiSize orgSize, AkkonFilterParam filterParam)
        {
            int sizerow = 0;
            int sizecol = 0;
            int i = 0;
            int maxKernelSize = (filterParam.GusSize > filterParam.LogSize) ? filterParam.GusSize : filterParam.LogSize;

            int nc = filterParam.LogSize;
            int nr = filterParam.GusSize;

            // compute the kernel semisizes
            int ncss = nc >> 1;
            int nrss = nr >> 1;

            // compute the kernel offsets (0 -> odd, 1 -> even)
            int co = 1 - (nc % 2);
            int ro = 1 - (nr % 2);

            IppiSize tempSize = new IppiSize();
            tempSize.Width = orgSize.Width;
            tempSize.Height = orgSize.Height + nc + 1;
            IntPtr tempPtr = IPPWrapper.ippiMalloc_16s_C1(tempSize.Width, tempSize.Height, out int tempStep);

            IntPtr ppSrc = IPPWrapper.ippsMalloc_8u((orgSize.Height + nc + 1) * 8); // sizeof(Ipp16s*) = 8
            //IntPtr ppDst = IPPWrapper.ippsMalloc_8u(orgSize.Height * 8);

            int status = IPPWrapper.ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(orgSize, nr, out int rowBufferSize);
            status = IPPWrapper.ippiFilterColumnPipelineGetBufferSize_16s_C1R(orgSize, nc, out int colBufferSize);

            IntPtr pBufferRow = IPPWrapper.ippsMalloc_8u(rowBufferSize);
            IntPtr pBufferCol = IPPWrapper.ippsMalloc_8u(colBufferSize);

            nrss -= ro;
            ncss -= co;

            unsafe
            {
                IntPtr source = Marshal.AllocHGlobal(src16DataArray.Length * sizeof(short));
                Marshal.Copy(src16DataArray, 0, source, src16DataArray.Length);

                IntPtr[] ppDst = new IntPtr[orgSize.Height];

                for (int h = 0; h < orgSize.Height; h++)
                {
                    ppDst[h] = source + h * orgSize.Width * sizeof(short);
                }

                IntPtr kernel = Marshal.AllocHGlobal(filterParam.GusKernel.Length * sizeof(short));
                Marshal.Copy(filterParam.GusKernel, 0, kernel, filterParam.GusKernel.Length);
                int kernelSize = filterParam.GusSize;
                int xAnchor = kernelSize / 2;// nrss;
                int scrStep = tempStep;
                int divisor = (int)filterParam.GusDivisor;
                int result = IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(source, orgSize.Width * sizeof(short), 
                    ppDst, orgSize, IntPtr.Zero, kernelSize, xAnchor, 0, 0, divisor, IntPtr.Zero);

            }







            //int re = IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(arrayPtr, tempStep, arrayPtr, tempStep, orgSize
            //    , kernel, kernelSize, nrss, (int)filterParam.GusDivisor, 1, 0);

        }

        private void SepConv16s_rowfirst(IntPtr src16Ptr, int src16Step, ref IntPtr dst16Ptr, int dst16Step, IppiSize orgSize, AkkonFilterParam filterParam)
        {
            int sizerow = 0;
            int sizecol = 0;
            int i = 0;
            int maxKernelSize = (filterParam.GusSize > filterParam.LogSize) ? filterParam.GusSize : filterParam.LogSize;

            int nc = filterParam.LogSize;
            int nr = filterParam.GusSize;

            // compute the kernel semisizes
            int ncss = nc >> 1;
            int nrss = nr >> 1;

            // compute the kernel offsets (0 -> odd, 1 -> even)
            int co = 1 - (nc % 2);
            int ro = 1 - (nr % 2);

            IppiSize tempSize = new IppiSize();
            tempSize.Width = orgSize.Width;
            tempSize.Height = orgSize.Height + nc + 1;

            IntPtr tempPtr = IPPWrapper.ippiMalloc_16s_C1(tempSize.Width, tempSize.Height, out int tempStep);

            //IntPtr ppSrc = IPPWrapper.ippsMalloc_8u((orgSize.Height + nc + 1) * 8);// sizeof(Ipp16s*) = 8
            //IntPtr ppDst = IPPWrapper.ippsMalloc_8u(orgSize.Height * 8); // sizeof(Ipp16s*) = 8

            // size of temporary buffers
            int status = IPPWrapper.ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(orgSize, nr, out int rowBufferSize);
            status = IPPWrapper.ippiFilterColumnPipelineGetBufferSize_16s_C1R(orgSize, nc, out int colBufferSize);

            IntPtr pBufferRow = IPPWrapper.ippsMalloc_8u(rowBufferSize);
            IntPtr pBufferCol = IPPWrapper.ippsMalloc_8u(colBufferSize);

            nrss -= ro;
            ncss -= co;

            IntPtr[] ppDst = new IntPtr[orgSize.Height];
            IntPtr[] ppSrc = new IntPtr[orgSize.Height + nc + 1];

            for (int ii = 0, jj = ncss; ii < orgSize.Height; ++ii, ++jj)
            {
                ppDst[ii] = IntPtr.Add(tempPtr, jj * orgSize.Width * sizeof(short));
                ppSrc[jj] = IntPtr.Add(tempPtr, jj * orgSize.Width * sizeof(short));

                Console.WriteLine("ppSrc: {0}  ppDst: {1}", ppSrc[jj], ppDst[ii]);
            }

            for (int ii = 0, jj = orgSize.Height + ncss; ii < ncss; ii++, jj++)
            {
                ppSrc[ii] = ppSrc[ncss];
                ppSrc[jj] = ppSrc[orgSize.Height + ncss - 1];
            }

            if (co != 0)
            {
                ppSrc[orgSize.Height + (ncss * 2)] = ppSrc[orgSize.Height + ncss - 1];
            }

            IntPtr pKernel = Marshal.AllocHGlobal(filterParam.GusKernel.Length * sizeof(short));
            Marshal.Copy(filterParam.GusKernel, 0, pKernel, filterParam.GusKernel.Length);


            //status = IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R
            //    (src16Ptr, src16Step, ppDst[0], tempStep, orgSize.Width * 2, pKernel, filterParam.GusSize, nrss, (int)filterParam.GusDivisor, 1, 0 
            //    );
            
        }

        private AkkonFilterParam GenerateFilter(double sigma, int gusWidth, int logWidth, double scaleFactor)
        {
            double s_lfGusFltPeak = 71;
            double s_lfLOGFltPeak = 50;

            int gusAnc = gusWidth / 2;

            short[] gusKernel = new short[gusWidth];
            short[] pGUS = new short[gusWidth];

            double scale = Math.Abs(s_lfGusFltPeak / Gaussian(0.0, sigma));
            double gusSum = 0;

            for (int i = 0; i < gusWidth; i++)
            {
                int x = i - gusAnc;
                double val = Gaussian(x, sigma) * scale;
                pGUS[i] = (short)(val + (val >= 0 ? 0.5 : -0.5));
                gusSum += pGUS[i];
            }

            // flip
            for (int i = 0; i < gusWidth; i++)
            {
                gusKernel[i] = pGUS[gusWidth - i - 1];
            }

            // Log
            scale = Math.Abs(s_lfLOGFltPeak / LOG(0.0, sigma));
          
            int logAnc = logWidth / 2;

            short[] pLOG = new short[logWidth];
            short[] logKernel = new short[logWidth];

            double logSum = 0;
            for (int i = 0; i < logWidth; i++)
            {
                int x = i - logAnc;
                double val = -1.0 * LOG(x, sigma) * scale * scaleFactor;
                pLOG[i] = (short)(val + (val >= 0 ? 0.5 : -0.5));
                logSum += pLOG[i];
            }
            // flip
            for (int i = 0; i < logWidth; i++)
            {
                logKernel[i] = pLOG[logWidth - i - 1];
            }

            if (logSum > 0)
            {
                if ((logWidth % 2) == 0)
                    logAnc--;  // because of 'flip'

                double ancValue = logKernel[logAnc];
                logKernel[logWidth - 1] = (short)(logKernel[logWidth - 1] - logSum);
            }

            AkkonFilterParam filterParam = new AkkonFilterParam();
            filterParam.GusSize = gusWidth;
            filterParam.GusDivisor = gusSum;
            filterParam.GusKernel = gusKernel;

            filterParam.LogSize = logWidth;
            filterParam.LogDivisor = 32;
            filterParam.LogKernel = logKernel;

            return filterParam;
        }

        private double Gaussian(double x, double sigma)
        {
            return (1.0 / (Math.Sqrt(Math.PI * 2) * sigma) * Math.Exp(-x * x / (2.0 * sigma * sigma)));
        }

        double LOG(double x, double sigma)
        {
            double t;

            t = x * x / (sigma * sigma);
            return (1.0 / (Math.Sqrt(Math.PI * 2) * sigma * sigma * sigma) * (t - 1.0) * Math.Exp(t / -2.0));
        }
    }

   public class AkkonFilterParam
    {
        public int GusSize { get; set; }

        public double GusDivisor { get; set; }

        public short[] GusKernel { get; set; }

        public int LogSize { get; set; }

        public double LogDivisor { get; set; }

        public short[] LogKernel { get; set; }
    }
}
