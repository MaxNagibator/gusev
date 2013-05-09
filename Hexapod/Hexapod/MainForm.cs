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
        private int _sceneRotateX = 120;
        private int _sceneRotateY = 180;
        private int _sceneRotateZ = 45;
        private const int ROTATE_ANGLE = 15;
        private int _sceneMoveX;
        private int _sceneMoveY;
        private int _sceneMoveZ = -200;
        private float _sceneZoom = 0.3f;
        private const int MOVE = 10;
        private int _settingsPanelWidth;
        private bool _isPlayBack;

        public MainForm()
        {
            InitializeComponent();
            InitializeOpenGl();
            _hexapod.SetParameters(this);
            HideSettingsPanel();
            UpdateTrackInformation();
        }

        private void HideSettingsPanel()
        {
            _settingsPanelWidth = uiSettingsPanel.Width;
            uiSettingsPanel.Width = uiSettingsVisibleButton.Width + 3;
            uiSimpleOpenGlControl.Width += _settingsPanelWidth;
        }

        private void InitializeOpenGl()
        {
            uiSimpleOpenGlControl.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
        }

        private void uiParameters_TextChanged(object sender, EventArgs e)
        {
            uiUpdateSceneTimer.Stop();
            _hexapod.SetParameters(this);
            UpdateTrackInformation();
        }

        private void UpdateTrackInformation()
        {
            uiTrackDataGridView.Rows.Clear();
            foreach (var position in _hexapod.Track.Positions
                .Select(position => new object[]
                                        {
                                            Math.Round(position.Time, 5),
                                            Math.Round(position.Center.X, 5),
                                            Math.Round(position.Center.Y, 5),
                                            Math.Round(position.Center.Z, 5),
                                            Math.Round(position.Fi, 5),
                                            Math.Round(position.Theta, 5),
                                            Math.Round(position.Psi, 5),
                                            Math.Round(position.Rail1Length, 5),
                                            Math.Round(position.Rail2Length, 5),
                                            Math.Round(position.Rail3Length, 5),
                                            Math.Round(position.Rail4Length, 5),
                                            Math.Round(position.Rail5Length, 5),
                                            Math.Round(position.Rail6Length, 5)
                                        }))
            {
                uiTrackDataGridView.Rows.Add(position);
            }
            uiUpdateSceneTimer.Interval = Convert.ToInt16(_hexapod.Track.Time*1000/_hexapod.Track.StepCount);
            uiTrackTrackBar.Maximum = _hexapod.Track.Positions.Count - 1;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void DrawHexapodTick(object sender, EventArgs e)
        {
            if (_isPlayBack)
            {
                if (uiTrackTrackBar.Value > 0)
                {
                    uiTrackTrackBar.Value--;
                    DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
                }
                else
                {
                    uiUpdateSceneTimer.Stop();
                }
            }
            else
            {
                if (uiTrackTrackBar.Value < uiTrackTrackBar.Maximum)
                {
                    uiTrackTrackBar.Value++;
                    DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
                }
                else
                {
                    uiUpdateSceneTimer.Stop();
                }
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
            DrawAxes(150f);
            DrawPlatformWay();
            DrawCardans(position);
            DrawBasePlatform();
            DrawPlatform(position);
        }


        private void SetSceneParameters()
        {
            Gl.glTranslated(_sceneMoveX, _sceneMoveY, _sceneMoveZ);
            Gl.glRotated(_sceneRotateX, 1, 0, 0);
            Gl.glRotated(_sceneRotateY, 0, 1, 0);
            Gl.glRotated(_sceneRotateZ, 0, 0, 1);
            Gl.glScalef(_sceneZoom, _sceneZoom, _sceneZoom);
        }

        private void DrawAxes(double axeLength)
        {
            double axeWidth = axeLength / 10;
            Gl.glBegin(Gl.GL_LINES);
            DrawAxeX(axeLength, axeWidth);
            DrawAxeY(axeLength, axeWidth);
            DrawAxeZ(axeLength, axeWidth);
            Gl.glEnd();
            Gl.glColor3f(0, 0, 0);
        }

        private void DrawAxeX(double axeLength, double axeWidth)
        {
            Gl.glColor3f(255, 0, 0);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(axeLength, 0, 0);
            Gl.glVertex3d(axeLength, 0, 0);
            Gl.glVertex3d(axeLength - axeWidth, axeWidth / 2, 0);
            Gl.glVertex3d(axeLength, 0, 0);
            Gl.glVertex3d(axeLength - axeWidth, -axeWidth / 2, 0);
        }

        private void DrawAxeY(double axeLength, double axeWidth)
        {
            Gl.glColor3f(0, 255, 0);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, axeLength, 0);
            Gl.glVertex3d(0, axeLength, 0);
            Gl.glVertex3d(axeWidth/2, axeLength - axeWidth, 0);
            Gl.glVertex3d(0, axeLength, 0);
            Gl.glVertex3d(-axeWidth/2, axeLength - axeWidth, 0);
        }

        private void DrawAxeZ(double axeLength, double axeWidth)
        {
            Gl.glColor3f(0, 0, 255);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 0, axeLength);
            Gl.glVertex3d(0, 0, axeLength);
            Gl.glVertex3d(axeWidth / 2, 0, axeLength - axeWidth);
            Gl.glVertex3d(0, 0, axeLength);
            Gl.glVertex3d(-axeWidth / 2, 0, axeLength - axeWidth);
        }

        private void DrawPlatformWay()
        {
            foreach (var position in _hexapod.Track.Positions)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(position.Center.X, position.Center.Y, position.Center.Z);
                Gl.glRotated(position.Psi, 0, 0, 1);
                Gl.glPushMatrix();
                Gl.glRotated(position.Theta, 1, 0, 0);
                Gl.glPushMatrix();
                Gl.glRotated(position.Fi, 0, 0, 1);
                DrawAxes(_hexapod.PlatformRadius);
                Gl.glPopMatrix();
                Gl.glPopMatrix();
                Gl.glPopMatrix();
            }
        }

        private void DrawCardans(Position position)
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
            Gl.glTranslated(0, 0, -_hexapod.PlatformHeight);
            Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius, _hexapod.PlatformHeight, 360, 360);
            Gl.glPopMatrix();
            DrawCardansRadius();
        }

        private void DrawPlatform(Position position)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(position.Center.X, position.Center.Y, position.Center.Z);
            Gl.glRotated(position.Psi, 0, 0, 1);
            Gl.glPushMatrix();
            Gl.glRotated(position.Theta, 1, 0, 0);
            Gl.glPushMatrix();
            Gl.glRotated(position.Fi, 0, 0, 1);
            Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius, _hexapod.PlatformHeight, 360, 360);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -_hexapod.CardanHeight);
            DrawCardansRadius();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        private void DrawCardansRadius()
        {
            DrawCardanRadius(_hexapod.A);
            DrawCardanRadius(_hexapod.B);
            DrawCardanRadius(_hexapod.C);
            DrawCardanRadius(_hexapod.D);
            DrawCardanRadius(_hexapod.E);
            DrawCardanRadius(_hexapod.F);
        }

        private void DrawCardanRadius(Point p)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(p.X, p.Y, p.Z - _hexapod.CardanHeight);
            Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.CardanRadius, _hexapod.CardanRadius, _hexapod.CardanHeight,
                            360, 360);
            Gl.glPopMatrix();
        }

        private void uiShowRotateXDownButton_Click(object sender, EventArgs e)
        {
            _sceneRotateX -= ROTATE_ANGLE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowRotateXUpButton_Click(object sender, EventArgs e)
        {
            _sceneRotateX += ROTATE_ANGLE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowRotateYDownButton_Click(object sender, EventArgs e)
        {
            _sceneRotateY -= ROTATE_ANGLE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowRotateYUpButton_Click(object sender, EventArgs e)
        {
            _sceneRotateY += ROTATE_ANGLE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowRotateZDownButton_Click(object sender, EventArgs e)
        {
            _sceneRotateZ -= ROTATE_ANGLE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowRotateZUpButton_Click(object sender, EventArgs e)
        {
            _sceneRotateZ += ROTATE_ANGLE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowZoomUpButton_Click(object sender, EventArgs e)
        {
            _sceneZoom = _sceneZoom * 1.3f;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowZoomDownButton_Click(object sender, EventArgs e)
        {
            _sceneZoom = _sceneZoom / 1.3f;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMoveXDownButton_Click(object sender, EventArgs e)
        {
            _sceneMoveX -= MOVE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMoveYDownButton_Click(object sender, EventArgs e)
        {
            _sceneMoveY -= MOVE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMoveZDownButton_Click(object sender, EventArgs e)
        {
            _sceneMoveZ -= MOVE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMoveXUpButton_Click(object sender, EventArgs e)
        {
            _sceneMoveX += MOVE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMoveYUpButton_Click(object sender, EventArgs e)
        {
            _sceneMoveY += MOVE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMoveZUpButton_Click(object sender, EventArgs e)
        {
            _sceneMoveZ += MOVE;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSettingsVisibleButton_Click(object sender, EventArgs e)
        {
            if (uiSettingsPanel.Width == _settingsPanelWidth)
            {
                uiSettingsPanel.Width = uiSettingsVisibleButton.Width + 3;
                uiSimpleOpenGlControl.Width += _settingsPanelWidth;
            }
            else
            {
                uiSettingsPanel.Width = _settingsPanelWidth;
                uiSimpleOpenGlControl.Width -= _settingsPanelWidth;
            }
            UpdateTrackInformation();
        }

        private void uiTrackStartButton_Click(object sender, EventArgs e)
        {
            _isPlayBack = false;
            uiUpdateSceneTimer.Start(); 
        }

        private void uiTrackPauseButton_Click(object sender, EventArgs e)
        {
            uiUpdateSceneTimer.Stop();
        }

        private void uiTrackBackStartButton_Click(object sender, EventArgs e)
        {
            _isPlayBack = true;
            uiUpdateSceneTimer.Start(); 
        }

        private void uiTrackPlayToEndButton_Click(object sender, EventArgs e)
        {
            uiUpdateSceneTimer.Stop(); 
            uiTrackTrackBar.Value = uiTrackTrackBar.Maximum;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiTrackPlayToStartButton_Click(object sender, EventArgs e)
        {
            uiUpdateSceneTimer.Stop(); 
            uiTrackTrackBar.Value = 0;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiTrackTrackBar_Scroll(object sender, EventArgs e)
        {
            uiUpdateSceneTimer.Stop(); 
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiMainPanel_SizeChanged(object sender, EventArgs e)
        {
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
            uiPlayButtonsPanel.Location = new System.Drawing.Point(Width/2 - uiPlayButtonsPanel.Width/2, uiPlayButtonsPanel.Location.Y);
        }

        private void uiTrackDataGridView_SizeChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in uiTrackDataGridView.Columns)
            {
                column.Width = (uiTrackDataGridView.Width-70)/uiTrackDataGridView.Columns.Count;
            }
        }
    }
}

