using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Imaging.Ipp
{
    public static class IPPWrapper
    {
        [DllImport("ippi.dll", CallingConvention = CallingConvention.Cdecl)] // 16비트 부호 있는 정수 형식의 이미지 데이터를 위한 메모리를 할당하는 기능
        public static extern IntPtr ippiMalloc_16s_C1(int width, int height, out int step);

        [DllImport("ippi.dll", CallingConvention = CallingConvention.Cdecl)]// 8비트 부호 없는 정수 형식의 이미지 데이터를 위한 메모리를 할당하는 기능
        public static extern IntPtr ippiMalloc_8u_C1(int width, int height, out int step);

        [DllImport("ippi.dll", CallingConvention = CallingConvention.Cdecl)] // 8비트 부호 없는 정수 이미지를 16비트 부호 있는 정수 이미지로 스케일링하고 데이터 형식을 변환하는 기능
        public static extern int ippiScale_8u16s_C1R(IntPtr pSrc, int srcStep, IntPtr pDst, int dstStep, IppiSize roiSize);
        //public static extern int ippiScale_8u16s_C1R(byte[] pSrc, int srcStep, short[] pDst, int dstStep, int roiSize, double scaleFactor, int shift);

        [DllImport("ippi.dll")] // 16비트 signed integer 형식의 1채널 이미지를 8비트 unsigned integer 형식으로 스케일링하는 함수
        public static extern int ippiScale_16s8u_C1R(short[] pSrc, int srcStep, byte[] pDst, int dstStep, IppiSize roiSize, double scale, short shift);

        [DllImport("ippcv.dll")] // 이미지의 가로 방향(row)에 대해 경계(border) 처리를 포함한 필터링 연산을 수행할 때 필요한 버퍼의 크기를 반환
        public static extern int ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(IppiSize roiSize, int kernelSize, out int bufferSize);

        [DllImport("ippcv.dll")] // 이미지의 세로 방향(column)에 대해 적용되는 필터링 연산을 수행할 때 필요한 버퍼의 크기를 반환
        public static extern int ippiFilterColumnPipelineGetBufferSize_16s_C1R(IppiSize roiSize, int kernelSize, out int bufferSize);

        [DllImport("ippi.dll")] // 16비트 signed integer 형식의 1채널 이미지에 대해 상수 값을 더하는 함수
        public static extern int ippiAddC_16s_C1IRSfs(short value, short[] pSrcDst, int srcDstStep, IppiSize roiSize, int scaleFactor);




        [DllImport("ippcv.dll")]
        public static extern int ippiFilterRowBorderPipelineInit_16s_C1R(short[] pKernel,int kernelSize,int anchor, IppiBorderType borderType,byte[] pBuffer);

        [DllImport("ipps.dll")] // 8비트 unsigned integer 형식의 메모리를 할당
        public static extern IntPtr ippsMalloc_8u(int length);

        [DllImport("ippcore.dll")] // 16비트 부호 있는 정수(16s) 형식의 메모리 버퍼를 동적으로 할당
        public static extern IntPtr ippsMalloc_16s(int length);

        [DllImport("ippcv.dll")]
        private static extern int ippiFilterRowBorderPipeline_16s_C1R(
        IntPtr pSrc, int srcStep, IntPtr pDst, int dstStep,
        int dstRoiSize, IntPtr pKernel, int kernelSize,
        int anchor, IntPtr pBorderValues);

        [DllImport("ippcv.dll")] // 16비트 signed integer 형식의 1채널 이미지에 대해 가로 방향 필터링을 수행하는 함수
        public static extern int ippiFilterRowBorderPipeline_16s_C1R(IntPtr pSrc, int srcStep, IntPtr[] ppDst,
                                                                    IppiSize roiSize, IntPtr pKernel, int kernelSize, int xAnchor,
                                                                    int borderType, short borderValue, int divisor, IntPtr pBuffer);
        //public static extern int ippiFilterRowBorderPipeline_16s_C1R(IntPtr pSrc, int srcStep, IntPtr pDst, int dstStep, 
        //                                                                IppiSize roiSize, IntPtr pKernel, int kernelSize,
        //                                                                int anchor, int divisor, int borderType, int borderValue);


        [DllImport("ippcv.dll")] // 16비트 signed integer 형식의 1채널 이미지에 대해 세로 방향 필터링을 수행하는 함수
        public static extern int ippiFilterColumnPipeline_16s_C1R(IntPtr pSrc, int srcStep, IntPtr pDst, int dstStep, IppiSize roiSize, IntPtr pSpec, IntPtr pBuffer, int bufferSize);


        [DllImport("ippcore.dll")] // 16비트 부호 있는 정수(16s) 형식의 이미지 컬럼에 대해 파이프라인 형태로 필터링을 수행
        public static extern int ippiFilterColumnPipeline_16s_C1R(short[] pSrc, int srcStep, short[] pDst, int dstStep, IppiSize roiSize, IntPtr pSpec, IntPtr pState, int scaleFactor);

        [DllImport("ippi.dll")]
        public static extern void ippiFree(IntPtr ptr);


        public static short[] IppiMalloc_16s_C1(int width, int height, out int step)
        {
            IntPtr ptr = ippiMalloc_16s_C1(width, height,out step);
            short[] data = new short[step * height];
            Marshal.Copy(ptr, data, 0, step * height);

            ippiFree(ptr);

            return data;
        }

        public static byte[] IppsMalloc_8u(int length)
        {
            IntPtr ptr = ippsMalloc_8u(length);

            byte[] data = new byte[length];
            Marshal.Copy(ptr, data, 0, length);

            ippiFree(ptr);

            return data;
        }

        public static int FilterRowBorderPipeline(short[] src, int srcStep, short[] dst, int dstStep,
       int dstRoiSize, short[] kernel, int kernelSize, int anchor, int[] borderValues)
        {
            // Pin the managed arrays in memory
            GCHandle srcHandle = GCHandle.Alloc(src, GCHandleType.Pinned);
            GCHandle dstHandle = GCHandle.Alloc(dst, GCHandleType.Pinned);
            GCHandle kernelHandle = GCHandle.Alloc(kernel, GCHandleType.Pinned);
            GCHandle borderValuesHandle = GCHandle.Alloc(borderValues, GCHandleType.Pinned);

            try
            {
                // Get the IntPtr pointers to the pinned arrays
                IntPtr pSrc = srcHandle.AddrOfPinnedObject();
                IntPtr pDst = dstHandle.AddrOfPinnedObject();
                IntPtr pKernel = kernelHandle.AddrOfPinnedObject();
                IntPtr pBorderValues = borderValuesHandle.AddrOfPinnedObject();

                // Call the IPP function
                int result = ippiFilterRowBorderPipeline_16s_C1R(
                    pSrc, srcStep, pDst, dstStep, dstRoiSize, pKernel, kernelSize, anchor, pBorderValues);

                return result;
            }
            finally
            {
                // Release the pinned arrays
                srcHandle.Free();
                dstHandle.Free();
                kernelHandle.Free();
                borderValuesHandle.Free();
            }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IppiSize
    {
        public int Width;  // 이미지의 너비
        public int Height; // 이미지의 높이

        public IppiSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public enum IppiBorderType
    {
        ippBorderConst = 0,   // 경계를 상수 값으로 처리
        ippBorderRepl = 1,    // 경계를 이미지의 가장자리 값으로 복제
        ippBorderWrap = 2,    // 경계를 이미지의 반대편 가장자리 값으로 처리
        ippBorderMirror = 3,  // 경계를 이미지의 가장자리 값으로 대칭 복사
        ippBorderMirrorR = 4  // 경계를 이미지의 가장자리 값으로 대칭 복사(미러 링 상태)
    }
}
