using GhostInvadersFinal.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GhostInvadersFinal
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BoardGame : Game
    {
        public static int LarguraDaTela = 800;
        public static int AlturaDaTela = 600;
        public static bool GameIsPaused = false;
        public static bool GameIsStarted = false;
        public static Game Board;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        ControladorDeTelas controladorDeTelas;

   

        public BoardGame()
        {
            Board = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = AlturaDaTela;
            graphics.PreferredBackBufferWidth = LarguraDaTela;

            //Pega a resolução do video da tela e ajusta para o jogo usar a resolução do monitor do jogo.
            //AlturaDaTela = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //LarguraDaTela = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //graphics.PreferredBackBufferHeight = AlturaDaTela;
            //graphics.PreferredBackBufferWidth = LarguraDaTela;
            //graphics.IsFullScreen = true;

            //cria uma nova tela de jogo.
            
            
        }

        protected override void Initialize()
        {
            this.controladorDeTelas = new ControladorDeTelas();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.controladorDeTelas.LoadContent(Content);
            //this.controladorDeTelas = new ControladorDeTelas(Content.Load<SpriteFont>("Fonts/Ghost Of The Wild West"));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            this.controladorDeTelas.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.White);
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            this.controladorDeTelas.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    
        public static void FecharJogo()
        {
            Board.Exit();
        }

    }
}
