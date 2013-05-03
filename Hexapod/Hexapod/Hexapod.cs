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
                                    X0 = Convert.ToInt32(mainForm.uiStartPositionX0TextBox.Text),
                                    Y0 = Convert.ToInt32(mainForm.uiStartPositionY0TextBox.Text),
                                    Z0 = Convert.ToInt32(mainForm.uiStartPositionZ0TextBox.Text),
                                    Fi = Convert.ToInt32(mainForm.uiStartPositionFiTextBox.Text),
                                    Theta = Convert.ToInt32(mainForm.uiStartPositionThetaTextBox.Text),
                                    Psi = Convert.ToInt32(mainForm.uiStartPositionPsiTextBox.Text),
                                };
            FinishPosition = new Position
                                 {
                                     X0 = Convert.ToInt32(mainForm.uiFinishPositionX0TextBox.Text),
                                     Y0 = Convert.ToInt32(mainForm.uiFinishPositionY0TextBox.Text),
                                     Z0 = Convert.ToInt32(mainForm.uiFinishPositionZ0TextBox.Text),
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
                X = CardanLocationRadius * Math.Cos(CardanAngle / 2 / 180 * Math.PI),
                Y = CardanLocationRadius * Math.Sin(CardanAngle / 2 / 180 * Math.PI),
                Z = 0
            };
            B = new Point
            {
                X = CardanLocationRadius * Math.Cos(CardanAngle / 2 / 180 * Math.PI),
                Y = -CardanLocationRadius * Math.Sin(CardanAngle / 2 / 180 * Math.PI),
                Z = 0
            };
            C = new Point
            {
                X = CardanLocationRadius * Math.Cos((120 - CardanAngle / 2) / 180 * Math.PI),
                Y = -CardanLocationRadius * Math.Sin((120 - CardanAngle / 2) / 180 * Math.PI),
                Z = 0
            };
            D = new Point
            {
                X = CardanLocationRadius * Math.Cos((120 + CardanAngle / 2) / 180 * Math.PI),
                Y = -CardanLocationRadius * Math.Sin((120 + CardanAngle / 2) / 180 * Math.PI),
                Z = 0
            };
            E = new Point
            {
                X = CardanLocationRadius * Math.Cos((120 + CardanAngle / 2) / 180 * Math.PI),
                Y = CardanLocationRadius * Math.Sin((120 + CardanAngle / 2) / 180 * Math.PI),
                Z = 0
            };
            F = new Point
            {
                X = CardanLocationRadius * Math.Cos((120 - CardanAngle / 2) / 180 * Math.PI),
                Y = CardanLocationRadius * Math.Sin((120 - CardanAngle / 2) / 180 * Math.PI),
                Z = 0
            };
        }

        private void CalculateTrack()
        {
            var positions = new List<Position>();
            var dX = (FinishPosition.X0 - StartPosition.X0) / Track.StepCount;
            var dY = (FinishPosition.Y0 - StartPosition.Y0) / Track.StepCount;
            var dZ = (FinishPosition.Z0 - StartPosition.Z0) / Track.StepCount;
            var dFi = (FinishPosition.Fi - StartPosition.Fi) / Track.StepCount;
            var dTheta = (FinishPosition.Theta - StartPosition.Theta) / Track.StepCount;
            var dPsi = (FinishPosition.Psi - StartPosition.Psi) / Track.StepCount;
            var dTime = Track.Time / Track.StepCount;
            for (var stepNumber = 0; stepNumber <= Track.StepCount; stepNumber++)
            {
                positions.Add(GetCurrentPosition(stepNumber, dTime, dX, dY, dZ, dFi, dTheta, dPsi));
            }
            Track.Positions = positions;
        }

        private Position GetCurrentPosition(int stepNumber, double dTime, double dX, double dY, double dZ, double dFi, double dTheta, double dPsi)
        {
            var x0 = StartPosition.X0 + stepNumber * dX;
            var y0 = StartPosition.Y0 + stepNumber * dY;
            var z0 = StartPosition.Z0 + stepNumber * dZ;
            var fi = StartPosition.Fi + stepNumber * dFi;
            var theta = StartPosition.Theta + stepNumber * dTheta;
            var psi = StartPosition.Psi + stepNumber * dPsi;
            var g = GetPoint(x0 + CardanLocationRadius*Math.Cos(CardanAngle/2/180*Math.PI),
                             y0 + CardanLocationRadius*Math.Sin(CardanAngle/2/180*Math.PI), z0, fi, theta, psi);

            return new Position
            {
                Time = dTime * stepNumber,
                X0 = x0,
                Y0 = y0,
                Z0 = z0,
                Fi = fi,
                Theta = theta,
                Psi = psi,
                Rail1Length = 100,
                Rail2Length = 100,
                Rail3Length = 100,
                Rail4Length = 100,
                Rail5Length = 100,
                Rail6Length = 100,
                G = g,
                H = new Point
                {
                    X = x0 + CardanLocationRadius * Math.Cos(CardanAngle / 2 / 180 * Math.PI),
                    Y = y0 + -CardanLocationRadius * Math.Sin(CardanAngle / 2 / 180 * Math.PI),
                    Z = z0
                },
                I = new Point
                {
                    X = x0 + CardanLocationRadius * Math.Cos((120 - CardanAngle / 2) / 180 * Math.PI),
                    Y = y0 + -CardanLocationRadius * Math.Sin((120 - CardanAngle / 2) / 180 * Math.PI),
                    Z = z0
                },
                J = new Point
                {
                    X = x0 + CardanLocationRadius * Math.Cos((120 + CardanAngle / 2) / 180 * Math.PI),
                    Y = y0 + -CardanLocationRadius * Math.Sin((120 + CardanAngle / 2) / 180 * Math.PI),
                    Z = z0
                },
                K = new Point
                {
                    X = x0 + CardanLocationRadius * Math.Cos((120 + CardanAngle / 2) / 180 * Math.PI),
                    Y = y0 + CardanLocationRadius * Math.Sin((120 + CardanAngle / 2) / 180 * Math.PI),
                    Z = z0
                },
                L = new Point
                {
                    X = x0 + CardanLocationRadius * Math.Cos((120 - CardanAngle / 2) / 180 * Math.PI),
                    Y = y0 + CardanLocationRadius * Math.Sin((120 - CardanAngle / 2) / 180 * Math.PI),
                    Z = z0
                }
            };
        }

        private Point GetPoint(double x0, double y0, double z0, double fiR, double thetaR, double psiR)
        {
            var fi = fiR/180*Math.PI;
            var theta = thetaR / 180 * Math.PI;
            var psi = psiR / 180 * Math.PI;
            var p = new Point();
            var x = x0 + CardanLocationRadius*Math.Cos(CardanAngle/2/180*Math.PI);
            var y = y0 + CardanLocationRadius*Math.Sin(CardanAngle/2/180*Math.PI);
            var z = z0;
            p.X = x*(Math.Cos(psi)*Math.Cos(fi) - Math.Sin(psi)*Math.Cos(theta)*Math.Sin(fi)) +
                  y*(-Math.Cos(psi)*Math.Sin(fi) - Math.Sin(psi)*Math.Cos(theta)*Math.Cos(fi)) +
                  z*(Math.Sin(psi)*Math.Sin(theta));
            p.Y = x*(Math.Sin(psi)*Math.Cos(fi) + Math.Cos(psi)*Math.Cos(theta)*Math.Sin(fi)) +
                  y*(-Math.Sin(psi)*Math.Sin(fi) + Math.Cos(psi)*Math.Cos(theta)*Math.Cos(fi)) +
                  z*(-Math.Cos(psi)*Math.Sin(theta));
            p.Z = x*(Math.Sin(theta)*Math.Sin(fi)) +
                  y*(Math.Sin(theta)*Math.Cos(fi)) +
                  z*(Math.Cos(theta));
            return p;
        }
    }
}
