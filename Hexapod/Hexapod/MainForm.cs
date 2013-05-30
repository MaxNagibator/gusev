using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;

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
            InitializeOpenGl();
            _hexapod.SetParameters(this);
            HideSettingsPanel();
            SetSizeTrackDataGridViewColumns();
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
            SetStartDirectionCosine();
            SetFinishDirectionCosine();
            uiTrackDataGridView.Rows.Clear();
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
            uiUpdateSceneTimer.Interval = Convert.ToInt16(_hexapod.Track.Time*1000/_hexapod.Track.StepCount);
            uiTrackTrackBar.Maximum = _hexapod.Track.Positions.Count - 1;
            DrawHexapod(_hexapod.Track.Positions[uiTrackTrackBar.Value]);
        }

        private void SetFinishDirectionCosine() //отобразить на формочке значения направляющих косинусов
        {
            uiStartPositionDirectionCosineXValueLabel.Text = _hexapod.StartPosition.DirectionCosineX.ToString();
            uiStartPositionDirectionCosineYValueLabel.Text = _hexapod.StartPosition.DirectionCosineY.ToString();
            uiStartPositionDirectionCosineZValueLabel.Text = _hexapod.StartPosition.DirectionCosineZ.ToString();
        }

        private void SetStartDirectionCosine() //отобразить на формочке значения направляющих косинусов
        {
            uiFinishPositionDirectionCosineXValueLabel.Text = _hexapod.FinishPosition.DirectionCosineX.ToString();
            uiFinishPositionDirectionCosineYValueLabel.Text = _hexapod.FinishPosition.DirectionCosineY.ToString();
            uiFinishPositionDirectionCosineZValueLabel.Text = _hexapod.FinishPosition.DirectionCosineZ.ToString();
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
            DrawAllComponents(position); //главный метод отрисовки в котором всё рисуемтся
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glFlush();
            uiSimpleOpenGlControl.Invalidate();
        }

        private void DrawAllComponents(Position position)
        {
            SetSceneParameters(); //установить параметры отображения
            Gl.glPushMatrix();
            DrawAxes(150f);
            DrawPlatformWay(); //нарисовать путь платформы
            if (uiShowHexapodCheckBox.Checked) // если нажата галочка показать гексапод
            {
                DrawBasePlatform(); //нарисовать основание
                DrawRails(position); //нарисовать штанги
                DrawPlatform(position); //нарисовать движ. платформу
            }
            Gl.glPopMatrix();
        }

        private void SetSceneParameters()
        {
            Gl.glTranslated(_sceneMoveX, _sceneMoveY, _sceneMoveZ); //перемещение сцены
            Gl.glRotated(_sceneRotateX, 1, 0, 0); //повороты вокруг осей Х У Z
            Gl.glRotated(_sceneRotateY, 0, 1, 0);
            Gl.glRotated(_sceneRotateZ, 0, 0, 1);
            Gl.glScaled(_sceneZoom, _sceneZoom, _sceneZoom); //приближение удаление сцены
        }

        private void DrawAxes(double axeLength) //сама отрисовка осей  axeLength-длина оси
        {
            var axeWidth = axeLength/10; 
            Gl.glBegin(Gl.GL_LINES);
            DrawAxeX(axeLength, axeWidth); //рисуем ось X
            DrawAxeY(axeLength, axeWidth);//рисуем ось Y
            DrawAxeZ(axeLength, axeWidth);//рисуем ось Z
            Gl.glEnd();
            Gl.glColor3f(0, 0, 0);
        }

        private void DrawAxeX(double axeLength, double axeWidth)
        {//рисуем ось X
            Gl.glColor3f(255, 0, 0); // cvet osi X - krasniy
            Gl.glVertex3d(0, 0, 0);         //пары строк, это координаты соединяемых точек
            Gl.glVertex3d(axeLength, 0, 0); //пары строк, это координаты соединяемых точек
            Gl.glVertex3d(axeLength, 0, 0);                         //2para
            Gl.glVertex3d(axeLength - axeWidth, axeWidth / 2, 0);//2para
            Gl.glVertex3d(axeLength, 0, 0);                     //3para
            Gl.glVertex3d(axeLength - axeWidth, -axeWidth / 2, 0);//3para
        }

        private void DrawAxeY(double axeLength, double axeWidth)//рисуем ось Y
        {
            Gl.glColor3f(0, 255, 0); // cvet osi Y - zeleniy
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, axeLength, 0);
            Gl.glVertex3d(0, axeLength, 0);
            Gl.glVertex3d(axeWidth/2, axeLength - axeWidth, 0);
            Gl.glVertex3d(0, axeLength, 0);
            Gl.glVertex3d(-axeWidth/2, axeLength - axeWidth, 0);
        }

        private void DrawAxeZ(double axeLength, double axeWidth) // risuem os' Z
        {
            Gl.glColor3f(0, 0, 255); // cvet osi Z - siniy
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 0, axeLength);
            Gl.glVertex3d(0, 0, axeLength);
            Gl.glVertex3d(axeWidth/2, 0, axeLength - axeWidth);
            Gl.glVertex3d(0, 0, axeLength);
            Gl.glVertex3d(-axeWidth/2, 0, axeLength - axeWidth);
        }

        private void DrawPlatformWay() // отрисовка осей платформы для всех её позиций
        {
            if (!uiShowWayCheckBox.Checked) return; // если не нажата галочка отображения пути платформы то не рисуем
            foreach (var position in _hexapod.Track.Positions) //для каждой позиции движущейся платформы, рисуем оси.
            {
                Gl.glPushMatrix();
                Gl.glTranslated(position.Center.X, position.Center.Y, position.Center.Z); //выбираем точку откуда будем рисовать
                Gl.glRotated(position.Psi, 0, 0, 1); 
                Gl.glPushMatrix();
                Gl.glRotated(position.Theta, 1, 0, 0);
                Gl.glPushMatrix();
                Gl.glRotated(position.Fi, 0, 0, 1); //пять строчек сверху, это поворот по углам эйлера
                DrawAxes(_hexapod.PlatformRadius); //сама отрисовка осей 
                Gl.glPopMatrix();
                Gl.glPopMatrix();
                Gl.glPopMatrix();
            }
        }

        private void DrawRails(Position position) //рисуем штанги платформы
        {
            DrawRail(_hexapod.A, position.G);       //рисуем штангу соединяющую 2 соответствующие точки
            DrawRail(_hexapod.B, position.H);       //рисуем штангу соединяющую 2 соответствующие точки
            DrawRail(_hexapod.C, position.I);       //рисуем штангу соединяющую 2 соответствующие точки
            DrawRail(_hexapod.D, position.J);       //рисуем штангу соединяющую 2 соответствующие точки
            DrawRail(_hexapod.E, position.K);       //рисуем штангу соединяющую 2 соответствующие точки
            DrawRail(_hexapod.F, position.L);       //рисуем штангу соединяющую 2 соответствующие точки
            Gl.glColor3f(0, 0, 0);
        }

        private void DrawRail(Point point1, Point point2) //рисуем штангу соединяющую 2 соответствующие точки
        {
            Gl.glBegin(Gl.GL_LINES);
            var lenght = Hexapod.GetRailLength(point1, point2);
            if (lenght > _hexapod.RailsMaxLength || lenght < _hexapod.RailsMinLength) //если длина штанги больше максимума или меньше минимума то красим её
            {
                Gl.glColor3f(255, 0, 0); //в красный
            }
            else
            {
                Gl.glColor3f(0, 0, 0);//всё норм - чёрный
            }
            Gl.glVertex3d(point1.X, point1.Y, point1.Z); //соединяем две пары точек
            Gl.glVertex3d(point2.X, point2.Y, point2.Z);
            Gl.glEnd();
        }

        private void DrawBasePlatform()
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -_hexapod.PlatformHeight);
            Glu.gluCylinder(Glu.gluNewQuadric(), _hexapod.PlatformRadius, _hexapod.PlatformRadius,
                            _hexapod.PlatformHeight, 360, 360); //отрисовка цилиндра для самой платформы(неподвижной)
            Gl.glPopMatrix();
            DrawCardans(); //нарисовать карданы у неподжвижной платформы
        }

        private void DrawPlatform(Position position)
        {
            if (position.Rail1Length > _hexapod.RailsMaxLength || position.Rail1Length < _hexapod.RailsMinLength ||
                position.Rail2Length > _hexapod.RailsMaxLength || position.Rail2Length < _hexapod.RailsMinLength ||
                position.Rail3Length > _hexapod.RailsMaxLength || position.Rail3Length < _hexapod.RailsMinLength ||
                position.Rail4Length > _hexapod.RailsMaxLength || position.Rail4Length < _hexapod.RailsMinLength ||
                position.Rail5Length > _hexapod.RailsMaxLength || position.Rail5Length < _hexapod.RailsMinLength ||
                position.Rail6Length > _hexapod.RailsMaxLength || position.Rail6Length < _hexapod.RailsMinLength) 
                //если длина хотябы одной штанги из 6 больше максимума или меньше минимума то красим в красный
            {
                Gl.glColor3f(255, 0, 0); //покрасить в красный
            }
            else
            {
                Gl.glColor3f(0, 0, 0); //покрасить в черный
            }
            Gl.glPushMatrix();
            Gl.glTranslated(position.Center.X, position.Center.Y, position.Center.Z);
            Gl.glRotated(position.Psi, 0, 0, 1);
            Gl.glPushMatrix();
            Gl.glRotated(position.Theta, 1, 0, 0);
            Gl.glPushMatrix();
            Gl.glRotated(position.Fi, 0, 0, 1);
            Glu.gluCylinder(Glu.gluNewQuadric(),
                _hexapod.PlatformRadius,       //радиус основания цилиндра
                _hexapod.PlatformRadius,      //радиус верхушки цилиндра
                    _hexapod.PlatformHeight,   //высота цилидра равна высоте платформы
                            360, 360);
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -_hexapod.CardanHeight);
            DrawCardans();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        private void DrawCardans()
        {
            DrawCardan(_hexapod.A); //нарисовать кордан вокруг точки А
            DrawCardan(_hexapod.B);     //нарисовать кордан 
            DrawCardan(_hexapod.C);     //нарисовать кордан
            DrawCardan(_hexapod.D);     //нарисовать кордан
            DrawCardan(_hexapod.E);     //нарисовать кордан
            DrawCardan(_hexapod.F);     //нарисовать кордан
        }

        private void DrawCardan(Point p)//нарисовать кордан с переданными координатами = p
        {
            Gl.glPushMatrix();
            Gl.glTranslated(p.X, p.Y, p.Z - _hexapod.CardanHeight); //перемещаемся ниже на высоту кардана
            Glu.gluCylinder(Glu.gluNewQuadric(), 
                            _hexapod.CardanRadius, //радиус основания цилиндра
                            _hexapod.CardanRadius,//радиус верхушки цилиндра
                            _hexapod.CardanHeight, //высота цилидра равна высоте кардана
                            360, 360 //степень скругливаемости
                            ); //нарисовать цилиндр
            Gl.glPopMatrix();
        }

        private void uiSettingsVisibleButton_Click(object sender, EventArgs e) //спрятать или показать окно настроек отображения 
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

