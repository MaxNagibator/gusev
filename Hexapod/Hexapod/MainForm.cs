using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Hexapod
{
    public partial class MainForm : Form
    {
        private readonly Hexapod _hexapod = new Hexapod();
        private double _sceneRotateX = 90;
        private double _sceneRotateY = 180;
        private double _sceneRotateZ = 45;
        private int _sceneMoveX;
        private int _sceneMoveY = -40;
        private int _sceneMoveZ = -200;
        private double _sceneZoom = 0.4f;
        private int _settingsPanelWidth;
        private bool _isPlayBack;

        public MainForm()
        {
            InitializeComponent();
            _hexapod.SetParameters(this);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            InitializeOpenGl();
            HideSettingsPanel();
            SetSizeTrackDataGridViewColumns();
            UpdateTrackInformation();
        }

        private void InitializeOpenGl()
        {
            uiSimpleOpenGlControl.MakeCurrent();
        }

        private void HideSettingsPanel()
        {
            _settingsPanelWidth = uiSettingsPanel.Width;
            uiSettingsPanel.Width = uiSettingsVisibleButton.Width + 3;
            uiSimpleOpenGlControl.Width += _settingsPanelWidth;
        }

        private void uiParameters_TextChanged(object sender, EventArgs e)
        {
            uiUpdateSceneTimer.Stop();
            _hexapod.SetParameters(this);
            UpdateTrackInformation();
        }

        private void UpdateTrackInformation()
        {
            SetStartDirectionCosine();
            SetFinishDirectionCosine();
            uiTrackDataGridView.Rows.Clear();
            UpdateTrackInformationTable();
            uiUpdateSceneTimer.Interval = Convert.ToInt16(_hexapod.Track.Time*1000/_hexapod.Track.StepCount);
            uiTrackTrackBar.Maximum = _hexapod.Track.Positions.Count - 1;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void SetFinishDirectionCosine()
        {
            uiStartPositionDirectionCosineXValueLabel.Text = _hexapod.StartPosition.DirectionCosineX.ToString();
            uiStartPositionDirectionCosineYValueLabel.Text = _hexapod.StartPosition.DirectionCosineY.ToString();
            uiStartPositionDirectionCosineZValueLabel.Text = _hexapod.StartPosition.DirectionCosineZ.ToString();
        }

        private void SetStartDirectionCosine()
        {
            uiFinishPositionDirectionCosineXValueLabel.Text = _hexapod.FinishPosition.DirectionCosineX.ToString();
            uiFinishPositionDirectionCosineYValueLabel.Text = _hexapod.FinishPosition.DirectionCosineY.ToString();
            uiFinishPositionDirectionCosineZValueLabel.Text = _hexapod.FinishPosition.DirectionCosineZ.ToString();
        }

        private void UpdateTrackInformationTable()
        {
            foreach (var position in _hexapod.Track.Positions)
            {
                var row = new DataGridViewRow();
                row.CreateCells(uiTrackDataGridView);
                row.Cells[0].Value = Math.Round(position.Time, 5);
                row.Cells[1].Value = Math.Round(position.Center.X, 5);
                row.Cells[2].Value = Math.Round(position.Center.Y, 5);
                row.Cells[3].Value = Math.Round(position.Center.Z, 5);
                row.Cells[4].Value = Math.Round(position.Fi, 5);
                row.Cells[5].Value = Math.Round(position.Theta, 5);
                row.Cells[6].Value = Math.Round(position.Psi, 5);
                row.Cells[7].Value = Math.Round(position.Rail1Length, 5);
                row.Cells[8].Value = Math.Round(position.Rail2Length, 5);
                row.Cells[9].Value = Math.Round(position.Rail3Length, 5);
                row.Cells[10].Value = Math.Round(position.Rail4Length, 5);
                row.Cells[11].Value = Math.Round(position.Rail5Length, 5);
                row.Cells[12].Value = Math.Round(position.Rail6Length, 5);
                if (position.Rail1Length > _hexapod.RailsMaxLength || position.Rail1Length < _hexapod.RailsMinLength ||
                    position.Rail2Length > _hexapod.RailsMaxLength || position.Rail2Length < _hexapod.RailsMinLength ||
                    position.Rail3Length > _hexapod.RailsMaxLength || position.Rail3Length < _hexapod.RailsMinLength ||
                    position.Rail4Length > _hexapod.RailsMaxLength || position.Rail4Length < _hexapod.RailsMinLength ||
                    position.Rail5Length > _hexapod.RailsMaxLength || position.Rail5Length < _hexapod.RailsMinLength ||
                    position.Rail6Length > _hexapod.RailsMaxLength || position.Rail6Length < _hexapod.RailsMinLength)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                uiTrackDataGridView.Rows.Add(row);
            }
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
            GL.ClearColor(255, 255, 255, 1);
            // установка порта вывода в соотвествии с размерами элемента anT
            GL.Viewport(0, 0, uiSimpleOpenGlControl.Width, uiSimpleOpenGlControl.Height);
            // настройка проекции
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView((float)(Math.PI / 4), (float)uiSimpleOpenGlControl.Width / uiSimpleOpenGlControl.Height, 0.1f, 800);
            GL.LoadMatrix(ref perspectiveMatrix);
            //Glu.gluPerspective(45, (float) uiSimpleOpenGlControl.Width/uiSimpleOpenGlControl.Height, 0.1, 800);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            // настройка параметров OpenGL для визуализации
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            GL.PushMatrix();
            DrawAllComponents(position);
            GL.PopMatrix();
            GL.PopMatrix();
            GL.Flush();
            uiSimpleOpenGlControl.SwapBuffers();
            uiSimpleOpenGlControl.Invalidate();
        }

        private void DrawAllComponents(Position position)
        {
            SetSceneParameters();
            GL.PushMatrix();
            DrawAxes(150f);
            DrawPlatformWay();
            if (uiShowHexapodCheckBox.Checked)
            {
                DrawBasePlatform();
                DrawRails(position);
                DrawPlatform(position);
            }
            GL.PopMatrix();
        }

        private void SetSceneParameters()
        {
            GL.Translate(_sceneMoveX, _sceneMoveY, _sceneMoveZ);
            GL.Rotate(_sceneRotateX, 1, 0, 0);
            GL.Rotate(_sceneRotateY, 0, 1, 0);
            GL.Rotate(_sceneRotateZ, 0, 0, 1);
            GL.Scale(_sceneZoom, _sceneZoom, _sceneZoom);
        }

        private void DrawAxes(double axeLength)
        {
            var axeWidth = axeLength / 10;
            GL.Begin(PrimitiveType.Lines);
            DrawAxeX(axeLength, axeWidth);
            DrawAxeY(axeLength, axeWidth);
            DrawAxeZ(axeLength, axeWidth);
            GL.End();
            GL.Color3(0, 0, 0);
        }

        private void DrawAxeX(double axeLength, double axeWidth)
        {
            GL.Color3(255, 0, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(axeLength, 0, 0);
            GL.Vertex3(axeLength, 0, 0);
            GL.Vertex3(axeLength - axeWidth, axeWidth / 2, 0);
            GL.Vertex3(axeLength, 0, 0);
            GL.Vertex3(axeLength - axeWidth, -axeWidth / 2, 0);
        }

        private void DrawAxeY(double axeLength, double axeWidth)
        {
            GL.Color3(0, 255, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, axeLength, 0);
            GL.Vertex3(0, axeLength, 0);
            GL.Vertex3(axeWidth / 2, axeLength - axeWidth, 0);
            GL.Vertex3(0, axeLength, 0);
            GL.Vertex3(-axeWidth / 2, axeLength - axeWidth, 0);
        }

        private void DrawAxeZ(double axeLength, double axeWidth)
        {
            GL.Color3(0, 0, 255);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, axeLength);
            GL.Vertex3(0, 0, axeLength);
            GL.Vertex3(axeWidth / 2, 0, axeLength - axeWidth);
            GL.Vertex3(0, 0, axeLength);
            GL.Vertex3(-axeWidth / 2, 0, axeLength - axeWidth);
        }

        private void DrawPlatformWay()
        {
            if (!uiShowWayCheckBox.Checked) return;
            foreach (var position in _hexapod.Track.Positions)
            {
                GL.PushMatrix();
                GL.Translate(position.Center.X, position.Center.Y, position.Center.Z);
                GL.Rotate(position.Psi, 0, 0, 1);
                GL.PushMatrix();
                GL.Rotate(position.Theta, 1, 0, 0);
                GL.PushMatrix();
                GL.Rotate(position.Fi, 0, 0, 1);
                DrawAxes(_hexapod.PlatformRadius);
                GL.PopMatrix();
                GL.PopMatrix();
                GL.PopMatrix();
            }
        }

        private void DrawRails(Position position)
        {
            DrawRail(_hexapod.A, position.G);
            DrawRail(_hexapod.B, position.H);
            DrawRail(_hexapod.C, position.I);
            DrawRail(_hexapod.D, position.J);
            DrawRail(_hexapod.E, position.K);
            DrawRail(_hexapod.F, position.L);
            GL.Color3(0, 0, 0);
        }

        private void DrawRail(Point point1, Point point2)
        {
            GL.Begin(PrimitiveType.Lines);
            var lenght = Hexapod.GetRailLength(point1, point2);
            if (lenght > _hexapod.RailsMaxLength || lenght < _hexapod.RailsMinLength)
            {
                GL.Color3(255, 0, 0);
            }
            else
            {
                GL.Color3(0, 0, 0);
            }
            GL.Vertex3(point1.X, point1.Y, point1.Z);
            GL.Vertex3(point2.X, point2.Y, point2.Z);
            GL.End();
        }

        private void DrawBasePlatform()
        {
            GL.PushMatrix();
            GL.Translate(0, 0, -_hexapod.PlatformHeight);
            DrawCylinder((float)_hexapod.PlatformRadius, (float)_hexapod.PlatformRadius, (float)_hexapod.PlatformHeight, 360);
            // Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius,
            //     _hexapod.PlatformHeight, 360, 360);
            GL.PopMatrix();
            DrawCardans();
        }

        private void DrawCylinder(float baseRadius, float topRadius, float height, int slices)
        {
            float angleStep = 360.0f / slices;
            float angle;

            GL.Begin(PrimitiveType.Lines);

            for (int i = 0; i < slices; i++)
            {
                angle = i * angleStep;
                float nextAngle = (i + 1) * angleStep;

                float x1 = baseRadius * (float)Math.Cos(MathHelper.DegreesToRadians(angle));
                float y1 = baseRadius * (float)Math.Sin(MathHelper.DegreesToRadians(angle));
                float x2 = baseRadius * (float)Math.Cos(MathHelper.DegreesToRadians(nextAngle));
                float y2 = baseRadius * (float)Math.Sin(MathHelper.DegreesToRadians(nextAngle));

                float x3 = topRadius * (float)Math.Cos(MathHelper.DegreesToRadians(nextAngle));
                float y3 = topRadius * (float)Math.Sin(MathHelper.DegreesToRadians(nextAngle));
                float x4 = topRadius * (float)Math.Cos(MathHelper.DegreesToRadians(angle));
                float y4 = topRadius * (float)Math.Sin(MathHelper.DegreesToRadians(angle));

                GL.Vertex3(x1, y1, 0);
                GL.Vertex3(x2, y2, 0);
                GL.Vertex3(x3, y3, height);
                GL.Vertex3(x4, y4, height);
            }

            GL.End();

            DrawCircle(baseRadius, slices, 0);
            DrawCircle(topRadius, slices, height);
        }

        private void DrawCircle(float radius, int slices, float z)
        {
            float angleStep = 360.0f / slices;
            float angle;

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, z);

            for (int i = 0; i <= slices; i++)
            {
                angle = i * angleStep;
                float x = radius * (float)Math.Cos(MathHelper.DegreesToRadians(angle));
                float y = radius * (float)Math.Sin(MathHelper.DegreesToRadians(angle));
                GL.Vertex3(x, y, z);
            }

            GL.End();
        }

        private void DrawPlatform(Position position)
        {
            if (position.Rail1Length > _hexapod.RailsMaxLength || position.Rail1Length < _hexapod.RailsMinLength ||
                position.Rail2Length > _hexapod.RailsMaxLength || position.Rail2Length < _hexapod.RailsMinLength ||
                position.Rail3Length > _hexapod.RailsMaxLength || position.Rail3Length < _hexapod.RailsMinLength ||
                position.Rail4Length > _hexapod.RailsMaxLength || position.Rail4Length < _hexapod.RailsMinLength ||
                position.Rail5Length > _hexapod.RailsMaxLength || position.Rail5Length < _hexapod.RailsMinLength ||
                position.Rail6Length > _hexapod.RailsMaxLength || position.Rail6Length < _hexapod.RailsMinLength)
            {
                GL.Color3(255, 0, 0);
            }
            else
            {
                GL.Color3(0, 0, 0);
            }
            GL.PushMatrix();
            GL.Translate(position.Center.X, position.Center.Y, position.Center.Z);
            GL.Rotate(position.Psi, 0, 0, 1);
            GL.PushMatrix();
            GL.Rotate(position.Theta, 1, 0, 0);
            GL.PushMatrix();
            GL.Rotate(position.Fi, 0, 0, 1);
            DrawCylinder((float)_hexapod.PlatformRadius, (float)_hexapod.PlatformRadius, (float)_hexapod.PlatformHeight, 360);
            //Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius,
            //                _hexapod.PlatformHeight, 360, 360);
            GL.PushMatrix();
            GL.Translate(0, 0, -_hexapod.CardanHeight);
            DrawCardans();
            GL.PopMatrix();
            GL.PopMatrix();
            GL.PopMatrix();
            GL.PopMatrix();
        }

        private void DrawCardans()
        {
            DrawCardan(_hexapod.A);
            DrawCardan(_hexapod.B);
            DrawCardan(_hexapod.C);
            DrawCardan(_hexapod.D);
            DrawCardan(_hexapod.E);
            DrawCardan(_hexapod.F);
        }

        private void DrawCardan(Point p)
        {
            GL.PushMatrix();
            GL.Translate(p.X, p.Y, p.Z - _hexapod.CardanHeight);
            DrawCylinder((float)_hexapod.CardanRadius, (float)_hexapod.CardanRadius, (float)_hexapod.CardanHeight, 360);
            // Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.CardanRadius, _hexapod.CardanRadius, _hexapod.CardanHeight,
            //                 360, 360);
            GL.PopMatrix();
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
            uiPlayButtonsPanel.Location = new System.Drawing.Point(Width/2 - uiPlayButtonsPanel.Width/2,
                                                                   uiPlayButtonsPanel.Location.Y);
        }

        private void uiTrackDataGridView_SizeChanged(object sender, EventArgs e)
        {
            SetSizeTrackDataGridViewColumns();
        }

        private void SetSizeTrackDataGridViewColumns()
        {
            foreach (DataGridViewColumn column in uiTrackDataGridView.Columns)
            {
                column.Width = (uiTrackDataGridView.Width - 70) / uiTrackDataGridView.Columns.Count;
            }
        }

        private void uiShowHexapodCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiShowWayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiTrackTrackBar_ValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in uiTrackDataGridView.Rows)
            {
                row.Selected = false;
            }
            uiTrackDataGridView.Rows[uiTrackTrackBar.Value].Selected = true;
            uiTrackDataGridView.FirstDisplayedCell = uiTrackDataGridView.Rows[uiTrackTrackBar.Value].Cells[0];
        }

        private void uiDirectionCosineValueLabels_MouseEnter(object sender, EventArgs e)
        {
            uiDirectionCosineToolTip.Show("направляющий косинус для оси " + ((Label) sender).Tag, (Label) sender);
        }

        private void uiDirectionCosineValueLabels_MouseLeave(object sender, EventArgs e)
        {
            uiDirectionCosineToolTip.Hide((Label) sender);
        }

        private void uiSceneRotateXhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneRotateX = uiSceneRotateXhScrollBar.Value;
            uiSceneRotateXNumericUpDown.Value = uiSceneRotateXhScrollBar.Value;
        }

        private void uiSceneRotateXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneRotateX = Convert.ToInt32(uiSceneRotateXNumericUpDown.Value);
            uiSceneRotateXhScrollBar.Value =  Convert.ToInt32(uiSceneRotateXNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSceneRotateYhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneRotateY = uiSceneRotateYhScrollBar.Value;
            uiSceneRotateYNumericUpDown.Value = uiSceneRotateYhScrollBar.Value;
        }

        private void uiSceneRotateYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneRotateY = Convert.ToInt32(uiSceneRotateYNumericUpDown.Value);
            uiSceneRotateYhScrollBar.Value = Convert.ToInt32(uiSceneRotateYNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSceneRotateZhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneRotateZ = uiSceneRotateZhScrollBar.Value;
            uiSceneRotateZNumericUpDown.Value = uiSceneRotateZhScrollBar.Value;
        }

        private void uiSceneRotateZNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneRotateZ = Convert.ToInt32(uiSceneRotateZNumericUpDown.Value);
            uiSceneRotateZhScrollBar.Value = Convert.ToInt32(uiSceneRotateZNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSceneMoveXhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneMoveX = uiSceneMoveXhScrollBar.Value;
            uiSceneMoveXNumericUpDown.Value = uiSceneMoveXhScrollBar.Value;
        }

        private void uiSceneMoveXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneMoveX = Convert.ToInt32(uiSceneMoveXNumericUpDown.Value);
            uiSceneMoveXhScrollBar.Value = Convert.ToInt32(uiSceneMoveXNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSceneMoveYhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneMoveY = uiSceneMoveYhScrollBar.Value;
            uiSceneMoveYNumericUpDown.Value = uiSceneMoveYhScrollBar.Value;
        }

        private void uiSceneMoveYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneMoveY = Convert.ToInt32(uiSceneMoveYNumericUpDown.Value);
            uiSceneMoveYhScrollBar.Value = Convert.ToInt32(uiSceneMoveYNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSceneMoveZhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneMoveZ = uiSceneMoveZhScrollBar.Value;
            uiSceneMoveZNumericUpDown.Value = uiSceneMoveZhScrollBar.Value;
        }

        private void uiSceneMoveZNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneMoveZ = Convert.ToInt32(uiSceneMoveZNumericUpDown.Value);
            uiSceneMoveZhScrollBar.Value = Convert.ToInt32(uiSceneMoveZNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void uiSceneZoomhScrollBar_ValueChanged(object sender, EventArgs e)
        {
            _sceneZoom = Convert.ToDouble(uiSceneZoomhScrollBar.Value)/100;
            uiSceneZoomNumericUpDown.Value = uiSceneZoomhScrollBar.Value;
        }

        private void uiSceneZoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _sceneZoom = Convert.ToDouble(uiSceneZoomNumericUpDown.Value)/100;
            uiSceneZoomhScrollBar.Value = Convert.ToInt32(uiSceneZoomNumericUpDown.Value);
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }
    }
}
