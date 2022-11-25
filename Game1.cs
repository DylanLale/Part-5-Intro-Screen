using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Emit;
using System.Threading;

namespace Part_5__Intro_Screen
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        enum Screen
        {
            Intro,
            TribbleYard
        }
        SoundEffect StarTrekTheme;
        Screen screen;
        MouseState mouseState; 
        Texture2D tribblebrownTexture;
        Texture2D tribblecreamTexture;
        Texture2D tribbleorangeTexture;
        Texture2D tribblegreyTexture;
        Texture2D backgroundTexture;
        Texture2D tribbleIntroTexture;
        Texture2D GameoverTexture;
        Rectangle GameoverRect;
        Rectangle tribblegreyRect;
        Vector2 tribblegreySpeed;
        Rectangle tribblebrownRect;
        Vector2 tribblebrownSpeed;
        Rectangle tribblecreamRect;
        Vector2 tribblecreamSpeed;
        Rectangle tribbleorangeRect;
        Vector2 tribbleorangeSpeed;
        SpriteFont Instruction;
        float seconds;
        float startTime;
        Random generator = new Random();

        public Game1()
        {
            
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
    }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            tribblegreySpeed = new Vector2(2, 0);
            tribblegreyRect = new Rectangle(300, 10, generator.Next(10, 100), generator.Next(10, 100));
            tribblebrownSpeed = new Vector2(1, 2);
            tribblebrownRect = new Rectangle(300, 10, generator.Next(10, 100), generator.Next(10, 100));
            tribblecreamSpeed = new Vector2(2, 0);
            tribblecreamRect = new Rectangle(300, 10, generator.Next(10, 100), generator.Next(10, 100));
            tribbleorangeSpeed = new Vector2(0, 2);
            tribbleorangeRect = new Rectangle(400, 30, generator.Next(10, 100), generator.Next(10, 100));
            GameoverRect = new Rectangle(0, 0, 800, 500);
            startTime = 0;
            base.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribblebrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribblecreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleorangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribblegreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");
            backgroundTexture = Content.Load<Texture2D>("space");
            GameoverTexture = Content.Load<Texture2D>("gameover");
            StarTrekTheme = Content.Load<SoundEffect>("Star Trek Theme");
            Instruction = Content.Load<SpriteFont>("Instruction");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }
            else if (screen == Screen.TribbleYard)
            {
                tribblegreyRect.X += (int)tribblegreySpeed.X;
                tribblegreyRect.Y += (int)tribblegreySpeed.Y;
                if (tribblegreyRect.Right > 800 || tribblegreyRect.Left < 0)
                {
                    tribblegreySpeed.X *= -1;
                    tribblegreyRect = new Rectangle(400, 30, generator.Next(10, 100), generator.Next(10, 100));
                }




                tribblebrownRect.X += (int)tribblebrownSpeed.X;
                tribblebrownRect.Y += (int)tribblebrownSpeed.Y;
                if (tribblebrownRect.Right > 800 || tribblebrownRect.Left < 0)
                {
                    tribblebrownSpeed.X *= -1;
                    tribblebrownRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                }
                if (tribblebrownRect.Bottom > _graphics.PreferredBackBufferHeight || tribblebrownRect.Top < 0)
                {
                    tribblebrownSpeed.Y *= -1;
                    tribblebrownRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                }



                tribblecreamRect.X += (int)tribblecreamSpeed.X;
                tribblecreamRect.Y += (int)tribblecreamSpeed.Y;
                if (tribblecreamRect.Right > 800 || tribblecreamRect.Left < 0)
                {
                    tribblecreamSpeed.X *= -1;
                    tribblecreamRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                }
                if (tribblecreamRect.Bottom > _graphics.PreferredBackBufferHeight || tribblecreamRect.Top < 0)
                {
                    tribblecreamSpeed.Y *= -1;
                    tribblecreamRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                }



                tribbleorangeRect.X += (int)tribbleorangeSpeed.X;
                tribbleorangeRect.Y += (int)tribbleorangeSpeed.Y;
                if (tribbleorangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleorangeRect.Top < 0)
                {
                    tribbleorangeSpeed.Y *= -1;
                    tribbleorangeRect = new Rectangle(generator.Next(50, 400), (generator.Next(50, 400)), generator.Next(10, 100), generator.Next(10, 100));
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(Instruction, "Press left click to enter tribble field", new Vector2(175, 350), Color.White);
                StarTrekTheme.Play();
            }
            else if (screen == Screen.TribbleYard)
            {
            _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(tribblegreyTexture, tribblegreyRect, Color.White);
            _spriteBatch.Draw(tribblecreamTexture, tribblecreamRect, Color.White);
            _spriteBatch.Draw(tribbleorangeTexture, tribbleorangeRect, Color.White);
            _spriteBatch.Draw(tribblebrownTexture, tribblebrownRect, Color.White);
            }
            if (seconds >= 15)
                _spriteBatch.Draw(GameoverTexture, GameoverRect, Color.White);
            

            _spriteBatch.End();
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}