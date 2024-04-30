using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using SumosMonogame.Controls;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace SumosMonogame
{
    public class Game1 : Game
    {
        KeyboardState state;
        private GraphicsDeviceManager g;
        public SpriteBatch _spriteBatch;


        Texture2D clouds, heart, Temples, sumoSleep, sumoNormal, jumpAtivated, jumpDesactivated, brick, button, redSumo, blueSumo, gameOver;
        SpriteFont titles;
  
        private float templesSpeed = 3.5f;
        Vector2 cloudsPosition;
        Vector2 templesPosition;
        MouseState mState;
        Canvas canvas;
        Scene scene;
        Juego juego;
        Map map;
        DateTime lastWKeyPressTime;
        DateTime lastIKeyPressTime;
        int timeAfterLoosingSumo1;
        int timeAfterLoosingSumo2;
        int lifes = 1;
        float delta;
        Texture2D brush;
        GraphicsDevice graphicsDevice;
        float angle;
        Vector2 origin;
        public Vector2 pos;

        bool aKey, wKey, dKey, upKey, leftKey, rightKey;
       


        SpriteBatch spriteBatchBackground;
        SpriteBatch spriteBatchForeground;

        private List<Component> _components;



        TimeSpan delayTime = TimeSpan.FromSeconds(3);

        int width, height;
        
        



        public Game1()
        {
            g = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //FULL SCREEN
            g.IsFullScreen = true;
            width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            int div = 1;
            g.PreferredBackBufferWidth = width / div;
            g.PreferredBackBufferHeight = height / div;
            g.ApplyChanges();


            wKey = true; dKey = true; aKey = true; upKey = true; leftKey = true; rightKey = true;


            



        }

        protected override void Initialize()
        {

            graphicsDevice = GraphicsDevice;

            //TEXTURES
            brush = new Texture2D(GraphicsDevice, 1, 1);
            brush.SetData(new Color[] { Color.Gray });

            //CLASES
            canvas = new Canvas(width, height, _spriteBatch, graphicsDevice);
            scene = new Scene(width, height, graphicsDevice);
            scene.AddSumo(new Vec2(750, 200), 60);
            scene.AddSumo(new Vec2(1050, 200), 60);
            juego = new Juego(lifes, graphicsDevice);
            delta = 0;

            timeAfterLoosingSumo1 = timeAfterLoosingSumo2 = 0;

            
            base.Initialize();
        }






        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            clouds = Content.Load<Texture2D>("Clouds");
            heart = Content.Load<Texture2D>("heart");
            Temples = Content.Load<Texture2D>("Temples");
            sumoSleep = Content.Load<Texture2D>("sumoSleep");
            sumoNormal = Content.Load<Texture2D>("sumoNormal");
            jumpAtivated = Content.Load<Texture2D>("jumpActivated");
            brick = Content.Load<Texture2D>("brick");
            jumpDesactivated = Content.Load<Texture2D>("jumpDesactivated");
            button = Content.Load<Texture2D>("buttonStock1h");
            redSumo = Content.Load<Texture2D>("redSumo");
            blueSumo = Content.Load<Texture2D>("blueSumo");
            gameOver = Content.Load<Texture2D>("GO6");
            titles = Content.Load<SpriteFont>("galleryFont");

            _components = new List<Component>();
            
            
            angle = 0f;
            origin = new Vector2(0, 0);
            pos = new Vector2(0, 0);

            cloudsPosition = new Vector2(0, 0);
            templesPosition = new Vector2(0, 300);


            spriteBatchBackground = new SpriteBatch(GraphicsDevice);
            spriteBatchForeground = new SpriteBatch(GraphicsDevice);


            spriteBatchBackground.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Matrix.Identity);
            spriteBatchBackground.End();

            spriteBatchForeground.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Matrix.Identity);
            spriteBatchForeground.End();








        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //mState = Mouse.GetState();

            //PARALAX
            templesPosition.X += templesSpeed;
            // Si los templos se salen del lado derecho de la pantalla, reaparécelos en el lado izquierdo
            if (templesPosition.X > width)
            {
                templesPosition.X %= width; // Ajusta la posición utilizando el módulo
            }

            //UPDATE SUMOS
            inputSumo1();
            inputSumo2();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            


            //DIBUJAR PARALAX EN EL FONDO
            spriteBatchBackground.Begin();

            // spriteBatchBackground.Draw(clouds, pos, new Rectangle(0, 0, screenWidth, screenHeight), Color.White, angle, Vector2.Zero, 1, SpriteEffects.None, 0.9f); 
            spriteBatchBackground.Draw(clouds, new Rectangle(0, 0, width, height), Color.White); ;
            float scale = (float)width / Temples.Width;

            spriteBatchBackground.Draw(Temples, templesPosition, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0.8f);

            spriteBatchBackground.End();
            


            //DIBUJAR CANVAS

            _spriteBatch.Begin();
            canvas.Render(scene, delta, juego, lastWKeyPressTime, lastIKeyPressTime, delayTime, brush, heart, jumpAtivated, jumpDesactivated, brick, sumoNormal, sumoSleep, redSumo, blueSumo);
            _spriteBatch.End();

            
           
            //NO FUNCIONAN BIEN LAS VIDAS
            
            delta += 0.001f;
            //check if a sumo lost the round
            if (scene.Elements[0].defeated)
            {
                //set a timer to initiate the game again
                timeAfterLoosingSumo1++;
                if (timeAfterLoosingSumo1 >= 100)
                {
                    //despues agregar encapsulacion
                    juego.decreaseLifesSumo1();
                    if (juego.getLifesSumo1() > 0 && juego.getLifesSumo2() > 0)
                    {
                        juego.nextRound();
                        map = new Map(graphicsDevice);
                        scene = new Scene(width, height, graphicsDevice);
                        scene.AddSumo(new Vec2(750, 200), 60);
                        scene.AddSumo(new Vec2(1050, 200), 60);
                    }
                    else
                    {
                        spriteBatchBackground.Begin();

                       
                        spriteBatchBackground.Draw(clouds, new Rectangle(0, 0, width, height), Color.White); ;


                        //spriteBatchBackground.DrawString(titles, "FIN DEL JUEGO", new Vector2(450, height/2), Color.Black);
                        
                        spriteBatchBackground.Draw(gameOver, new Vector2(350, 0), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0.8f);

                        spriteBatchBackground.End();
                        return;
                    }

                }
            }

            if (scene.Elements[1].defeated)
            {
                timeAfterLoosingSumo2++;
                if (timeAfterLoosingSumo2 >= 100)
                {
                    juego.decreaseLifesSumo2();
                    if (juego.getLifesSumo1() > 0 && juego.getLifesSumo2() > 0)
                    {
                        
                        juego.nextRound();
                        map = new Map(graphicsDevice);
                        scene = new Scene(width, height, graphicsDevice);
                        scene.AddSumo(new Vec2(750, 200), 60);
                        scene.AddSumo(new Vec2(1050, 200), 60);
                    }
                    else
                    {
                        spriteBatchBackground.Begin();

                       
                        spriteBatchBackground.Draw(clouds, new Rectangle(0, 0, width, height), Color.White); ;


                        //spriteBatchBackground.DrawString(titles, "FIN DEL JUEGO", new Vector2(450, height / 2), Color.Black);
                        
                        spriteBatchBackground.Draw(gameOver, new Vector2( 350, 0), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0.8f);

                        spriteBatchBackground.End();
                        return;
                    }
                }
            }
            

           

            base.Draw(gameTime);
        }




        public void inputSumo1()
        {
            state = Keyboard.GetState();

            if (state.IsKeyUp(Keys.W)) { wKey = true; }
            if (state.IsKeyUp(Keys.A)) { aKey = true; }
            if (state.IsKeyUp(Keys.D)) { dKey = true; }

            if (!scene.Elements[0].knocked)
            {
                



                if (state.IsKeyDown(Keys.W))
                {
                    if (wKey && DateTime.Now - lastWKeyPressTime > delayTime)
                    {

                        scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X, scene.Elements[0].VPoints[0].pos.Y + 350);
                        wKey = false;
                        lastWKeyPressTime = DateTime.Now;
                    }

                    //SoundManagercs.soundEffect.Play(.5f,0,-1);
                    
                }

                if (state.IsKeyDown(Keys.A))
                {
                    if (aKey) { scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X + 50, scene.Elements[0].VPoints[0].pos.Y); aKey = false; }
                }

                if (state.IsKeyDown(Keys.D))
                {
                    if (dKey) { scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X - 50, scene.Elements[0].VPoints[0].pos.Y); dKey = false; }
                }


            }

  
        }



        public void inputSumo2()
        {
            state = Keyboard.GetState();

            if (state.IsKeyUp(Keys.Up)) { upKey = true; }
            if (state.IsKeyUp(Keys.Left)) { leftKey = true; }
            if (state.IsKeyUp(Keys.Right)) { rightKey = true; }

            if (!scene.Elements[1].knocked)
            {
                if (state.IsKeyDown(Keys.Up))
                {
                    if (upKey && DateTime.Now - lastIKeyPressTime > delayTime)
                    {
                        scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X, scene.Elements[1].VPoints[0].pos.Y + 350);
                        upKey = false;
                        lastIKeyPressTime = DateTime.Now;
                    }

                    //SoundManagercs.soundEffect.Play(.5f,0,-1);

                }

                if (state.IsKeyDown(Keys.Left))
                {
                    if (leftKey) { scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X + 50, scene.Elements[1].VPoints[0].pos.Y); leftKey = false; }
                }

                if (state.IsKeyDown(Keys.Right))
                {
                    if (rightKey) { scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X - 50, scene.Elements[1].VPoints[0].pos.Y); rightKey = false; }
                }


            }


        }
    }
}
