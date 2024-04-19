
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace PLAYGROUND
{
    public partial class MyForm : Form
    {
        Game game;
        Scene scene;
        Canvas canvas;
        Map map;
        
        
        float delta;
        bool wKey;
        bool sKey;
        bool aKey;
        bool dKey;

        bool iKey;
        bool kKey;
        bool jKey;
        bool lKey;

        DateTime lastWKeyPressTime;
        DateTime lastIKeyPressTime;

        int timeAfterLoosingSumo1;
        int timeAfterLoosingSumo2;
        int lifes;


        


        TimeSpan delayTime = TimeSpan.FromSeconds(2);
        public MyForm()
        {
            InitializeComponent();
            
            
            
            this.KeyUp += MyForm_KeyUp;
            this.KeyDown += MyForm_KeyDown;
            wKey = true;
            sKey = true;
            aKey = true;
            dKey = true;


            iKey = true;
            kKey = true;
            jKey = true;
            lKey = true;


            
            //now is static maybe later we can modify this with the user input

        }

        private void Init()
        {

            canvas = new Canvas(PCT_CANVAS);
            canvas.drawParalax();

            BUTTON3.Visible = true;
            BUTTON5.Visible = true;
            BUTTON7.Visible = true;
            label1.Visible = true;
            VIDAS.Visible = true;
            label2.Visible = false;

            //scene element 0 and element 1 will be sumos
            label1.Location = new Point((Width / 2) - label1.Width / 2, label1.Location.Y);
            label2.Location = new Point((Width / 2) - label2.Width / 2, label2.Location.Y);
            VIDAS.Location = new Point((Width / 2) - VIDAS.Width / 2, VIDAS.Location.Y);

            BUTTON5.Location = new Point((Width / 2) - BUTTON5.Width / 2, BUTTON5.Location.Y);

            BUTTON3.Location = new Point((Width / 2) - (BUTTON3.Width / 2)*5, BUTTON3.Location.Y);

            BUTTON7.Location = new Point((Width / 2) + (BUTTON7.Width / 2)*3, BUTTON7.Location.Y);

        }


        private void Finish()
        {
            TIMER.Enabled = false;
            canvas = new Canvas(PCT_CANVAS);
            canvas.drawParalax();

            BUTTON3.Visible = false;
            BUTTON5.Visible = false;
            BUTTON7.Visible = false;
            label1.Visible = false;
            VIDAS.Visible = false;
            label2.Visible = true;

            



        }

        private void InGame()
        {
            
            map = new Map(PCT_CANVAS.Size);
            scene = new Scene(PCT_CANVAS.Size);
            scene.AddSumo(new Vec2(600, 200), 60, PCT_CANVAS.Size, new Pen(Color.Green), Brushes.Gray);
            scene.AddSumo(new Vec2(1000, 200), 60, PCT_CANVAS.Size, new Pen(Color.Blue), Brushes.Black);

            BUTTON3.Visible = false;
            BUTTON5.Visible = false;
            BUTTON7.Visible = false;
            label1.Visible = false;
            VIDAS.Visible = false;

            //scene.AddPlatform(PCT_CANVAS.Size);
            delta = 0;

            timeAfterLoosingSumo1 = timeAfterLoosingSumo2 = 0;

        }

        private void MyForm_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            //map.Draw(new PointF(1.0f, 1.0f), PCT_CANVAS.Size);
            //PCT_CANVAS.Invalidate();

            
            
            canvas.Render(scene, delta, game,lastWKeyPressTime,lastIKeyPressTime,delayTime);
            delta += 0.001f;
            //check if a sumo lost the round
            if (scene.Elements[0].defeated)
            {    
                //set a timer to initiate the game again
                timeAfterLoosingSumo1++;
                if (timeAfterLoosingSumo1>=100)
                {
                    //despues agregar encapsulacion
                    game.decreaseLifesSumo1();
                    if (game.getLifesSumo1() > 0 && game.getLifesSumo2() > 0)
                    {
                        game.nextRound();
                        InGame();
                    }
                    else
                    {
                        Finish();
                        return;
                    }
                    
                }
            }

            if (scene.Elements[1].defeated)
            {
                timeAfterLoosingSumo2++;
                if (timeAfterLoosingSumo2 >= 100)
                {
                    game.decreaseLifesSumo2();
                    if (game.getLifesSumo1() > 0 && game.getLifesSumo2() > 0)
                    {
                        game.nextRound();
                        InGame();
                    }
                    else
                    {
                        Finish();
                        return;
                    }
                }
            }

        }


        

        private void ADD_POINT_BTN_Click(object sender, EventArgs e)
        {
            Init();
        }

        
        private void MyForm_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    wKey = true;
                    break;
                case Keys.S:
                    sKey = true;
                    break;
                case Keys.A:
                    aKey = true;
                    break;
                case Keys.D:
                    dKey = true;
                    break;
                case Keys.Space:
                    break;
            }

            switch (e.KeyCode)
            {
                case Keys.I:
                    iKey = true;
                    break;
                case Keys.K:
                    kKey = true;
                    break;
                case Keys.J:
                    jKey = true;
                    break;
                case Keys.L:
                    lKey = true;
                    break;
                case Keys.Space:
                    break;
            }

        }

        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            //movement sumo 1
            if (!scene.Elements[0].knocked)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        if (wKey && DateTime.Now - lastWKeyPressTime > delayTime)
                        {
                            //agregar encapsulacion a todo esto
                            scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X, scene.Elements[0].VPoints[0].pos.Y + 300);
                            wKey = false;
                            lastWKeyPressTime = DateTime.Now;
                        }
                        break;

                    /*case Keys.S:
                        if (sKey) { scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X, scene.Elements[0].VPoints[0].pos.Y - 2000); sKey = false; }
                        break;*/

                    case Keys.A:
                        if (aKey) { scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X + 40, scene.Elements[0].VPoints[0].pos.Y); aKey = false; }
                        break;

                    case Keys.D:
                        if (dKey) { scene.Elements[0].VPoints[0].old = new Vec2(scene.Elements[0].VPoints[0].pos.X - 40, scene.Elements[0].VPoints[0].pos.Y); dKey = false; }
                        break;
                    case Keys.Space:
                        break;
                }
            }

            //movement sumo 2
            if (!scene.Elements[1].knocked)
            {
                switch (e.KeyCode)
                {
                    case Keys.I:
                        if (iKey && DateTime.Now - lastIKeyPressTime > delayTime)
                        {
                            scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X, scene.Elements[1].VPoints[0].pos.Y + 300);
                            iKey = false;
                            lastIKeyPressTime = DateTime.Now;
                        }
                        break;

                    /*case Keys.K:
                        if (kKey) { scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X, scene.Elements[1].VPoints[0].pos.Y - 2000); kKey = false; }
                        break;*/

                    case Keys.J:
                        if (jKey) { scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X + 40, scene.Elements[1].VPoints[0].pos.Y); jKey = false; }
                        break;

                    case Keys.L:
                        if (lKey) { scene.Elements[1].VPoints[0].old = new Vec2(scene.Elements[1].VPoints[0].pos.X - 40, scene.Elements[1].VPoints[0].pos.Y); lKey = false; }
                        break;
                    case Keys.Space:
                        break;
                }
            }



        }

        private void PCT_CANVAS_Click(object sender, EventArgs e)
        {

        }

        private void BUTTON3_Click(object sender, EventArgs e)
        {
            lifes = 1;
            game = new Game(lifes);
            InGame();
            TIMER.Enabled = true;

            
        }

        private void BUTTON5_Click(object sender, EventArgs e)
        {
            lifes = 3;
            game = new Game(lifes);
            InGame();
            TIMER.Enabled = true;

            
        }

        private void BUTTON7_Click(object sender, EventArgs e)
        {
            lifes = 5;
            game = new Game(lifes);
            InGame();
            TIMER.Enabled = true;

            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Init();
        }

    }


}