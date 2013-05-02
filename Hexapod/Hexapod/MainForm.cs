using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Hexapod
{
    public partial class MainForm : Form
    {
        private Hexapod _hexapod;
        private int _sceneRotateX = 0;
        private int _sceneRotateY = 0;
        private int _sceneRotateZ = 0;
        private int _rotateAngle= 10;
        private int _time;
        private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        public MainForm()
        {
            InitializeComponent();
            uiSimpleOpenGlControl.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            _hexapod = CreateHexapod();
            _hexapod.CalculateTrack();
            UpdateTrackInformation();
            t.Tick += DrawHexapod;
            t.Interval = 1;
        }

        private Hexapod CreateHexapod()
        {
            var h = new Hexapod
                        {
                            PlatformRadius = Convert.ToInt32(uiPlatformRadiusTextBox.Text),
                            PlatformHeight = Convert.ToInt32(uiPlatformHeightTextBox.Text),
                            CardanAngle = Convert.ToInt32(uiCardanAngleTextBox.Text),
                            CardanHeight = Convert.ToInt32(uiCardanHeightTextBox.Text),
                            CardanRadius = Convert.ToInt32(uiCardanRadiusTextBox.Text),
                            CardanLocationRadius = Convert.ToInt32(uiCardanToCenterLenghtTextBox.Text),
                            RailsRadius = Convert.ToInt32(uiRailsRadiusTextBox.Text),
                            RailsMinLength = Convert.ToInt32(uiRailsMinLengthTextBox.Text),
                            RailsMaxLength = Convert.ToInt32(uiRailsMaxLengthTextBox.Text),
                            StartPosition = new Position
                                                {
                                                    X0 = Convert.ToInt32(uiStartPositionX0TextBox.Text),
                                                    Y0 = Convert.ToInt32(uiStartPositionY0TextBox.Text),
                                                    Z0 = Convert.ToInt32(uiStartPositionZ0TextBox.Text),
                                                    Fi = Convert.ToInt32(uiStartPositionFiTextBox.Text),
                                                    Theta = Convert.ToInt32(uiStartPositionThetaTextBox.Text),
                                                    Psi = Convert.ToInt32(uiFinishPositionPsiTextBox.Text),
                                                },
                            FinishPosition = new Position
                                                 {
                                                     X0 = Convert.ToInt32(uiFinishPositionX0TextBox.Text),
                                                     Y0 = Convert.ToInt32(uiFinishPositionY0TextBox.Text),
                                                     Z0 = Convert.ToInt32(uiFinishPositionZ0TextBox.Text),
                                                     Fi = Convert.ToInt32(uiFinishPositionFiTextBox.Text),
                                                     Theta = Convert.ToInt32(uiFinishPositionThetaTextBox.Text),
                                                     Psi = Convert.ToInt32(uiFinishPositionPsiTextBox.Text)
                                                 },
                            Track = new Track
                                        {
                                            Time = Convert.ToInt32(uiTrackTimeTextBox.Text),
                                            StepCount = Convert.ToInt32(uiTrackStepCountTextBox.Text)
                                        }
                        };
            h.CalculatePoints();
            return h;
        }

        private void uiParameters_TextChanged(object sender, EventArgs e)
        {
            _hexapod = CreateHexapod();
            _hexapod.CalculateTrack();
            UpdateTrackInformation();
        }

        private void UpdateTrackInformation()
        {
            textBox1.Text = "";
            uiTrackDataGridView.Rows.Clear();
            foreach (Position position in _hexapod.Track.Positions)
            {
                var r = new object[]
                            {
                                position.Time, position.X0, position.Y0, position.Z0,
                                position.Fi, position.Theta, position.Psi,
                                position.Rail1Length, position.Rail2Length, position.Rail3Length,
                                position.Rail4Length, position.Rail5Length, position.Rail6Length
                            };
                uiTrackDataGridView.Rows.Add(r);
            }
            _time = 1;
            t.Stop();
            t.Start();
        }

        private void DrawHexapod(object sender, EventArgs e)
        {

            DrawHexapod(_hexapod.Track.Positions[_time]);
            _time++;
            if (_time >= _hexapod.Track.Positions.Count)
            {
                t.Stop();
                _time--;
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
            Glu.gluPerspective(45, (float) uiSimpleOpenGlControl.Width/(float) uiSimpleOpenGlControl.Height, 0.1, 800);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0, 0);
            Gl.glPushMatrix();
            Gl.glTranslated(10, 10, -200);
            Gl.glRotated(_sceneRotateX, 1, 0, 0);
            Gl.glRotated(_sceneRotateY, 0, 1, 0);
            Gl.glRotated(_sceneRotateZ, 0, 0, 1);
            Gl.glScalef(0.3f, 0.3f, 0.3f);
            DrawAxes();
            DrawBasePlatform();
            DrawRails(position);
            DrawPlatform(position);
            Gl.glPopMatrix();
            Gl.glFlush();
            uiSimpleOpenGlControl.Invalidate();
        }

        private void DrawAxes()
        {
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 0.0f, 0.0f); //xyz
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
            for (double i = 0; i < 360; i++)
            {
                var x = (float) (position.X0 + _hexapod.PlatformRadius*Math.Cos(i/180*Math.PI));
                var y = (float) (position.Y0 + _hexapod.PlatformRadius*Math.Sin(i/180*Math.PI));
                var z = (float) (position.Z0);
                Gl.glVertex3f(x, y, z);
                Gl.glVertex3f(x, y, z + 10);
            }
            Gl.glEnd();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _hexapod = CreateHexapod();
            _hexapod.CalculateTrack();
            UpdateTrackInformation();
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

