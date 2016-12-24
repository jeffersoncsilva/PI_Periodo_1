using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GhostInvader_SENAC_FINAL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BoardGame : Game
    {
        /*
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        


        public BoardGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        */

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //******************Conteudo Jogo---------------
        Vector2 screenSize;
        Tiro tiro;
        Pac pac;
        Cenas cena;
        Ghosts[,] ghostsPosicao = new Ghosts[5, 10];
        int a = 0, b = 0;
        //SoundEffect son1;
        TiroGhost[,] tiroGhostPosicao = new TiroGhost[5, 10];
        double segundo;                                          //armazena o segundo do jogo para o ghost poder atirar
        double proxSegundo = 1;
        Random col = new Random();
        private Vector2 pos44 = new Vector2(70, 530);
        private Texture2D fundo1, fundo2, fundo3, fundo4, fundo5;
        private Vector2 posBonus;                              //armazena a posição do bonus 1
        bool sai = false;                                     //para definir a hora exata do bonus ir
        SpriteFont pontuacao;
        private Texture2D bonus;                             //armazena o bonus de pontuação do jogo
        private Texture2D menuPrincipal;                    //armazena a imagem do menu principal
        private Texture2D credito;                         //armazena os creditos
        private Texture2D menuPausa;                      //armazena a imagen do menu pausa
        private Texture2D fimdejogo;
        private Vector2 pos = new Vector2(0, 0);         //posiciona os menus principais
        private Vector2 posOp = new Vector2(330, 364);  //para armazernar o ponto inicial do ponto de escolha dos menus
        private Texture2D op;                          //para armazenar o ponto que aparece nos menus
        bool menuPrin = true;                         //para saber quando mostrar o menu       
        bool pausa = false;                          //para saber quando aparecer pausa
        bool creditoAp = false;                     //para saber quando se desenha nova sprite com movimento dos olhos dos personagens
        bool faseConcluida = false;                //para saber se a faze foi concluida ou não
        bool jogoOver = false;
        bool perdeu = false;
        bool start = true;                        //bool para auxiliar na hora de mostrar a fase
        bool inicio = false;                     //o que vc FAS???
        int cont = 50;                          //contador numero de inimigos
        int contAuxiliar = 0;                  //contadro auxiliar para mudar a velocidade das naves na fimão ghosts.Move
        int fase = 1;                         //contador que conta as fazes do jogado
        int tela = 9;                        // 0 - Abertura - 9 e um numero esdruxulo para nao aparecer a historia no inicio
        int pontos;                         //conta a quantidade de pontos            
        int vida = 3;                      //representa a quantidade de vida
        //auxilia na hora de definir as posiçoes dos ghots        
        int linhaInicial, linha_01, linha_02, linha_03, linha_04, linha_05;

        int tamTelaX, tamTelaY;

        SoundEffect somFundo, somFundo2;
        SoundEffectInstance somFundoImp, somFundoImp2;


        private void iniciarTiroGhost(Ghosts[,] ghosts)
        {
            for (int l = 0; l < 5; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    tiroGhostPosicao[l, c] = new TiroGhost(Content.Load<Texture2D>("tiro"),
                        new Vector2(ghosts[l, c].Position.X + ghosts[l, c].Size.X / 2, ghosts[l, c].Position.Y + ghosts[l, c].Size.Y / 2),
                        new Vector2(40.0f, 40.0f),
                        new Vector2(ghostsPosicao[l, c].Speed.X, 00.0f));
                }
            }
        }

        private void DrawTiroGhost(SpriteBatch spriteBatch)
        {
            for (int l = 0; l < 5; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (tiroGhostPosicao[l, c].isVisible)
                    {
                        tiroGhostPosicao[l, c].Draw(spriteBatch);
                    }
                }
            }
        }

        private void MoveTiroGhost(TiroGhost[,] tiroGhost)
        {

            for (int l = 4; l >= 0; l--)
            {
                for (int c = 0; c < 10; c++)
                {
                    tiroGhost[l, c].Move(screenSize);
                }
            }

        }


        private void atirar()
        {
            if (segundo == 59)
            {
                proxSegundo = 1;
            }
            int aux;
            for (int l = 4; l >= 0; l--)
            {
                for (int c = 0; c < 10; c++)
                {
                    aux = col.Next(0, 9);
                    if (segundo == proxSegundo && ghostsPosicao[l, aux].isVisible)
                    {
                        tiroGhostPosicao[l, aux].Speed = new Vector2(00.0f, 05.0f);
                        proxSegundo += 1;
                    }
                    if (tiroGhostPosicao[l, aux].Position.Y + tiroGhostPosicao[l, aux].Speed.Y > graphics.PreferredBackBufferHeight)
                    {
                        tiroGhostPosicao[l, aux].Position = new Vector2(ghostsPosicao[l, aux].Position.X + ghostsPosicao[l, aux].Size.X / 2, ghostsPosicao[l, aux].Position.Y + ghostsPosicao[l, aux].Size.Y / 2);
                        tiroGhostPosicao[l, aux].Speed = new Vector2(ghostsPosicao[l, aux].Speed.X, 00.0f);
                    }
                }
                Console.WriteLine(segundo);
            }
        }


        //***************Fim Funções Tiro ghost       
        public BoardGame()  : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 768;
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            tamTelaX = graphics.PreferredBackBufferWidth;
            tamTelaY = graphics.PreferredBackBufferHeight;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pac = new Pac(Content.Load<Texture2D>("pac2"), new Vector2(472.0f, 725.0f), new Vector2(40.0f, 40.0f), new Vector2(05.0f, 00.0f));
            tiro = new Tiro(Content.Load<Texture2D>("tiro"), new Vector2(0, 0), new Vector2(15.0f, 15.0f), new Vector2(00.0f, 00.0f));
            cena = new Cenas(Content.Load<Texture2D>("ato1"),
                             Content.Load<Texture2D>("ato2"),
                             Content.Load<Texture2D>("ato3"),
                             Content.Load<Texture2D>("ato4"),
                             Content.Load<Texture2D>("ato5"),
                             Content.Load<Texture2D>("final"),
                             new Vector2(0, 0),
                             new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));



            fimdejogo = Content.Load<Texture2D>("fim");
            menuPausa = Content.Load<Texture2D>("pausa");
            credito = Content.Load<Texture2D>("creditos");
            op = Content.Load<Texture2D>("op");
            menuPrincipal = Content.Load<Texture2D>("menu");
            fundo1 = Content.Load<Texture2D>("Ato_1");
            fundo2 = Content.Load<Texture2D>("Ato_2");
            fundo3 = Content.Load<Texture2D>("Ato_3");
            fundo4 = Content.Load<Texture2D>("Ato_4");
            fundo5 = Content.Load<Texture2D>("Ato_5");
            bonus = Content.Load<Texture2D>("bonus_1");
            pontuacao = Content.Load<SpriteFont>("arial");
            somFundo = Content.Load<SoundEffect>("part3");
            somFundoImp = somFundo.CreateInstance();
            somFundoImp.IsLooped = true;
            somFundoImp.Play();

            somFundo2 = Content.Load<SoundEffect>("perseverar");
            somFundoImp2 = somFundo2.CreateInstance();
            somFundoImp2.IsLooped = true;

            //fimdejogo = Content.Load<Texture2D>("Gameover");
            linhaInicial = 0;
            organizarLinhas();
            iniciaGhostsFase1();
            iniciarTiroGhost(ghostsPosicao);
        }

        private void mudarFormaPac()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                pac.Textura = Content.Load<Texture2D>("pac");
            }
            else
            {
                pac.Textura = Content.Load<Texture2D>("pac2");
            }


        }

        private void bonus1()
        {
            int d = 0;
            Random x = new Random();
            if (segundo == x.Next(1, 59) && d == 0)
            {
                posBonus.X = x.Next(50, 718);
                sai = true;
            }
            if (sai)
            {
                posBonus = new Vector2(posBonus.X, posBonus.Y + 1);
            }

        }

        private void organizarLinhas()
        {
            Random random = new Random();
            int temp = random.Next(0, 3);
            if (temp == 1)
            {
                linhaInicial = 0;
            }
            else if (temp == 1)
            {
                linhaInicial = 1;
            }
            else if (temp == 3)
            {
                linhaInicial = 2;
            }
            //pence em uma logica para nao carregar imagens repetidas
            linha_01 = linhaInicial;
            linha_02 = linha_01 + 1;
            linha_03 = linha_02 + 1;
            linha_04 = linha_03 + 1;
            linha_05 = linha_04 + 1;
        }

        private void resetaGhost(Ghosts[,] ghosts, TiroGhost[,] tiroGhost)
        {
            if (faseConcluida)
            {
                for (int l = 0; l < 5; l++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        ghosts[l, c].isVisible = true;
                        tiroGhost[l, c].isVisible = true;
                    }
                }
                cont = 50;
                contAuxiliar = 0;
            }
        }

        private void Colisao(Tiro tiro, Ghosts[,] ghosts)
        {
            for (int l = 0; l < 5; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (tiro.isColides(ghostsPosicao[l, c]))
                    {
                        ghosts[l, c].isVisible = false;
                        tiroGhostPosicao[l, c].isVisible = false;
                        tiro.isVisible = false;
                        tiro.Position = new Vector2((pac.Position.X + pac.Size.X / 2 - tiro.Size.X / 2), pac.Position.Y);//fas com que o tiro nao "mate" mais de um fantasma
                        cont--;
                        pontos += 30;
                        if (cont < 40 && fase == 1 || fase == 2)
                        {
                            MudaVelocidadeGhost();
                        }
                        else
                        {
                            MudaVelocidadeGhost();
                        }

                    }
                }
            }
            if (cont == 0)
            {
                faseConcluida = true;
                organizarLinhas();
                tela++;
                start = true;
            }
        }

        private void ColisaoTiroGhots(TiroGhost[,] tiro, Pac pac)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tiro[i, j].isColides(pac) && tiro[i, j].isVisible)
                    {
                        vida -= 1;
                        tiro[i, j].isVisible = false;
                    }
                }
            }
            Console.WriteLine("Vida - " + vida);
        }

        private void Move(Ghosts[,] ghosts)
        {

            for (int l = 0; l < 5; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (ghosts[l, c].Position.Y < graphics.PreferredBackBufferHeight)
                        ghosts[l, c].Move(screenSize);
                }
            }
        }

        private void gameover()
        {

            for (int l = 0; l < 5; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (ghostsPosicao[l, c].Position.Y > tamTelaY - 150 && ghostsPosicao[l, c].isVisible)
                    {
                        perdeu = true;
                    }
                }
            }
        }

        private void DrawGhosts(SpriteBatch spriteBatch)
        {
            for (int l = 0; l < 5; l++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (ghostsPosicao[l, c].isVisible)
                    {
                        ghostsPosicao[l, c].Draw(spriteBatch);
                    }
                }
            }
        }

        private Texture2D carregarFantastama(int linha)
        {
            if (linha == 1)
            {
                return Content.Load<Texture2D>("NaveRosa1");
            }
            else if (linha == 2)
            {
                return Content.Load<Texture2D>("naveMarrom1");
            }
            else if (linha == 3)
            {
                return Content.Load<Texture2D>("NaveAzul1");
            }
            else
            {
                return Content.Load<Texture2D>("NaveVermelha1");
            }

        }

        private void iniciaGhostsFase1()
        {
            Random random = new Random();
            float pL = 60;
            for (int l = 0; l < 5; l++)
            {
                float pC = 110;
                for (int c = 0; c < 10; c++)
                {
                    if (l == 0)
                    {
                        ghostsPosicao[l, c] = new Ghosts(carregarFantastama(linha_01),
                                              new Vector2(pC, pL),
                                              new Vector2(40.0f, 40.0f), new Vector2(-01.0f, 00.0f));
                    }
                    else if (l == 1)
                    {
                        ghostsPosicao[l, c] = new Ghosts(carregarFantastama(linha_02),
                                              new Vector2(pC, pL),
                                              new Vector2(40.0f, 40.0f),
                                              new Vector2(01.0f, 00.0f));
                    }
                    else if (l == 2)
                    {
                        ghostsPosicao[l, c] = new Ghosts(carregarFantastama(linha_03),
                                              new Vector2(pC, pL),
                                              new Vector2(40.0f, 40.0f),
                                              new Vector2(-01.0f, 00.0f));
                    }
                    else if (l == 3)
                    {
                        ghostsPosicao[l, c] = new Ghosts(carregarFantastama(linha_04),
                                              new Vector2(pC, pL),
                                              new Vector2(40.0f, 40.0f),
                                              new Vector2(01.0f, 00.0f));
                    }
                    else if (l == 4)
                    {
                        ghostsPosicao[l, c] = new Ghosts(carregarFantastama(linha_05),
                                              new Vector2(pC, pL),
                                              new Vector2(40.0f, 40.0f),
                                              new Vector2(-01.0f, 00.0f));
                    }
                    pC += 80.0f;
                }
                pL += 80.0f;
            }
        }

        private void MudaVelocidadeGhost()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ghostsPosicao[i, j].Speed.X > 0)
                    {
                        ghostsPosicao[i, j].Speed += new Vector2(00.09f, 00.0f);
                        tiroGhostPosicao[i, j].Speed += new Vector2(00.09f, 00.0f);
                    }
                    else
                    {
                        ghostsPosicao[i, j].Speed += new Vector2(-00.09f, 00.0f);
                        tiroGhostPosicao[i, j].Speed += new Vector2(-00.09f, 00.0f);
                    }
                }
            }
        }

        private void reloadTiro()
        {
            tiro.Position = new Vector2((pac.Position.X + pac.Size.X / 2 - tiro.Size.X / 2), 725.0f);
            tiro.Speed = new Vector2(0.0f, 0.0f);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            #region
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (creditoAp)
                {
                    menuPrin = true;
                    fase = 0;
                    tela = 0;
                    creditoAp = false;
                }
                if (!menuPrin)
                {
                    pausa = true;
                    posOp = new Vector2(200, 265);
                }
            }
            #endregion

            #region
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (menuPrin && posOp.Y == 364)
                {//inia jogo
                    tela = 0;
                    menuPrin = false;
                }
                else if (menuPrin && posOp.Y == 450)
                {//credito jogo
                    creditoAp = true;
                    menuPrin = false;
                }
                else if (menuPrin && posOp.Y == 535)
                {//sai jogo
                    Exit();
                }
                else if (pausa && posOp.Y == 265)
                {
                    menuPrin = true;
                    pausa = false;
                }
                else if (pausa && posOp.Y == 410)
                {
                    Exit();
                }
                if (jogoOver && pos44.X == 70)//&& posOp.Y == 550)
                {
                    Exit();
                }
                if (tela == 6)
                {
                    menuPrin = true;
                    fase = 1;
                    tela = 0;
                }
            }
            #endregion

            mudarFormaPac();

            #region
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {

                tela = fase;
                start = false;
                inicio = true;

                if (contAuxiliar == 0)
                {
                    proxSegundo = gameTime.TotalGameTime.Seconds;
                    contAuxiliar = 1;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (pausa && a == 0)
                {
                    posOp = new Vector2(200, 410);
                    a = 1;
                }
                else if (menuPrin && b == 0)
                {
                    posOp = new Vector2(330, 450);
                    b = 1;
                }
                else if (menuPrin && b == 1)
                {
                    posOp = new Vector2(330, 535);
                    b = 2;
                }
                Console.WriteLine("b = " + b);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (pausa && a == 1)
                {
                    posOp = new Vector2(200, 265);
                    a = 0;
                }
                else if (menuPrin && b == 1)
                {
                    posOp = new Vector2(330, 364);
                    b = 0;
                }
                if (menuPrin && b == 2)
                {
                    posOp = new Vector2(330, 450);
                    b = 1;
                }
            }
            #endregion

            if (perdeu || vida == 0)
            {
                jogoOver = true;
                perdeu = false;
                posOp = new Vector2(70, 530);
            }


            #region
            if (!jogoOver)
                gameover();

            //verifica se bonus colidiu
            if (posBonus.X + 30 > pac.Position.X &&
                posBonus.X < pac.Position.X + pac.Size.X &&
                posBonus.Y + 30 > pac.Position.Y &&
                posBonus.Y < pac.Position.Y + pac.Size.Y && sai)
            {
                pontos += 100;
                sai = false;
            }

            //verifica se bonus colidiu FIM            

            if (contAuxiliar == 1)
            {
                segundo = gameTime.TotalGameTime.Seconds;
            }

            if (!tiro.isVisible)
            {
                reloadTiro();
            }
            if (faseConcluida)
            {
                contAuxiliar = 0;
                resetaGhost(ghostsPosicao, tiroGhostPosicao);
                fase += 1;
                faseConcluida = false;
                iniciaGhostsFase1();
                iniciarTiroGhost(ghostsPosicao);
                inicio = false;
                segundo = 0;
            }
            #endregion

            #region
            if (inicio && !jogoOver && !menuPrin)
            {
                pac.Move(graphics.PreferredBackBufferWidth);
                tiro.Move(screenSize, pac);
                switch (fase)
                {
                    //***********************Fase 1*************************************
                    case 1:
                        somFundoImp2.Play();
                        atirar();
                        MoveTiroGhost(tiroGhostPosicao);
                        ColisaoTiroGhots(tiroGhostPosicao, pac);
                        Move(ghostsPosicao);
                        Colisao(tiro, ghostsPosicao);
                        bonus1();
                        break;
                    //*************************FASE 2*************************************
                    case 2:
                        somFundoImp2.Play();
                        atirar();
                        MoveTiroGhost(tiroGhostPosicao);
                        ColisaoTiroGhots(tiroGhostPosicao, pac);
                        Move(ghostsPosicao);
                        Colisao(tiro, ghostsPosicao);
                        bonus1();
                        break;
                    //*************************FASE 3*************************************
                    case 3:
                        somFundoImp2.Play();
                        atirar();
                        MoveTiroGhost(tiroGhostPosicao);
                        ColisaoTiroGhots(tiroGhostPosicao, pac);
                        Move(ghostsPosicao);
                        Colisao(tiro, ghostsPosicao);
                        bonus1();
                        break;
                    //*************************FASE 4*************************************
                    case 4:
                        somFundoImp2.Play();
                        atirar();
                        MoveTiroGhost(tiroGhostPosicao);
                        ColisaoTiroGhots(tiroGhostPosicao, pac);
                        Move(ghostsPosicao);
                        Colisao(tiro, ghostsPosicao);
                        bonus1();
                        break;
                    //*************************FASE 5*************************************
                    case 5:
                        somFundoImp2.Play();
                        atirar();
                        MoveTiroGhost(tiroGhostPosicao);
                        ColisaoTiroGhots(tiroGhostPosicao, pac);
                        Move(ghostsPosicao);
                        Colisao(tiro, ghostsPosicao);
                        bonus1();
                        break;
                }
            }
            #endregion

            cena.fase = fase;
            if (fase > 6)
            {
                menuPrin = true;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if (menuPrin)
            {
                spriteBatch.Draw(menuPrincipal, pos, Color.White);
                spriteBatch.Draw(op, posOp, Color.White);
            }
            else if (creditoAp)
            {
                spriteBatch.Draw(credito, pos, Color.White);
            }
            else if (pausa)
            {
                spriteBatch.Draw(menuPausa, pos, Color.White);
                spriteBatch.Draw(op, posOp, Color.White);
            }
            else if (!menuPrin && !pausa && !creditoAp)
            {
                if (tela == 0)
                {
                    cena.Draw(spriteBatch);
                    //fase 1 tela
                }
                else if (tela == 1)
                {
                    spriteBatch.Draw(fundo1, pos, Color.White);
                    spriteBatch.DrawString(pontuacao, "Pontos: " + pontos, new Vector2(5, 5), Color.Red);
                    if (sai)
                    {
                        spriteBatch.Draw(bonus, posBonus, Color.White);
                    }
                    tiro.Draw(spriteBatch);
                    pac.Draw(spriteBatch);
                    DrawTiroGhost(spriteBatch);
                    DrawGhosts(spriteBatch);
                    //fase 1 game
                }
                else if (tela == 2 && start)
                {
                    cena.Draw(spriteBatch);

                    //fase 2 tela
                }
                else if (tela == 2)
                {
                    spriteBatch.Draw(fundo2, pos, Color.White);
                    spriteBatch.DrawString(pontuacao, "Pontos: " + pontos, new Vector2(5, 5), Color.Red);
                    tiro.Draw(spriteBatch);
                    pac.Draw(spriteBatch);
                    DrawTiroGhost(spriteBatch);
                    DrawGhosts(spriteBatch);
                    //fase 2 game
                }
                else if (tela == 3 && start)
                {
                    cena.Draw(spriteBatch);

                    //fase 3 tela
                }
                else if (tela == 3)
                {
                    spriteBatch.Draw(fundo3, pos, Color.White);
                    spriteBatch.DrawString(pontuacao, "Pontos: " + pontos, new Vector2(5, 5), Color.Red);
                    tiro.Draw(spriteBatch);
                    pac.Draw(spriteBatch);
                    DrawTiroGhost(spriteBatch);
                    DrawGhosts(spriteBatch);
                    //fase 3 game
                }
                else if (tela == 4 && start)
                {
                    cena.Draw(spriteBatch);

                    //fase 4 tela
                }
                else if (tela == 4)
                {
                    spriteBatch.Draw(fundo4, pos, Color.White);
                    spriteBatch.DrawString(pontuacao, "Pontos: " + pontos, new Vector2(5, 5), Color.Red);
                    tiro.Draw(spriteBatch);
                    pac.Draw(spriteBatch);
                    DrawTiroGhost(spriteBatch);
                    DrawGhosts(spriteBatch);
                    //fase 4 game
                }
                else if (tela == 5 && start)
                {
                    cena.Draw(spriteBatch);

                    //fase 5 tela
                }
                else if (tela == 5)
                {
                    spriteBatch.Draw(fundo5, pos, Color.White);
                    spriteBatch.DrawString(pontuacao, "Pontos: " + pontos, new Vector2(5, 5), Color.Red);
                    tiro.Draw(spriteBatch);
                    pac.Draw(spriteBatch);
                    DrawTiroGhost(spriteBatch);
                    DrawGhosts(spriteBatch);
                    //fase 5 game
                }
                else if (tela == 6)
                {
                    cena.Draw(spriteBatch);
                }
            }
            if (jogoOver)
            {
                spriteBatch.Draw(fimdejogo, pos, Color.White);
                spriteBatch.Draw(op, pos44, Color.White);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

    }
}
