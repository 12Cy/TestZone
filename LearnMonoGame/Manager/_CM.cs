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
        public static ContentManager Content;

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
            textureDictionary.Add(TextureName.animationClick, Content.Load<Texture2D>("Select//MoveAnimationClick"));

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

            textureDictionary.Add(TextureName._flower1, Content.Load<Texture2D>("Map//Tiles//TestFiles//Flower74x64"));
            textureDictionary.Add(TextureName._flower2, Content.Load<Texture2D>("Map//Tiles//TestFiles//Flower274x64"));
            textureDictionary.Add(TextureName._grass1, Content.Load<Texture2D>("Map//Tiles//TestFiles//Grass2_74x64"));
            textureDictionary.Add(TextureName._grass2, Content.Load<Texture2D>("Map//Tiles//TestFiles//Grass3_74x64"));
            textureDictionary.Add(TextureName._grass3, Content.Load<Texture2D>("Map//Tiles//TestFiles//Grass74x64"));
            textureDictionary.Add(TextureName._stone, Content.Load<Texture2D>("Map//Tiles//TestFiles//Stones_74x64"));
            textureDictionary.Add(TextureName._cheast, Content.Load<Texture2D>("Map//Tiles//TestFiles//KisteGrass_74x64"));
            textureDictionary.Add(TextureName._water, Content.Load<Texture2D>("Map//Tiles//TestFiles//Water74x64"));
            textureDictionary.Add(TextureName._wood, Content.Load<Texture2D>("Map//Tiles//TestFiles//Wood_74x64"));


            //Monster
            textureDictionary.Add(TextureName.wolf, Content.Load<Texture2D>("Monster//Wolf"));
            textureDictionary.Add(TextureName.skelett, Content.Load<Texture2D>("Monster//Skelett"));
            textureDictionary.Add(TextureName.zombie, Content.Load<Texture2D>("Monster//Zombie"));
            textureDictionary.Add(TextureName.skeletonMage, Content.Load<Texture2D>("Monster//SkeletonMage"));


            //Spells
            textureDictionary.Add(TextureName.iceLance, Content.Load<Texture2D>("Player//Weapons//IceLance"));
            textureDictionary.Add(TextureName.tornado, Content.Load<Texture2D>("Player//Weapons//Tornado"));

        }
        static void LoadFont()
        {
            fontDictionary.Add(FontName.Arial, Content.Load<SpriteFont>("Font//Arial"));
            fontDictionary.Add(FontName.DamagePopUp, Content.Load<SpriteFont>("Font//DamagePopUp"));
        }


        public enum TextureName
        {
            map,
            grassTile,
            stoneTile,
            waterTile,
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
            skelett,
            zombie,
            skeletonMage,
            animationClick,
            //TestArea
            _flower1,
            _flower2,
            _grass1,
            _grass2,
            _grass3,
            _cheast,
            _water,
            _wood,
            _stone,
                
        }
        public enum FontName
        {
            Arial,
            DamagePopUp

        }

    }
}