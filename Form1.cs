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
        int parts = 2;

        private void ChooseThePictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap picture = new Bitmap(ofd.FileName);
                    //TODO: создать метод выбора области, который выводит pictureZoomed
                    Bitmap pictureZoomed = new Bitmap(picture, pictureBox1.Width, pictureBox1.Height);
                    tileSet = new TileSet(pictureZoomed, parts);
                    DrawTileSet();
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                }
            }
            pictureBox1.Image = MainBmp;
        }
        //private Point CoordThatFitsMousePosition(int x, int y)
        //{

        //}
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
