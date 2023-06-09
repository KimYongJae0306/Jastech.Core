﻿using Jastech.Framework.Device.Motions;

namespace Jastech.Framework.Device.LAFCtrl
{
    public class VirtualLAFCtrl : LAFCtrl
    {
        public VirtualLAFCtrl(string name) : base(name)
        {
        }

        public override bool Initialize()
        {
            return true;
        }

        public override bool Release()
        {
            return true;
        }

        public override bool IsConnected()
        {
            return true;
        }

        public override void SetMotionRelativeMove(AxisMovingParam.Direction direction, double value)
        {
            
        }

        public override void SetMotionAbsoluteMove(double value)
        {

        }

        public override void SetMotionNegativeLimit(double value)
        {
            
        }

        public override void SetMotionPositiveLimit(double value)
        {
            
        }

        public override void SetMotionMaxSpeed(double value)
        {
            
        }

        public override void SetMotionZeroSet()
        {
            
        }

        public override void SetMotionStop()
        {

        }

        public override void SetCenterOfGravity(int value)
        {
            
        }
    }
}
