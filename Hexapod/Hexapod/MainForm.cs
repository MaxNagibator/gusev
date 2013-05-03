using System;
using System.Linq;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Hexapod
{
    public partial class MainForm : Form
    {
        private readonly Hexapod _hexapod = new Hexapod();
        private int _sceneRotateX;
        private int _sceneRotateY;
        private int _sceneRotateZ;
        private const int _rotateAngle = 10;
        private int _time;

        public MainForm()
        {
            InitializeComponent();
            InitializeOpenGl();
            _hexapod.SetParameters(this);
            UpdateTrackInformation();
        }

        private void InitializeOpenGl()
        {
            uiSimpleOpenGlControl.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
        }

        private void uiParameters_TextChanged(object sender, EventArgs e)
        {
            _hexapod.SetParameters(this);
            UpdateTrackInformation();
        }

        private void UpdateTrackInformation()
        {
            uiTrackDataGridView.Rows.Clear();
            foreach (var position in _hexapod.Track.Positions.Select(
                position => new object[]
                                {
                                    position.Time, position.X0, position.Y0, position.Z0,
                                    position.Fi, position.Theta, position.Psi,
                                    position.Rail1Length, position.Rail2Length, position.Rail3Length,
                                    position.Rail4Length, position.Rail5Length, position.Rail6Length
                                }))
            {
                uiTrackDataGridView.Rows.Add(position);
            }
            _time = 1;
            uiUpdateSceneTimer.Start();
        }

        private void DrawHexapod(object sender, EventArgs e)
        {
            if (_time < _hexapod.Track.Positions.Count - 1)
            {
                _time++;
                DrawHexapod(_hexapod.Track.Positions[_time]);
            }
            else
            {
                uiUpdateSceneTimer.Stop();
            }
        }

        private void DrawHexapod(Position position)
        {
            // очитка окна 
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, uiSimpleOpenGlControl.Width, uiSimpleOpenGlControl.Height);
            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float) uiSimpleOpenGlControl.Width/uiSimpleOpenGlControl.Height, 0.1, 800);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            DrawAllComponents(position);
            Gl.glPopMatrix();
            Gl.glFlush();
            uiSimpleOpenGlControl.Invalidate();
        }

        private void DrawAllComponents(Position position)
        {
            SetSceneParameters();
            DrawAxes();
            DrawBasePlatform();
            DrawRails(position);
            DrawPlatform(position);
        }

        private void SetSceneParameters()
        {
            Gl.glTranslated(0, 0, -200);
            Gl.glRotated(_sceneRotateX, 1, 0, 0);
            Gl.glRotated(_sceneRotateY, 0, 1, 0);
            Gl.glRotated(_sceneRotateZ, 0, 0, 1);
            Gl.glScalef(0.3f, 0.3f, 0.3f);
        }

        private void DrawAxes()
        {
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex3f(100.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 100.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0.0f, 0.0f, 100.0f);
            Gl.glEnd();
        }

        private void DrawRails(Position position)
        {
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3f((float) _hexapod.A.X, (float) _hexapod.A.Y, (float) _hexapod.A.Z);
            Gl.glVertex3f((float) position.G.X, (float) position.G.Y, (float) position.G.Z);
            Gl.glVertex3f((float) _hexapod.B.X, (float) _hexapod.B.Y, (float) _hexapod.B.Z);
            Gl.glVertex3f((float) position.H.X, (float) position.H.Y, (float) position.H.Z);
            Gl.glVertex3f((float) _hexapod.C.X, (float) _hexapod.C.Y, (float) _hexapod.C.Z);
            Gl.glVertex3f((float) position.I.X, (float) position.I.Y, (float) position.I.Z);
            Gl.glVertex3f((float) _hexapod.D.X, (float) _hexapod.D.Y, (float) _hexapod.D.Z);
            Gl.glVertex3f((float) position.J.X, (float) position.J.Y, (float) position.J.Z);
            Gl.glVertex3f((float) _hexapod.E.X, (float) _hexapod.E.Y, (float) _hexapod.E.Z);
            Gl.glVertex3f((float) position.K.X, (float) position.K.Y, (float) position.K.Z);
            Gl.glVertex3f((float) _hexapod.F.X, (float) _hexapod.F.Y, (float) _hexapod.F.Z);
            Gl.glVertex3f((float) position.L.X, (float) position.L.Y, (float) position.L.Z);
            Gl.glEnd();
        }

        private void DrawBasePlatform()
        {
            Gl.glBegin(Gl.GL_LINES);
            for (double i = 0; i < 360; i++)
            {
                var x = (float) (_hexapod.PlatformRadius*Math.Cos(i/180*Math.PI));
                var y = (float) (_hexapod.PlatformRadius*Math.Sin(i/180*Math.PI));
                Gl.glVertex3f(x, y, 0);
                Gl.glVertex3f(x, y, -10);
            }
            Gl.glEnd();
        }

        private void DrawPlatform(Position position)
        {
            Gl.glBegin(Gl.GL_LINES);
            Gl.glRotated(position.Fi, 0, 0, 1);
            Gl.glRotated(position.Theta, 1, 0, 0);
            Gl.glRotated(position.Psi, 0, 0, 1);
            for (double i = 0; i < 360; i++)
            {
                var x0 = (position.X0 + _hexapod.PlatformRadius*Math.Cos(i/180*Math.PI));
                var y0 = (position.Y0 + _hexapod.PlatformRadius*Math.Sin(i/180*Math.PI));
                var z0 = 0;
                var fi = position.Fi/180*Math.PI;
                var theta = position.Theta/180*Math.PI;
                var psi = position.Psi/180*Math.PI;
                var x = ((float)(x0 * (Math.Cos(psi) * Math.Cos(fi) - Math.Sin(psi) * Math.Cos(theta) * Math.Sin(fi)) +
                                  y0 * (-Math.Cos(psi) * Math.Sin(fi) - Math.Sin(psi) * Math.Cos(theta) * Math.Cos(fi)) +
                                  z0 * (Math.Sin(psi) * Math.Sin(theta))));
                var y = ((float)(x0 * (Math.Sin(psi) * Math.Cos(fi) + Math.Cos(psi) * Math.Cos(theta) * Math.Sin(fi)) +
                                  y0 * (-Math.Sin(psi) * Math.Sin(fi) + Math.Cos(psi) * Math.Cos(theta) * Math.Cos(fi)) +
                                  z0 * (-Math.Cos(psi) * Math.Sin(theta))));
                var z = ((float)(x0 * (Math.Sin(theta) * Math.Sin(fi)) +
                                  y0 * (Math.Sin(theta) * Math.Cos(fi)) +
                                  z0 * (Math.Cos(theta)) + (position.Z0)));
                //var x = ((float) (x0*(Math.Cos(theta)) +
                //                  y0*
                //                  (-Math.Cos(psi)*Math.Sin(theta)*Math.Cos(fi) -
                //                   Math.Sin(psi)*Math.Sin(theta)*Math.Sin(fi)) +
                //                  z0*
                //                  (Math.Sin(psi)*Math.Sin(theta)*Math.Cos(fi) +
                //                   Math.Cos(psi)*Math.Sin(theta)*Math.Sin(fi))));
                //var y = ((float) (x0*(Math.Cos(psi)*Math.Sin(theta)) +
                //                  y0*(Math.Cos(psi)*Math.Cos(theta)*Math.Cos(fi) - Math.Sin(psi)*Math.Sin(fi)) +
                //                  z0*(-Math.Cos(psi)*Math.Cos(theta)*Math.Sin(fi) - Math.Sin(psi)*Math.Cos(fi))));
                //var z = ((float) (x0*(Math.Sin(psi)*Math.Sin(theta)) +
                //                  y0*(Math.Sin(psi)*Math.Cos(theta)*Math.Cos(fi) + Math.Cos(psi)*Math.Sin(fi)) +
                //                  z0*(-Math.Sin(psi)*Math.Cos(theta)*Math.Sin(fi) + Math.Cos(psi)*Math.Cos(fi))));
                Gl.glVertex3f(x, y, z);
                Gl.glVertex3f(x, y, z + 10);
            }
            Gl.glEnd();
        }

        private void uiShowRotateXDownButton_Click(object sender, EventArgs e)
        {
            _sceneRotateX -= _rotateAngle;
            DrawHexapod(_hexapod.Track.Positions[_time]);
        }

        private void uiShowRotateXUpButton_Click(object sender, EventArgs e)
        {
            _sceneRotateX += _rotateAngle;
            DrawHexapod(_hexapod.Track.Positions[_time]);
        }

        private void uiShowRotateYDownButton_Click(object sender, EventArgs e)
        {
            _sceneRotateY -= _rotateAngle;
            DrawHexapod(_hexapod.Track.Positions[_time]);
        }

        private void uiShowRotateYUpButton_Click(object sender, EventArgs e)
        {
            _sceneRotateY += _rotateAngle;
            DrawHexapod(_hexapod.Track.Positions[_time]);
        }

        private void uiShowRotateZDownButton_Click(object sender, EventArgs e)
        {
            _sceneRotateZ -= _rotateAngle;
            DrawHexapod(_hexapod.Track.Positions[_time]);
        }

        private void uiShowRotateZUpButton_Click(object sender, EventArgs e)
        {
            _sceneRotateZ += _rotateAngle;
            DrawHexapod(_hexapod.Track.Positions[_time]);
        }
    }
}

