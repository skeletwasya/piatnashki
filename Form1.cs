using System.Drawing;

namespace piatnashki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MainBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            MainGraphics = Graphics.FromImage(MainBmp);

        }
        Bitmap MainBmp;
        Graphics MainGraphics;
        TileSet tileSet;
        TileSet originalTileSet;
        int parts = 4;
        int size;
        bool isDragging;
        Point coordOfDragged;
        Point delta;
        Direction dir;
        private void ChooseThePictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableButtons();
                    Bitmap picture = new Bitmap(ofd.FileName);
                    //TODO: создать метод выбора области, который выводит pictureZoomed
                    Bitmap pictureZoomed = new Bitmap(picture, pictureBox1.Width, pictureBox1.Height);
                    tileSet = new TileSet(pictureZoomed, parts);
                    originalTileSet = tileSet.Copy();
                    size = pictureZoomed.Width / parts;
                    DrawTileSet();
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EnableButtons()
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
        }
        private void DrawTileSet()
        {
            int size = pictureBox1.Width / parts;
            for (int i = 0; i < parts; i++)
            {
                for (int j = 0; j < parts; j++)
                {
                    if (tileSet[i, j].ID != tileSet.IdOfTheCorner)
                    {
                        MainGraphics.DrawImage(tileSet[i, j].Picture, size * i, size * j);
                    }
                    else
                    {
                        MainGraphics.FillRectangle(new SolidBrush(Color.White), size * i, size * j, size, size);
                    }
                    if (isDragging)
                    {
                        int x = coordOfDragged.X;
                        int y = coordOfDragged.Y;
                        MainGraphics.FillRectangle(new SolidBrush(Color.White), size * x, size * y, size, size);
                    }
                }
            }
            pictureBox1.Image = MainBmp;
        }
        private Point CoordsThatFitsMousePosition(int x, int y)
        {
            Point def = new Point(-1, -1);
            int ind_x = x / size;
            int ind_y = y / size;
            for (int i = 0; i < parts; i++)
            {
                for (int j = 0; j < parts; j++)
                {
                    if (ind_x == i && ind_y == j)
                    {
                        return new Point(i, j);
                    }
                }
            }
            return def;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point ind = CoordsThatFitsMousePosition(e.X, e.Y);
            int i = ind.X;
            int j = ind.Y;
            if (tileSet[i, j].ID != tileSet.IdOfTheCorner)
            {
                if (i + 1 != parts)
                {
                    if (tileSet[i + 1, j].ID == tileSet.IdOfTheCorner)
                    {
                        isDragging = true;
                        dir = Direction.Right;
                    }
                }
                if (i - 1 != -1)
                {
                    if (tileSet[i - 1, j].ID == tileSet.IdOfTheCorner)
                    {
                        isDragging = true;
                        dir = Direction.Left;
                    }
                }
                if (j + 1 != parts)
                {
                    if (tileSet[i, j + 1].ID == tileSet.IdOfTheCorner)
                    {
                        isDragging = true;
                        dir = Direction.Down;
                    }
                }
                if (j - 1 != -1)
                {
                    if (tileSet[i, j - 1].ID == tileSet.IdOfTheCorner)
                    {
                        isDragging = true;
                        dir = Direction.Up;
                    }
                }
            }
            if (isDragging)
            {
                coordOfDragged = new Point(i, j);
                delta.X = Math.Abs(e.X - i * size);
                delta.Y = Math.Abs(e.Y - j * size);
            }
        }
        private void SwitchWithCornerTile(Point from)
        {
            int i = from.X;
            int j = from.Y;
            Point cornerCoord = tileSet.GetById(tileSet.IdOfTheCorner);
            int k = cornerCoord.X;
            int m = cornerCoord.Y;
            Tile tmp = tileSet[i, j];
            tileSet[i, j] = tileSet[k, m];
            tileSet[k, m] = tmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                DrawTileSet();
                int i = coordOfDragged.X;
                int j = coordOfDragged.Y;
                //TODO: ИСПРАВИТЬ ЭТО УРОДСТВО
                if (dir == Direction.Up && e.Y - delta.Y < j * size && e.Y - delta.Y > j * size - size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, e.Y - delta.Y);
                }
                else if (dir == Direction.Up && e.Y - delta.Y >= j * size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, j * size);
                }
                else if (dir == Direction.Up && e.Y - delta.Y <= j * size - size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, j * size - size);
                }

                else if (dir == Direction.Down && e.Y - delta.Y > j * size && e.Y - delta.Y < j * size + size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, e.Y - delta.Y);
                }
                else if (dir == Direction.Down && e.Y - delta.Y <= j * size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, j * size);
                }
                else if (dir == Direction.Down && e.Y - delta.Y >= j * size + size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, j * size + size);
                }

                else if (dir == Direction.Right && e.X - delta.X > i * size && e.X - delta.X < i * size + size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, e.X - delta.X, j * size);
                }
                else if (dir == Direction.Right && e.X - delta.X <= i * size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, j * size);
                }
                else if (dir == Direction.Right && e.X - delta.X >= i * size + size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size + size, j * size);
                }

                else if (dir == Direction.Left && e.X - delta.X < i * size && e.X - delta.X > i * size - size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, e.X - delta.X, j * size);
                }
                else if (dir == Direction.Left && e.X - delta.X >= i * size - size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size, j * size);
                }
                else if (dir == Direction.Left && e.X - delta.X <= i * size)
                {
                    MainGraphics.DrawImage(tileSet[i, j].Picture, i * size - size, j * size);
                }
                pictureBox1.Image = MainBmp;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                Point coordsOfDestination = CoordsThatFitsMousePosition(e.X, e.Y);
                if (coordsOfDestination != coordOfDragged)
                {
                    SwitchWithCornerTile(coordOfDragged);
                }
                CheckCode();
                DrawTileSet();
                //coordOfDragged = new Point(0, 0);
            }
        }
        private void CheckCode()
        {
            string nCode = "";
            for (int i = 0; i < parts; i++)
            {
                for (int j = 0; j < parts; j++)
                {
                    nCode += tileSet[i, j].ID;
                }
            }
            if (nCode == tileSet.Code)
            {
                label1.Text = "Ура!";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void MakeMove(Direction dir)
        {
            Point cornerCoord = tileSet.GetById(tileSet.IdOfTheCorner);
            if (dir == Direction.Up && cornerCoord.Y + 1 != parts)
            {
                SwitchWithCornerTile(new Point(cornerCoord.X, cornerCoord.Y + 1));
            }
            if (dir == Direction.Right && cornerCoord.X - 1 != -1)
            {
                SwitchWithCornerTile(new Point(cornerCoord.X - 1, cornerCoord.Y));
            }
            if (dir == Direction.Down && cornerCoord.Y - 1 != -1)
            {
                SwitchWithCornerTile(new Point(cornerCoord.X, cornerCoord.Y - 1));
            }
            if (dir == Direction.Left && cornerCoord.X + 1 != parts)
            {
                SwitchWithCornerTile(new Point(cornerCoord.X + 1, cornerCoord.Y));
            }
        }

        //Up
        private void UpButton_Click(object sender, EventArgs e)
        {
            MakeMove(Direction.Up);
            CheckCode();
            DrawTileSet();
        }
        //Right
        private void RightButton_Click(object sender, EventArgs e)
        {
            MakeMove(Direction.Right);
            CheckCode();
            DrawTileSet();
        }
        //Down
        private void DownButton_Click(object sender, EventArgs e)
        {
            MakeMove(Direction.Down);
            CheckCode();
            DrawTileSet();
        }
        //Left
        private void LeftButtonClick(object sender, EventArgs e)
        {
            MakeMove(Direction.Left);
            CheckCode();
            DrawTileSet();
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Direction dir = (Direction)rand.Next(-1, 4);
                MakeMove(dir);
            }
            DrawTileSet();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            tileSet.CopyValue(originalTileSet);
            DrawTileSet();
        }
    }
}
