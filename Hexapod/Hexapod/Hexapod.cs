﻿using System;
using System.Collections.Generic;

namespace Hexapod
{
    public class Hexapod
    {
        public double PlatformRadius { get; set; }
        public double PlatformHeight { get; set; }
        public double CardanRadius { get; set; }
        public double CardanHeight { get; set; }
        public double CardanLocationRadius { get; set; }
        public double CardanAngle { get; set; }
        public double RailsRadius { get; set; }
        public double RailsMinLength { get; set; }
        public double RailsMaxLength { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public Point E { get; set; }
        public Point F { get; set; }
        public Position StartPosition { get; set; }
        public Position FinishPosition { get; set; }
        public Track Track { get; set; }

        public void SetParameters(MainForm mainForm)
        {
            PlatformRadius = Convert.ToInt32(mainForm.uiPlatformRadiusTextBox.Text);
            PlatformHeight = Convert.ToInt32(mainForm.uiPlatformHeightTextBox.Text);
            CardanAngle = Convert.ToInt32(mainForm.uiCardanAngleTextBox.Text);
            CardanHeight = Convert.ToInt32(mainForm.uiCardanHeightTextBox.Text);
            CardanRadius = Convert.ToInt32(mainForm.uiCardanRadiusTextBox.Text);
            CardanLocationRadius = Convert.ToInt32(mainForm.uiCardanToCenterLenghtTextBox.Text);
            RailsRadius = Convert.ToInt32(mainForm.uiRailsRadiusTextBox.Text);
            RailsMinLength = Convert.ToInt32(mainForm.uiRailsMinLengthTextBox.Text);
            RailsMaxLength = Convert.ToInt32(mainForm.uiRailsMaxLengthTextBox.Text);
            StartPosition = new Position
                                {
                                    Center = new Point
                                                 {
                                                     X = Convert.ToInt32(mainForm.uiStartPositionX0TextBox.Text),
                                                     Y = Convert.ToInt32(mainForm.uiStartPositionY0TextBox.Text),
                                                     Z = Convert.ToInt32(mainForm.uiStartPositionZ0TextBox.Text)
                                                 },
                                    Fi = Convert.ToInt32(mainForm.uiStartPositionFiTextBox.Text),
                                    Theta = Convert.ToInt32(mainForm.uiStartPositionThetaTextBox.Text),
                                    Psi = Convert.ToInt32(mainForm.uiStartPositionPsiTextBox.Text),
                                };
            FinishPosition = new Position
                                 {
                                     Center = new Point
                                                  {
                                                      X = Convert.ToInt32(mainForm.uiFinishPositionX0TextBox.Text),
                                                      Y = Convert.ToInt32(mainForm.uiFinishPositionY0TextBox.Text),
                                                      Z = Convert.ToInt32(mainForm.uiFinishPositionZ0TextBox.Text)
                                                  },
                                     Fi = Convert.ToInt32(mainForm.uiFinishPositionFiTextBox.Text),
                                     Theta = Convert.ToInt32(mainForm.uiFinishPositionThetaTextBox.Text),
                                     Psi = Convert.ToInt32(mainForm.uiFinishPositionPsiTextBox.Text)
                                 };
            Track = new Track
                        {
                            Time = Convert.ToInt32(mainForm.uiTrackTimeTextBox.Text),
                            StepCount = Convert.ToInt32(mainForm.uiTrackStepCountTextBox.Text)
                        };
            CalculatePoints();
            CalculateTrack();
        }

        private void CalculatePoints()
        {
            A = new Point
                    {
                        X = CardanLocationRadius*Math.Cos(CardanAngle/2/180*Math.PI),
                        Y = CardanLocationRadius*Math.Sin(CardanAngle/2/180*Math.PI),
                        Z = 0
                    };
            B = new Point
                    {
                        X = CardanLocationRadius*Math.Cos(CardanAngle/2/180*Math.PI),
                        Y = -CardanLocationRadius*Math.Sin(CardanAngle/2/180*Math.PI),
                        Z = 0
                    };
            C = new Point
                    {
                        X = CardanLocationRadius*Math.Cos((120 - CardanAngle/2)/180*Math.PI),
                        Y = -CardanLocationRadius*Math.Sin((120 - CardanAngle/2)/180*Math.PI),
                        Z = 0
                    };
            D = new Point
                    {
                        X = CardanLocationRadius*Math.Cos((120 + CardanAngle/2)/180*Math.PI),
                        Y = -CardanLocationRadius*Math.Sin((120 + CardanAngle/2)/180*Math.PI),
                        Z = 0
                    };
            E = new Point
                    {
                        X = CardanLocationRadius*Math.Cos((120 + CardanAngle/2)/180*Math.PI),
                        Y = CardanLocationRadius*Math.Sin((120 + CardanAngle/2)/180*Math.PI),
                        Z = 0
                    };
            F = new Point
                    {
                        X = CardanLocationRadius*Math.Cos((120 - CardanAngle/2)/180*Math.PI),
                        Y = CardanLocationRadius*Math.Sin((120 - CardanAngle/2)/180*Math.PI),
                        Z = 0
                    };
        }

        private void CalculateTrack()
        {
            var positions = new List<Position>();
            var dX = (FinishPosition.Center.X - StartPosition.Center.X) / Track.StepCount;
            var dY = (FinishPosition.Center.Y - StartPosition.Center.Y) / Track.StepCount;
            var dZ = (FinishPosition.Center.Z - StartPosition.Center.Z) / Track.StepCount;
            var dFi = (FinishPosition.Fi - StartPosition.Fi)/Track.StepCount;
            var dTheta = (FinishPosition.Theta - StartPosition.Theta)/Track.StepCount;
            var dPsi = (FinishPosition.Psi - StartPosition.Psi)/Track.StepCount;
            var dTime = Track.Time/Track.StepCount;
            for (var stepNumber = 0; stepNumber <= Track.StepCount; stepNumber++)
            {
                positions.Add(GetCurrentPosition(stepNumber, dTime, dX, dY, dZ, dFi, dTheta, dPsi));
            }
            Track.Positions = positions;
        }

        private Position GetCurrentPosition(int stepNumber, double dTime, double dX, double dY, double dZ, double dFi,
                                            double dTheta, double dPsi)
        {
            var center = new Point
                             {
                                 X = StartPosition.Center.X + stepNumber * dX,
                                 Y = StartPosition.Center.Y + stepNumber * dY,
                                 Z = StartPosition.Center.Z + stepNumber * dZ
                             };
            var fi = StartPosition.Fi + stepNumber*dFi;
            var theta = StartPosition.Theta + stepNumber*dTheta;
            var psi = StartPosition.Psi + stepNumber*dPsi;
            var g = GetPoint(CardanLocationRadius*Math.Cos(CardanAngle/2/180*Math.PI),
                             CardanLocationRadius*Math.Sin(CardanAngle/2/180*Math.PI),center, fi, theta, psi);
 
            var h = GetPoint(CardanLocationRadius*Math.Cos(CardanAngle/2/180*Math.PI),
                             -CardanLocationRadius * Math.Sin(CardanAngle / 2 / 180 * Math.PI), center, fi, theta, psi);

            var i = GetPoint(CardanLocationRadius*Math.Cos((120 - CardanAngle/2)/180*Math.PI),
                             -CardanLocationRadius * Math.Sin((120 - CardanAngle / 2) / 180 * Math.PI), center, fi, theta, psi);

            var j = GetPoint(CardanLocationRadius*Math.Cos((120 + CardanAngle/2)/180*Math.PI),
                             -CardanLocationRadius * Math.Sin((120 + CardanAngle / 2) / 180 * Math.PI), center, fi, theta, psi);

            var k = GetPoint(CardanLocationRadius*Math.Cos((120 + CardanAngle/2)/180*Math.PI),
                             CardanLocationRadius * Math.Sin((120 + CardanAngle / 2) / 180 * Math.PI), center, fi, theta, psi);

            var l = GetPoint(CardanLocationRadius*Math.Cos((120 - CardanAngle/2)/180*Math.PI),
                             CardanLocationRadius * Math.Sin((120 - CardanAngle / 2) / 180 * Math.PI), center, fi, theta, psi);


            return new Position
                       {
                           Time = dTime * stepNumber,
                           Center = center,
                           Fi = fi,
                           Theta = theta,
                           Psi = psi,
                           G = g,
                           H = h,
                           I = i,
                           J = j,
                           K = k,
                           L = l,
                           Rail1Length = GetRailLength(A, g),
                           Rail2Length = GetRailLength(B, h),
                           Rail3Length = GetRailLength(C, i),
                           Rail4Length = GetRailLength(D, j),
                           Rail5Length = GetRailLength(E, k),
                           Rail6Length = GetRailLength(F, l)
                       };
        }

        private Point GetPoint(double x, double y, Point center, double fiR, double thetaR, double psiR)
        {
            var fi = fiR/180*Math.PI; //перевод в радианы
            var theta = thetaR/180*Math.PI; //перевод в радианы
            var psi = psiR/180*Math.PI; //перевод в радианы
            var p = new Point
                        {
                            X = x*(Math.Cos(psi)*Math.Cos(fi) - Math.Sin(psi)*Math.Cos(theta)*Math.Sin(fi)) +
                                y*(-Math.Cos(psi)*Math.Sin(fi) - Math.Sin(psi)*Math.Cos(theta)*Math.Cos(fi)),
                            Y = x*(Math.Sin(psi)*Math.Cos(fi) + Math.Cos(psi)*Math.Cos(theta)*Math.Sin(fi)) +
                                y*(-Math.Sin(psi)*Math.Sin(fi) + Math.Cos(psi)*Math.Cos(theta)*Math.Cos(fi)),
                            Z = x*(Math.Sin(theta)*Math.Sin(fi)) +
                                y*(Math.Sin(theta)*Math.Cos(fi))
                        };
            p.X += center.X;
            p.Y += center.Y;
            p.Z += center.Z;
            return p;
        }

        private double GetRailLength(Point p0, Point p1)
        {
            return Math.Sqrt(Math.Pow(p0.X - p1.X, 2) + Math.Pow(p0.Y - p1.Y, 2) + Math.Pow(p0.Z - p1.Z, 2));
        }
    }
}
