namespace piatnashki
{
    internal class TileSet
    {
        //Количество клеток по вертикали и горизонтали. 
        int parts;
        //Картинка, загруженная пользователем и преобразованная в соответствии с разрешением pictureBox1
        Bitmap picture;
        //Код картинки, сложенный из tiles[i,j].id, означающий то, как картинка выглядит в оригинале
        string? code = "";
        //id угловой клетки, которая пуста
        string idOfTheCorner = "";
        public string IdOfTheCorner
        {
            get
            {
                if (idOfTheCorner == null) throw new Exception("id is null");
                return idOfTheCorner;
            }
        }
        public string Code
        {
            get 
            {
                if (code == null) throw new Exception("code is null");
                return code; 
            }
        }
        
        //Двумерный массив клеток размером [parts,parts]
        Tile[,]? tiles;
        public TileSet(Bitmap picture, int parts)
        {
            this.parts = parts;
            this.picture = picture;
            SetTiles();
            SetCode();
        }
        public Point GetById(string id)
        {
            if (tiles == null) throw new Exception("tiles is null");
            for(int i = 0; i < parts; i++) 
            {
                for(int j = 0; j < parts; j++)
                {
                    if (tiles[i,j].ID == id)
                    {
                        return new Point(i,j);
                    }
                }
            }
            throw new Exception("id does not exist");
        }
        private void SetTiles()
        {
            if (picture == null) throw new Exception("picture is null");
            if (picture.Width != picture.Height) throw new Exception("picture is not square shaped");
            if (parts <= 0) throw new Exception("parts <= 0");
            
            int size = picture.Height / parts;
            Tile[,] tiles = new Tile[parts, parts];
            for(int i = 0; i < parts; i++) 
            {
                for(int j = 0; j < parts; j++) 
                {
                    tiles[i, j] = new Tile(GetId(i, j), Crop(picture, new Rectangle(i * size, j * size, size, size)));
                    if (i == parts - 1 && j == 0) idOfTheCorner = tiles[i, j].ID;
                }
            }
            this.tiles = tiles;
        }
        private void SetCode()
        {
            for(int i = 0; i < parts; i++)
            {
                for(int j = 0; j < parts; j++)
                {
                    if (tiles == null) throw new Exception("tiles array is null");
                    if (tiles[i,j].ID == null) throw new Exception("id is null");
                    code += tiles[i, j].ID;
                }
            }
        }
        private Bitmap Crop(Bitmap image, Rectangle selection)
        {
            Bitmap bmp = new Bitmap(image);
            if (image == null)
                throw new ArgumentException("No valid bitmap");
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);  
            bmp.Dispose();
            return cropBmp;
        }  
        private string GetId(int i, int j)
        {
            return Convert.ToString(i) + Convert.ToString(j);
        }
        public Tile this[int i, int j]
        {
            get 
            {
                if (tiles == null) throw new Exception("tiles array is null");
                if (i >= parts || j >= parts || i < 0 || j < 0) throw new ArgumentOutOfRangeException();
                return tiles[i, j]; 
            }
            set
            {
                if (tiles == null) throw new Exception("tiles array is null");
                if (i >= parts || j >= parts || i < 0 || j < 0) throw new ArgumentOutOfRangeException();
                tiles[i, j] = value;
            }
        }
    }
}
