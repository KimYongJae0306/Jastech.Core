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
        [DllImport("ippi.dll")] // 16비트 부호 있는 정수 형식의 이미지 데이터를 위한 메모리를 할당하는 기능
        public static extern IntPtr ippiMalloc_16s_C1(int width, int height, out int step);

        [DllImport("ippi.dll")] // 8비트 부호 없는 정수 형식의 이미지 데이터를 위한 메모리를 할당하는 기능
        public static extern IntPtr ippiMalloc_8u_C1(int width, int height, out int step);

        [DllImport("ippi.dll")] // 8비트 부호 없는 정수 이미지를 16비트 부호 있는 정수 이미지로 스케일링하고 데이터 형식을 변환하는 기능
        public static extern int ippiScale_8u16s_C1R(byte[] pSrc, int srcStep, short[] pDst, int dstStep,int roiWidth, int roiHeight, double scaleFactor, int shift);

        [DllImport("ippcv.dll")] // 이미지의 가로 방향(row)에 대해 경계(border) 처리를 포함한 필터링 연산을 수행할 때 필요한 버퍼의 크기를 반환
        public static extern int ippiFilterRowBorderPipelineGetBufferSize_16s_C1R(IppiSize roiSize, int kernelSize, out int bufferSize);

        [DllImport("ippcv.dll")] //  이미지의 세로 방향(column)에 대해 적용되는 필터링 연산을 수행할 때 필요한 버퍼의 크기를 반환
        public static extern int ippiFilterColumnPipelineGetBufferSize_16s_C1R(IppiSize roiSize, int kernelSize, out int bufferSize);


        [DllImport("ippcv.dll")]
        public static extern int ippiFilterRowBorderPipelineInit_16s_C1R(short[] pKernel,int kernelSize,int anchor, IppiBorderType borderType,byte[] pBuffer);

        [DllImport("ippcore.dll")] // 6비트 부호 있는 정수(16s) 형식의 메모리 버퍼를 동적으로 할당
        public static extern IntPtr ippsMalloc_16s(int length);




        [DllImport("ippcore.dll")] // 16비트 부호 있는 정수(16s) 형식의 이미지 컬럼에 대해 파이프라인 형태로 필터링을 수행
        public static extern int ippiFilterColumnPipeline_16s_C1R(short[] pSrc, int srcStep, short[] pDst, int dstStep, IppiSize roiSize, IntPtr pSpec, IntPtr pState, int scaleFactor);

        [DllImport("ippi.dll")]
        public static extern void ippiFree(IntPtr ptr);

        
    }
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
