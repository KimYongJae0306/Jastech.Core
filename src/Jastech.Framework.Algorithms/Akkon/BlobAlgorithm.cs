using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Framework.Algorithms.Akkon
{
    public class BlobAlgorithm
    {
        int m_DataType = 0;
        int m_OriginType = 0;
        int m_MaxLine = 0;
        int m_MaxBlob = 0;
        int m_MaxIndex = 0;
        STLINE[] m_aPtrLine;
        STBLOB[] m_aPtrBlob;
        STINDEX[] m_aPtrIndex;
        ushort[] m_aMap;
        bool[] m_bRegBlobSeed;

        int m_ImgWidth;
        int m_ImgHeight;
        int m_StepWidth;
        int m_ByteDepth;

        int m_RoiLeft;
        int m_RoiTop;
        int m_RoiRight;
        int m_RoiBottom;
        ushort m_NumBlob = 0;
        int m_NumLine = 0;
        ushort m_NumIndex = 0;
        public bool Create(int maxline, int maxblob, int maxindex, int datatype, int origin)
        {
            m_DataType = datatype;
            m_OriginType = origin;

            m_MaxLine = maxline;
            m_MaxBlob = maxblob;
            m_MaxIndex = maxindex;

            m_aPtrLine = new STLINE[m_MaxLine];
            for (int i = 0; i < m_MaxLine; i++)
                m_aPtrLine[i] = new STLINE();

            if (m_aPtrLine.Count() == 0)
                return false;

            m_aPtrBlob = new STBLOB[m_MaxBlob];
            for (int i = 0; i < m_MaxBlob; i++)
                m_aPtrBlob[i] = new STBLOB();
            if (m_aPtrBlob.Count() == 0)
                return false;

            m_aPtrIndex = new STINDEX[m_MaxIndex];
            for (int i = 0; i < m_MaxIndex; i++)
                m_aPtrIndex[i] = new STINDEX();

            if (m_aPtrIndex.Count() == 0)
                return false;

            //m_aMap = new ushort[m_MaxIndex];
            //for (int i = 0; i < m_MaxIndex; i++)
            //    m_aMap[i] = new ushort();

            //if (m_aMap.Count() == 0)
            //    return false;

            m_bRegBlobSeed = new bool[m_MaxBlob];
            for (int i = 0; i < m_MaxBlob; i++)
                m_bRegBlobSeed[i] = new bool();

            if (m_bRegBlobSeed.Count() == 0)
                return false;

            return true;
        }

        public void SetImgInfo(int width, int height, int byteDepth, int stepwidth)
        {
            m_ImgWidth = width;
            m_ImgHeight = height;
            m_StepWidth = stepwidth;
            m_ByteDepth = byteDepth;
        }

        public void SetRoi(int left, int top, int right, int bottom)
        {
            m_RoiLeft = left;
            m_RoiTop = top;
            m_RoiRight = right;
            m_RoiBottom = bottom;

            m_RoiLeft = ((m_RoiLeft < 0 || m_RoiLeft > m_ImgWidth) ? 0 : m_RoiLeft);
            m_RoiTop = ((m_RoiTop < 0 || m_RoiTop > m_ImgHeight) ? m_ImgHeight : m_RoiTop);
            m_RoiRight = ((m_RoiRight < 0 || m_RoiRight > m_ImgWidth) ? m_ImgWidth : m_RoiRight);
            m_RoiBottom = ((m_RoiBottom < 0 || m_RoiBottom > m_ImgHeight) ? 0 : m_RoiBottom);
        }

        public void BlobScan(IntPtr ptr)
        {
            ExtractLine(ptr);
            IndexLine();
            LabelBlobObj();
        }

        private unsafe void ExtractLine(IntPtr ptr)
        {
            int x, y;
            int MaxVal = 0;
            MPoint ptMaxValTmp = new MPoint();

            m_NumLine = 0;

            byte* pData = (byte*)ptr;
            byte* pBuf = null;
            int index = 0;
            for (y = m_RoiTop; y < m_RoiBottom; y++)
            {
                x = m_RoiLeft;
				pBuf = pData + (y * m_StepWidth) + x;

                index = 0;
                while (x < m_RoiRight)
                {
                    if (*pBuf > 0)
                    {
                        m_aPtrLine[m_NumLine].Y = (short)y;
                        m_aPtrLine[m_NumLine].X1 = (short)x;
                        MaxVal = *pBuf;
                        ptMaxValTmp.X = x;
                        ptMaxValTmp.Y = y;


                        while (*pBuf > 0 && x < m_RoiRight)
                        {
                            if (MaxVal < *pBuf)
                            {
                                MaxVal = *pBuf;
                                ptMaxValTmp.X = x;
                                ptMaxValTmp.Y = y;
                            }

                            pBuf++;
                            x++;
                        }

                        m_aPtrLine[m_NumLine].MaxVal = MaxVal;
                        m_aPtrLine[m_NumLine].MaxValPoint.X = ptMaxValTmp.X;
                        m_aPtrLine[m_NumLine].MaxValPoint.Y = ptMaxValTmp.Y;

                        m_aPtrLine[m_NumLine].X2 = (short)x;
                        m_aPtrLine[m_NumLine].Index = 0;  

                        m_NumLine++;
                            if (m_NumLine >= m_MaxLine)
                                return;//return BLOBERR_MAXLINE;
                    }
                    else
                    {
                        pBuf++;
                        x++;
                    }
                }
            }
        }

        private void IndexLine()
        {
            //memset((void*)m_aPtrIndex, 0, sizeof(STINDEX) * m_MaxIndex);
           
            bool bNew = false;
            int i, j, k, indi, indj, pti, ptj;
            m_NumIndex = 1;
            m_aPtrLine[0].Index = m_NumIndex++;
            for (i = 1; i < m_NumLine; i++)
            {
                for (k = i - 1; k >= 0 && (m_aPtrLine[k].Y > m_aPtrLine[i].Y - 2); k--)
                    bNew = true;

                for (j = k; j < i; j++)
                {
                    if (j < 0)          // 2008.09.04  k=-1인 경우가 발생하기 때문에 m_aPtrLine[-1].index처럼 배열을 음수로 인덱싱 하는 경우가 발생하고, 
                        continue;       // 아래의 while loop에서 무한 loop에 빠질 가능성이 있어서 추가한 코드임 

                    if (m_aPtrLine[i].Y - 1 != m_aPtrLine[j].Y)
                        continue;

                    if (m_aPtrLine[j].X2 >= m_aPtrLine[i].X1 && m_aPtrLine[j].X1 <= m_aPtrLine[i].X2)
                    {
                        indi = m_aPtrLine[i].Index;
                        indj = m_aPtrLine[j].Index;
                        if (bNew)
                        {
                            m_aPtrLine[i].Index = (ushort)indj;
                            bNew = false;
                        }
                        else if (indi < indj)
                        {
                            if (m_aPtrIndex[indj].LinkPtr == 0)
                            {
                                m_aPtrIndex[indj].LinkPtr = (ushort)indi;
                            }
                            else
                            {
                                ptj = m_aPtrIndex[indj].LinkPtr;
                                while (ptj < m_MaxIndex && m_aPtrIndex[ptj].LinkPtr > 0 && ptj != m_aPtrIndex[ptj].LinkPtr) ptj = m_aPtrIndex[ptj].LinkPtr;

                                if (m_aPtrIndex[indi].LinkPtr == 0)
                                {
                                    pti = indi;
                                }
                                else
                                {
                                    pti = m_aPtrIndex[indi].LinkPtr;
                                    while (pti < m_MaxIndex && m_aPtrIndex[pti].LinkPtr > 0 && pti != m_aPtrIndex[pti].LinkPtr) pti = m_aPtrIndex[pti].LinkPtr;
                                }
                                if (pti < ptj)
                                {
                                    m_aPtrIndex[ptj].LinkPtr = (ushort)indi;
                                }
                                else if (pti > ptj)
                                {
                                    m_aPtrIndex[pti].LinkPtr = (ushort)indj;
                                }
                            }
                        }
                        else if (indi > indj)
                        {
                            if (m_aPtrIndex[indi].LinkPtr == 0)
                            {
                                m_aPtrIndex[indi].LinkPtr = (ushort)indj;
                            }
                            else
                            {
                                pti = m_aPtrIndex[indi].LinkPtr;
                                while (pti < m_MaxIndex && m_aPtrIndex[pti].LinkPtr > 0 && pti != m_aPtrIndex[pti].LinkPtr) pti = m_aPtrIndex[pti].LinkPtr;

                                if (m_aPtrIndex[indj].LinkPtr == 0)
                                {
                                    ptj = indj;
                                }
                                else
                                {
                                    ptj = m_aPtrIndex[indj].LinkPtr;
                                    while (ptj < m_MaxIndex && m_aPtrIndex[ptj].LinkPtr > 0 && ptj != m_aPtrIndex[ptj].LinkPtr)
                                        ptj = m_aPtrIndex[ptj].LinkPtr;
                                }
                                if (pti < ptj)
                                {
                                    m_aPtrIndex[ptj].LinkPtr = (ushort)indi;
                                }
                                else if (pti > ptj)
                                {
                                    m_aPtrIndex[pti].LinkPtr = (ushort)indj;
                                }
                            }
                        }
                    }
                }
                if (bNew)
                    m_aPtrLine[i].Index = m_NumIndex++;

                if (m_NumIndex >= m_MaxIndex)
                    return;// return BLOBERR_MAXINDEX;
            }
        }

        private void LabelBlobObj()
        {
            int i, pt;
            m_NumBlob = 1;
            int numIndex = 0;
            bool bMaxBlob = false;

            for (i = 1; i < m_NumIndex; i++)
            {
                if (m_aPtrIndex[i].LinkPtr == 0)
                {
                    m_aPtrIndex[i].Label = m_NumBlob++;
                    if (m_NumBlob >= m_MaxBlob)
                    {
                        numIndex = i;
                        bMaxBlob = true;
                        break;
                    }

                }
            }

            for (i = 1; i < m_NumIndex; i++)
            {
                if (m_aPtrIndex[i].LinkPtr == 0) continue;
                pt = m_aPtrIndex[i].LinkPtr;
                while (pt < m_MaxIndex && m_aPtrIndex[pt].LinkPtr > 0 && pt != m_aPtrIndex[pt].LinkPtr) pt = m_aPtrIndex[pt].LinkPtr;
                m_aPtrIndex[i].Label = m_aPtrIndex[pt].Label;
            }

            if (bMaxBlob)
                return;// return BLOBERR_MAXBLOB;
            else
                return;// BLOBERR_NONE;
        }

        public void ExtractBlob()
        {
            int i, lbl;
            int pBlobDataX1 = 0, pBlobDataX2 = 0;


            for (i = 0; i < m_NumBlob; i++)
            {
                m_aPtrBlob[i].Top = 65000;
                m_aPtrBlob[i].Bottom = 0;
                m_aPtrBlob[i].Left = 65000;
                m_aPtrBlob[i].Right = 0;
                m_aPtrBlob[i].PixelSize = 0;
                m_aPtrBlob[i].Sx = 0;
                m_aPtrBlob[i].Sy = 0;
                m_aPtrBlob[i].CenterOfMass.X = 0;
                m_aPtrBlob[i].CenterOfMass.Y = 0;
                m_aPtrBlob[i].MaxVal = 0;
                m_aPtrBlob[i].MaxValPoint.X = 0;
                m_aPtrBlob[i].MaxValPoint.Y = 0;
            }

            double Sx = 0, Sy = 0, Sxx = 0, Syy = 0, Sxy = 0;

            for (i = 0; i < m_NumLine; i++)
            {
                lbl = m_aPtrIndex[m_aPtrLine[i].Index].Label;
                if (!m_bRegBlobSeed[lbl])
                {
                    m_aPtrBlob[lbl].Seed.X = m_aPtrLine[i].X1;
                    m_aPtrBlob[lbl].Seed.Y = m_aPtrLine[i].Y;
                    m_bRegBlobSeed[lbl] = true;
                }

                if (m_aPtrBlob[lbl].Top > m_aPtrLine[i].Y)
                    m_aPtrBlob[lbl].Top = (ushort)m_aPtrLine[i].Y;
                if (m_aPtrBlob[lbl].Bottom < m_aPtrLine[i].Y)
                    m_aPtrBlob[lbl].Bottom = (ushort)m_aPtrLine[i].Y;
                if (m_aPtrBlob[lbl].Left > m_aPtrLine[i].X1)
                    m_aPtrBlob[lbl].Left = (ushort)m_aPtrLine[i].X1;
                if (m_aPtrBlob[lbl].Right < m_aPtrLine[i].X2)
                    m_aPtrBlob[lbl].Right = (ushort)m_aPtrLine[i].X2;

                m_aPtrBlob[lbl].PixelSize += (ulong)(m_aPtrLine[i].X2 - m_aPtrLine[i].X1);

                if (m_aPtrBlob[lbl].MaxVal < m_aPtrLine[i].MaxVal)
                {
                    m_aPtrBlob[lbl].MaxVal = m_aPtrLine[i].MaxVal;
                    m_aPtrBlob[lbl].MaxValPoint = m_aPtrLine[i].MaxValPoint;

                }

                pBlobDataX1 = m_aPtrLine[i].X1;
                pBlobDataX2 = m_aPtrLine[i].X2 - 1;

                m_aPtrBlob[lbl].Sx += (uint)(((pBlobDataX2 + pBlobDataX1) * ((pBlobDataX2 - pBlobDataX1) + 1)) / 2);
                m_aPtrBlob[lbl].Sy += (uint)(m_aPtrLine[i].Y * ((pBlobDataX2 + 1) - pBlobDataX1));
            }
        }

        public ushort GetBlobCount()
        {
            return m_NumBlob;
        }
        public STBLOB GetBlob(int index)
        {
            if (index < m_NumBlob && m_aPtrBlob[index].PixelSize > 0)
            {
                m_aPtrBlob[index].CenterOfMass.X = (int)(m_aPtrBlob[index].Sx / m_aPtrBlob[index].PixelSize);
                m_aPtrBlob[index].CenterOfMass.Y = (int)(m_aPtrBlob[index].Sy / m_aPtrBlob[index].PixelSize);

                return m_aPtrBlob[index];
            }
            else
                return null;
        }
    }

    public class STLINE
    {
        public short Y;
        public short X1;
        public short X2;
        public ushort Index;
        public float MaxVal;
        public MPoint MaxValPoint = new MPoint();
    }

    public class STBLOB
    {
        public ushort Top;
        public ushort Bottom;
        public ushort Left;
        public ushort Right;
        public ulong PixelSize;
        public MPoint Seed = new MPoint();// Blob 영역의 한점
        public MPoint CenterOfMass = new MPoint();
        public uint Sx;
        public uint Sy;
        public float MaxVal;
        public MPoint MaxValPoint = new MPoint();
    }

    public class STINDEX
    {
        public ushort LinkPtr;
        public ushort Label;
        public ushort Check;
    }

    public class MPoint
    {
        public int X;
        public int Y;
    }
}
