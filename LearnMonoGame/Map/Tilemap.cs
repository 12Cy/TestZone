﻿using LearnMonoGame.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json;
using System.IO;
using LearnMonoGame.Tools.Logger;

namespace LearnMonoGame.Map
{
    public class Tilemap
    {
        Tile[,,] _tileMap;
        Point _tileSize;
        Point mapSize;
        int layerHeight;
        List<TileLayer> tilelayers;

        public Tilemap()
        {
            tilelayers = new List<TileLayer>();
        }

        public static Tilemap ParseJson(string path)
        {
            Tilemap tileMap = new Tilemap();

            List<string> strList = File.ReadAllLines(path).ToList();

            strList[0].TrimStart('{');

            parseMain(tileMap, strList);

            LogHelper.Instance.Log(Logtarget.Contructor, tileMap.ToString());

            return tileMap;
        }

        static void parseMain(Tilemap t, List<string> strList)
        {
            Console.WriteLine("Check!");
            if (strList.Count == 0)
                return;

            string s = strList[0];
            strList.RemoveAt(0);

            s = s.Trim(' ', '"');

            string[] split = s.Split(':');

            split[0] = split[0].Trim(' ', '"');
            split[1] = split[1].Trim(' ', '"');

            switch (split[0])
            {
                case "height":
                    split[1] = split[1].Replace(',', ' ');
                    t.mapSize.Y = int.Parse(split[1]);
                    break;
                case "width":
                    split[1] = split[1].Replace(',', ' ');
                    t.mapSize.X = int.Parse(split[1]);
                    break;
                case "tileheight":
                    split[1] = split[1].Replace(',', ' ');
                    t._tileSize.Y = int.Parse(split[1]);
                    break;
                case "tilewidth":
                    split[1] = split[1].Replace(',', ' ');
                    t._tileSize.X = int.Parse(split[1]);
                    break;
                case "layers":
                    TileLayer.parseTileLayer(t.tilelayers, strList);
                    break;

            }

            parseMain(t, strList);
        }



        public Tilemap(Texture2D[] textures, Texture2D bitMap, Point _tileSize)
        {
            ParseJson("Assets/Level0_01.json");

            layerHeight = 5;
            this._tileSize = _tileSize;
            this._tileMap = new Tile[bitMap.Width, bitMap.Height, layerHeight];

            BuildMap(textures, bitMap);
        }
        void BuildMap(Texture2D[] textures, Texture2D bitMap)
        {
            Color[] colores = new Color[bitMap.Width * bitMap.Height];

            bitMap.GetData(colores);

            /*
                   TileMap: Die Tiles habene eine gewissen Größe (tileSize).
                   Wir berechnen für jedes Tail den Vector * TailSize um die genaue Position zu bestimmten!
                   Danach prüfen wir die Farben und ordnen dementsprechend Tiles zu
            */

            for (int y = 0; y < _tileMap.GetLength(1); y++) //nur die höhe möchte ich haben
            {
                for (int x = 0; x < _tileMap.GetLength(0); x++)
                {
                    if (colores[y * _tileMap.GetLength(0) + x] == Color.White) //Weiß = Gras auf der TileMap  //Grass1
                    {
                        _tileMap[x, y, 0] = new Tile(textures[3], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(0, 162, 232)) //STONE BLAU
                    {
                        _tileMap[x, y, 0] = new Tile(textures[10], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(255, 121, 0)) //Grass2 ORANGE
                    {
                        _tileMap[x, y, 0] = new Tile(textures[4], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(255, 0, 182)) //Grass3 PINK
                    {
                        _tileMap[x, y, 0] = new Tile(textures[5], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == Color.Red) //flower1
                    {
                        _tileMap[x, y, 0] = new Tile(textures[1], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(40, 255, 0)) //Flower2
                    {
                        _tileMap[x, y, 0] = new Tile(textures[2], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(0, 251, 154)) //Water
                    {
                        _tileMap[x, y, 0] = new Tile(textures[7], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(128, 249, 0)) //WoodFloor
                    {
                        _tileMap[x, y, 0] = new Tile(textures[8], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(0, 20, 255)) //Chest
                    {
                        _tileMap[x, y, 0] = new Tile(textures[6], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.Terrain);
                    }

                    //ManaSource
                    else if (colores[y * _tileMap.GetLength(0) + x] == new Color(222,255,0))//FARBE EINGEBEN)
                    {
                        _tileMap[x, y, 0] = new Tile(textures[9], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.manaSource);
                        _MapStuff.Instance.manaSourceList.Add(new ManaSource(new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y)));
                    }


                    else //sonst Stein
                    {
                        _tileMap[x, y,0] = new Tile(textures[0], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y), ETile.stone);
                        _tileMap[x, y, 1] = new Tile(textures[0], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y - 2*_tileSize.Y), ETile.stone);
                        _tileMap[x, y, 2] = new Tile(textures[0], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y - 4 * _tileSize.Y), ETile.stone);
                        _tileMap[x, y, 3] = new Tile(textures[0], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y - 6 * _tileSize.Y), ETile.stone);
                        _tileMap[x, y, 4] = new Tile(textures[0], new Vector2(x * _tileSize.X + (_tileSize.X / 2 * (y % 2)), y * _tileSize.Y - 8 * _tileSize.Y), ETile.stone);

                    }
                }
            }
        }

        public bool Walkable(Vector2 currentPosition)
        {
            try
            {
                return _tileMap[(int)currentPosition.X / _tileSize.X, (int)currentPosition.Y / _tileSize.Y, 0].Walkable();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool ManaSource(Vector2 currentPosition)
        {
            return _tileMap[(int)currentPosition.X / _tileSize.X, (int)currentPosition.Y / _tileSize.Y, 0].ManaSource();
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {

            for (int y = 0; y < _tileMap.GetLength(1); y++) //nur die höhe möchte ich haben
            {

                for (int x = 0; x < _tileMap.GetLength(0); x++)
                {
                    _tileMap[x, y, 0].Draw(spritebatch);


                    if (_tileMap[x, y, 1] == null)
                        continue;


                    for (int z = 0; z < _tileMap.GetLength(2); z++)
                        _tileMap[x, y, z].Draw(spritebatch);
                }
            }


        }

        public override string ToString()
        {
            return _tileSize + " MapSize: " + mapSize + "Count: " + tilelayers.Count;
        }
    }

}
