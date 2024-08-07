﻿namespace piatnashki
{
    internal class Tile
    {
        //Уникальный идентификатор клетки
        private string id;
        public string ID 
        { 
            get 
            {
                if (id == null) throw new Exception("id is null");
                return id;
            }
            set { id = value; }
        }
        
        //Обрезанная картинка, полученная извне
        private Bitmap? picture;
        public Bitmap? Picture 
        { 
            get 
            {
                if (picture == null) throw new Exception("picture is null");
                return picture; 
            }
            set {  picture = value; }
        }

        public Tile(string id, Bitmap? picture)
        {
            this.id = id;
            this.picture = picture;
        }
    }
}
