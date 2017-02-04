﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMonoGame.Manager
{
    //MyConntentManager
    public class _CM
    {
        private static Dictionary<TextureName, Texture2D> textureDictionary = new Dictionary<TextureName, Texture2D>();
        private static Dictionary<FontName, SpriteFont> fontDictionary = new Dictionary<FontName, SpriteFont>();
        static ContentManager Content;

        public _CM(ContentManager _content)
        {
            Content = _content;

        }

        public static Texture2D GetTexture(TextureName textureName)
        {
            if (textureDictionary.Count == 0)
            {
                LoadTexture();
            }
            return textureDictionary[textureName];
        }

        public static SpriteFont GetFont(FontName FontName)
        {

            if (fontDictionary.Count == 0)
            {

                LoadFont();
            }
            return fontDictionary[FontName];
        }

        static void LoadTexture()
        {
            textureDictionary.Add(TextureName.select, Content.Load<Texture2D>("Select//DottedLine3"));
            textureDictionary.Add(TextureName.selected, Content.Load<Texture2D>("Select//selected"));
            textureDictionary.Add(TextureName.selectCircle, Content.Load<Texture2D>("Select//Circle"));
            textureDictionary.Add(TextureName.damageselect, Content.Load<Texture2D>("Select//Damageselected"));
            textureDictionary.Add(TextureName.malePlayer, Content.Load<Texture2D>("Player//maleplayer"));

            //IMoves
            textureDictionary.Add(TextureName.heal, Content.Load<Texture2D>("IMove//Heal-sheet128x128"));
            textureDictionary.Add(TextureName.burn, Content.Load<Texture2D>("IMove//Burn-sheet128x128"));

            //Weapons
            textureDictionary.Add(TextureName.fireball, Content.Load<Texture2D>("Player//Weapons//Fireball"));
            //HealthBar
            textureDictionary.Add(TextureName.backLife, Content.Load<Texture2D>("HealthBar/BackLifeGUI"));
            textureDictionary.Add(TextureName.frontLife, Content.Load<Texture2D>("HealthBar/FrontLifeGUI"));
            //Map
            textureDictionary.Add(TextureName.map, Content.Load<Texture2D>("Map//Map1"));

            //Tiles
            textureDictionary.Add(TextureName.grassTile, Content.Load<Texture2D>("Map//Tiles//GrassIso01"));
            textureDictionary.Add(TextureName.stoneTile, Content.Load<Texture2D>("Map//Tiles//StoneIso"));
            textureDictionary.Add(TextureName.waterTile, Content.Load<Texture2D>("Map//Tiles//WaterIso"));
            textureDictionary.Add(TextureName.tryTrio, Content.Load<Texture2D>("Map//Tiles//TryTri"));
            textureDictionary.Add(TextureName.wasteland, Content.Load<Texture2D>("Map//Tiles//WasteLand"));
            textureDictionary.Add(TextureName.wastelandflower, Content.Load<Texture2D>("Map//Tiles//WasteLandFlower"));
            textureDictionary.Add(TextureName.grasFlower, Content.Load<Texture2D>("Map//Tiles//GrassIsoFlower"));
            textureDictionary.Add(TextureName.tree, Content.Load<Texture2D>("Map//Tiles//TreeColor"));
            textureDictionary.Add(TextureName.manaSource, Content.Load<Texture2D>("Map//Tiles//ManaSource74x64"));
            textureDictionary.Add(TextureName.manaSourceAnimation, Content.Load<Texture2D>("Map//Tiles//ManaSourceAnimation96x96"));


            //Monster
            textureDictionary.Add(TextureName.wolf, Content.Load<Texture2D>("Monster//Wolf"));


            //Spells
            textureDictionary.Add(TextureName.iceLance, Content.Load<Texture2D>("Player//Weapons//IceLance"));
            textureDictionary.Add(TextureName.tornado, Content.Load<Texture2D>("Player//Weapons//Tornado"));

            //DebugGraphics
            textureDictionary.Add(TextureName.whitePixel, Content.Load<Texture2D>("DebugTextures//whitePixel"));

        }

        static void LoadFont()
        {
            fontDictionary.Add(FontName.Arial, Content.Load<SpriteFont>("Font//Arial"));
        }


        public enum TextureName
        {
            map,
            grassTile,
            stoneTile,
            waterTile,
            whitePixel,
            select,
            selected,
            damageselect,
            selectCircle,
            backLife,
            frontLife,
            fireball,
            wolf,
            iceLance,
            heal,
            burn,
            tornado,
            tryTrio,
            wastelandflower,
            wasteland,
            grasFlower,
            tree,
            malePlayer,
            manaSource,
            manaSourceAnimation,
                
        }
        public enum FontName
        {
            Arial,

        }

    }
}