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
            uiUpdateSceneTimer.Interval = Convert.ToInt16(_hexapod.Track.Time * 1000 / _hexapod.Track.StepCount);
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
            Gl.glVertex3d(_hexapod.A.X, _hexapod.A.Y, _hexapod.A.Z);
            Gl.glVertex3d(position.G.X, position.G.Y, position.G.Z);
            Gl.glVertex3d(_hexapod.B.X, _hexapod.B.Y, _hexapod.B.Z);
            Gl.glVertex3d(position.H.X, position.H.Y, position.H.Z);
            Gl.glVertex3d(_hexapod.C.X, _hexapod.C.Y, _hexapod.C.Z);
            Gl.glVertex3d(position.I.X, position.I.Y, position.I.Z);
            Gl.glVertex3d(_hexapod.D.X, _hexapod.D.Y, _hexapod.D.Z);
            Gl.glVertex3d(position.J.X, position.J.Y, position.J.Z);
            Gl.glVertex3d(_hexapod.E.X, _hexapod.E.Y, _hexapod.E.Z);
            Gl.glVertex3d(position.K.X, position.K.Y, position.K.Z);
            Gl.glVertex3d(_hexapod.F.X, _hexapod.F.Y, _hexapod.F.Z);
            Gl.glVertex3d(position.L.X, position.L.Y, position.L.Z);
            Gl.glEnd();
        }

        private void DrawBasePlatform()
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -10);
            Gl.glBegin(Gl.GL_LINES);
            Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius, 10f, 360, 360);
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        private void DrawPlatform(Position position)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(position.X0, position.Y0, position.Z0);
            Gl.glRotated(position.Psi, 0, 0, 1);
            Gl.glPushMatrix();
            Gl.glRotated(position.Theta, 1, 0, 0);
            Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius, 10f, 360, 360);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
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

