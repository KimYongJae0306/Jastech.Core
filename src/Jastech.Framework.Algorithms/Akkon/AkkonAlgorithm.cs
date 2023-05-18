using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Jastech.Framework.Algorithms.Akkon.Parameters;
using Jastech.Framework.Imaging.Ipp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon
{
    public partial class AkkonAlgorithm
    {
        public void Run(byte[] sourceData, int width, int height, AkkonParameters parameters)
        {
            int overLap = 10;
            // 기존 marcon Filter2 =>(sigma : 2, gusWidth : 8, logWidth : 16, scaleFactor : 1.3)
            AkkonFilterParam filterParam = GenerateFilter(2.0, 8, 16, 1.3);

            // EnhanceY
            IntPtr src16Ptr = IntPtr.Zero;
            IntPtr dst16Ptr = IntPtr.Zero;
            int src16step = width * sizeof(short);
            int dst16step = width * sizeof(short);

            try
            {
                src16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out src16step); // 16비트 메모리 할당
                dst16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out dst16step); // 16비트 메모리 할당

                short[] src16_Data = new short[width * height];
                short[] dst16_Data = new short[width * height];
                Marshal.Copy(src16Ptr, src16_Data, 0, width * height);
                Marshal.Copy(dst16Ptr, dst16_Data, 0, width * height);

                IPPWrapper.ippiScale_8u16s_C1R(sourceData, width, src16_Data, src16step, width, height, 0.0, -128);
            }
            finally
            {
                if (src16Ptr != IntPtr.Zero)
                    IPPWrapper.ippiFree(src16Ptr);
                if (dst16Ptr != IntPtr.Zero)
                    IPPWrapper.ippiFree(dst16Ptr);
            }
        }

        //public void Run(byte[] sourceData, int width, int height, AkkonParameters parameters)
        //{
        //    int overLap = 10;
        //    // 기존 marcon Filter2 =>(sigma : 2, gusWidth : 8, logWidth : 16, scaleFactor : 1.3)
        //    AkkonFilterParam filterParam = GenerateFilter(2.0, 8, 16, 1.3);

        //    // EnhanceY
        //    IntPtr src16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int src16step); // 16비트 메모리 할당
        //    IntPtr dst16Ptr = IPPWrapper.ippiMalloc_16s_C1(width, height, out int dst16step); // 16비트 메모리 할당

        //    short[] src16_Data = new short[src16step * height];
        //    short[] dst16_Data = new short[dst16step * height];
        //    Marshal.Copy(src16Ptr, src16_Data, 0, src16step * height);
        //    Marshal.Copy(dst16Ptr, dst16_Data, 0, dst16step * height);

        //    //IntPtr src8Ptr = IPPWrapper.ippiMalloc_8u_C1(width, height, out int src8step);

        //    IPPWrapper.ippiScale_8u16s_C1R(sourceData, width, src16_Data, src16step, width, height, 0.0, -128);



        //    IPPWrapper.ippiFree(src16Ptr);
        //    IPPWrapper.ippiFree(dst16Ptr);

        //    //IPPWrapper.ippiScale_8u16s_C1R(sourceData, src8step, src16Ptr,)
        //    //int dst16Size = width * height;
        //    //short[] dst16Data = new short[dst16Size];
        //    //Marshal.Copy(dst16Data, 0, dst16Ptr, dst16Data.Length); // dst16Ptr 에 데이터 Copy
        //    //IppiSize size = new IppiSize(width, height);
        //    ////IPPWrapper.ippiScale_8u16s_C1R(sourceData, srcStep, dst16Data, dstStep, width, height, 0.0, -128); // 8Bit->16Bit로 변경
        //    //IPPWrapper.ippiScale_8u16s_C1R(sourcePtr, srcStep, dst16Ptr, dstStep, new IppiSize(width, height), 0.0, -128); // 8Bit->16Bit로 변경

        //    #region SepConv16s_rowfirst

        //    #region calc...
        //    int sizerow = 0;
        //    int sizecol = 0;
        //    int i = 0;
        //    int maxKernelSize = (filterParam.GusSize > filterParam.LogSize) ? filterParam.GusSize : filterParam.LogSize;

        //    int nc = filterParam.LogSize;
        //    int nr = filterParam.GusSize;

        //    // compute the kernel semisizes
        //    int ncss = nc >> 1;
        //    int nrss = nr >> 1;

        //    // compute the kernel offsets (0 -> odd, 1 -> even)
        //    int co = 1 - (nc % 2);
        //    int ro = 1 - (nr % 2);

        //    IppiSize tempSize = new IppiSize();
        //    tempSize.Width = width;
        //    tempSize.Height = height + nc + 1;

        //    int tempStep = 0;
        //    IntPtr ptemp = IPPWrapper.ippiMalloc_16s_C1(tempSize.Width, tempSize.Height, out tempStep);
        //    #endregion
        //    int pilelRowSize = 0;
        //    int pilelColumSize = 0;
        //    int status = IPPWrapper.ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(tempSize, nr, out pilelRowSize);
        //    status = IPPWrapper.ippiFilterColumnPipelineGetBufferSize_16s_C1R(tempSize, nc, out pilelColumSize);

        //    nrss -= ro;
        //    ncss -= co;

    

        //    IntPtr pSrc = Marshal.AllocHGlobal(height + nc + 1);
        //    IntPtr nDst = Marshal.AllocHGlobal(height);

        //    IppiSize sourceSize = new IppiSize();
        //    sourceSize.Width = width;
        //    sourceSize.Height = height;

        //    //IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R()
        //    //IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(sourceData, srcStep, destData, dstStep, sourceSize, IntPtr.Zero, Inptr.ze)
        //    #endregion
        //    //SepConv16s_rowfirst(sourceData, filterParam, new Size(width, height));

        //    //SepConv16s_rowfirst(filterParam, )

        //    IPPWrapper.ippiFree(src16Ptr);
        //    IPPWrapper.ippiFree(dst16Ptr);
        //}

        private void SepConv16s_rowfirst(byte[] sourceData, int sourceStep, ref byte[] destData, int destStep, AkkonFilterParam filterParam, Size imageSize)
        {
            //int sizerow = 0;
            //int sizecol = 0;
            //int i = 0;
            //int maxKernelSize = (filterParam.GusSize > filterParam.LogSize) ? filterParam.GusSize : filterParam.LogSize;

            //int nc = filterParam.LogSize;
            //int nr = filterParam.GusSize;

            //// compute the kernel semisizes
            //int ncss = nc >> 1;
            //int nrss = nr >> 1;

            //// compute the kernel offsets (0 -> odd, 1 -> even)
            //int co = 1 - (nc % 2);
            //int ro = 1 - (nr % 2);

            //IppiSize tempSize = new IppiSize();
            //tempSize.Width = imageSize.Width;
            //tempSize.Height = imageSize.Height + nc + 1;

            //int pilelRowSize = 0;
            //int pilelColumSize = 0;

            //int status = IPPWrapper.ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(tempSize, nr, out pilelRowSize);
            //status = IPPWrapper.ippiFilterColumnPipelineGetBufferSize_16s_C1R(tempSize, nc, out pilelColumSize);

            //nrss -= ro;
            //ncss -= co;

            //int tempStep = 0;
            //IntPtr ptemp = IPPWrapper.ippiMalloc_16s_C1(imageSize.Width, imageSize.Height, out tempStep);

            //IntPtr pSrc = Marshal.AllocHGlobal(imageSize.Height + nc + 1);
            //IntPtr nDst = Marshal.AllocHGlobal(imageSize.Height);

            //IppiSize sourceSize = new IppiSize();
            //sourceSize.Width = imageSize.Width;
            //sourceSize.Height = imageSize.Height;


            //IPPWrapper.ippiFilterRowBorderPipeline_16s_C1R(sourceData, sourceStep, destData, dstStep, sourceSize, IntPtr.Zero, Inptr.ze)
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
