using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Memory;

namespace SuperEd
{
    public partial class Form1 : Form
    {
        private readonly Mem mem = new Mem();
        private readonly Form2 Form2 = null;
        private int pID = 0;
        private int currentBackground = 0;
        private bool processRunning = false;
        private bool tabDown = false;
        private readonly string version = "V2.22";
        private readonly KeyHook keyHook = new KeyHook();

        public Form1()
        {
            InitializeComponent();
            Form2 = new Form2(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label32.Text = version;

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            keyHook.KeyDown += new KeyHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            keyHook.KeyUp += new KeyHook.KeyboardHookCallback(KeyboardHook_KeyUp);
            keyHook.Install();
        }

        private void KeyboardHook_KeyUp(KeyHook.VKeys key)
        {
            if (processRunning)
            {
                switch (key)
                {
                    case KeyHook.VKeys.KEY_TAB: { tabDown = false; break; }
                    case KeyHook.VKeys.KEY_F1: { if (!IsInTitleScreen()) { if (checkBox1.Checked) { checkBox1.Checked = false; } else if (!checkBox1.Checked) { checkBox1.Checked = true; } } break; }
                    case KeyHook.VKeys.KEY_F2: { if (!IsInTitleScreen()) { if (checkBox2.Checked) { checkBox2.Checked = false; } else if (!checkBox2.Checked) { checkBox2.Checked = true; } } break; }
                    case KeyHook.VKeys.KEY_F3:
                        {
                            if (!IsInTitleScreen())
                            {
                                if (checkBox3.Checked)
                                {
                                    mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pWeapon2, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pBowtieInventoryIcon, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pDivinghelmetInventoryIcon, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pChameleonbeltInventoryIcon, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickAttack, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickMechanism, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickMoveStoneL, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickBlowpipe, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickPogo, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickPogoAttack, "byte", "0x00");
                                    mem.WriteMemory(Pointers.pStickMoveStoneH, "byte", "0x00");
                                }
                                else if (!checkBox3.Checked)
                                {
                                    mem.WriteMemory(Pointers.pWeapon1, "byte", "0xFF");
                                    mem.WriteMemory(Pointers.pWeapon2, "byte", "0x03");
                                    mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pBowtieInventoryIcon, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pDivinghelmetInventoryIcon, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pChameleonbeltInventoryIcon, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickAttack, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickMechanism, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickMoveStoneL, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickBlowpipe, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickPogo, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickPogoAttack, "byte", "0x01");
                                    mem.WriteMemory(Pointers.pStickMoveStoneH, "byte", "0x01");
                                }
                            }
                            break;
                        }
                }
            }
        }
        private void SetBackground(int backgroundID)
        {
            switch (backgroundID)
            {
                case 0: { mem.WriteMemory(Pointers.pBackground, "string", @"Menu\BkMenu.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 1: { mem.WriteMemory(Pointers.pBackground, "string", @"Menu\Special\Plus.bmp\0\0\0\0\0\0\0"); break; }
                case 2: { mem.WriteMemory(Pointers.pBackground, "string", @"Logo2.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 3: { mem.WriteMemory(Pointers.pBackground, "string", @"UbiSoft.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 4: { mem.WriteMemory(Pointers.pBackground, "string", @"Inventor\Inventaire_fond.bmp"); break; }

                case 5: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Ski.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 6: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Sud.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 7: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Cavedoc.bmp\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 8: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Carota.bmp\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 9: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\North.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 10: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\lecanyon.bmp\0\0\0\0\0\0\0\0\0\0"); break; }
                case 11: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Cock.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 12: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Marmite.bmp\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 13: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Pyramide.bmp\0\0\0\0\0\0\0\0\0\0\0"); break; }
                case 14: { mem.WriteMemory(Pointers.pBackground, "string", @"Level\Land.bmp\0\0\0\0\0\0\0\0\0\0\0\0\0\0"); break; }

                case 15: { mem.WriteMemory(Pointers.pBackground, "string", @"Credits\Credit01.bmp\0\0\0\0\0\0\0\0"); break; }
                case 16: { mem.WriteMemory(Pointers.pBackground, "string", @"Credits\Credit02.bmp\0\0\0\0\0\0\0\0"); break; }
                case 17: { mem.WriteMemory(Pointers.pBackground, "string", @"Credits\Credit03.bmp\0\0\0\0\0\0\0\0"); break; }
                case 18: { mem.WriteMemory(Pointers.pBackground, "string", @"Credits\Credit04.bmp\0\0\0\0\0\0\0\0"); break; }
                case 19: { mem.WriteMemory(Pointers.pBackground, "string", @"Credits\Credit05.bmp\0\0\0\0\0\0\0\0"); break; }
                case 20: { mem.WriteMemory(Pointers.pBackground, "string", @"Credits\Credit06.bmp\0\0\0\0\0\0\0\0"); break; }
            }
        }
        private void KeyboardHook_KeyDown(KeyHook.VKeys key)
        {
            if (key == KeyHook.VKeys.KEY_TAB) { tabDown = true; }
            if (key == KeyHook.VKeys.KEY_NUMPAD4 && tabDown == true)
            {
                if (currentBackground <= 0) { currentBackground = 20; }
                else { currentBackground--; }
                SetBackground(currentBackground);
            }
            if (key == KeyHook.VKeys.KEY_NUMPAD6 && tabDown == true)
            {
                if (currentBackground >= 20) { currentBackground = 0; }
                else { currentBackground++; }
                SetBackground(currentBackground);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            keyHook.KeyDown -= new KeyHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            keyHook.KeyUp -= new KeyHook.KeyboardHookCallback(KeyboardHook_KeyUp);
            keyHook.Uninstall();
        }
        private void Form1_Move(object sender, EventArgs e)
        {
            Form2.Location = new Point(Location.X + 765, Location.Y - 120);
            Form2.BringToFront();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (Form2.Visible) { Form2.Hide(); }
            else { Form2.Show(); }
        }
        private void Label37_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/Zhs6v55");
        }
        private void Label38_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://1drv.ms/u/s!AsgcQQ-C4Q3CkYEl9u9Gc7WPh35Rfg");
        }

        private bool IsInTitleScreen()
        {
            switch (mem.ReadString(Pointers.pTitleScreenCheck).ToLower())
            {
                case "": { return true; }
                case "bkmenu.bmp": { return true; }
                case "ft.bmp": { return true; }
                case ".bmp": { return true; }
            }
            if (mem.ReadString(Pointers.pTitleScreenCheck).Contains("\\0")) { return true; }
            return false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (label6.Text != ("6"))
            {
                switch (mem.ReadInt(Pointers.pSprings))
                {
                    default: { mem.WriteMemory(Pointers.pSprings, "int", 65536.ToString()); label6.Text = ("1"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pSprings, "int", 131072.ToString()); label6.Text = ("2"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pSprings, "int", 196608.ToString()); label6.Text = ("3"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pSprings, "int", 262144.ToString()); label6.Text = ("4"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pSprings, "int", 327680.ToString()); label6.Text = ("5"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pSprings, "int", 393216.ToString()); label6.Text = ("6"); break; }
                }
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (label6.Text != ("0"))
            {
                switch (mem.ReadInt(Pointers.pSprings))
                {
                    default: { mem.WriteMemory(Pointers.pSprings, "int", 0.ToString()); label6.Text = ("0"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pSprings, "int", 0.ToString()); label6.Text = ("0"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pSprings, "int", 65536.ToString()); label6.Text = ("1"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pSprings, "int", 131072.ToString()); label6.Text = ("2"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pSprings, "int", 196608.ToString()); label6.Text = ("3"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pSprings, "int", 262144.ToString()); label6.Text = ("4"); break; }
                    case 393216: { mem.WriteMemory(Pointers.pSprings, "int", 327680.ToString()); label6.Text = ("5"); break; }
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (label8.Text != ("6"))
            {
                switch (mem.ReadInt(Pointers.pPinwheels))
                {
                    default: { mem.WriteMemory(Pointers.pPinwheels, "int", 65536.ToString()); label8.Text = ("1"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pPinwheels, "int", 131072.ToString()); label8.Text = ("2"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pPinwheels, "int", 196608.ToString()); label8.Text = ("3"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pPinwheels, "int", 262144.ToString()); label8.Text = ("4"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pPinwheels, "int", 327680.ToString()); label8.Text = ("5"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pPinwheels, "int", 393216.ToString()); label8.Text = ("6"); break; }
                }
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            if (button6.Enabled == false) { button6.Enabled = true; button6.BackColor = Color.SandyBrown; }
            if (label8.Text != ("0"))
            {
                switch (mem.ReadInt(Pointers.pPinwheels))
                {
                    default: { mem.WriteMemory(Pointers.pPinwheels, "int", 0.ToString()); label8.Text = ("0"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pPinwheels, "int", 0.ToString()); label8.Text = ("0"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pPinwheels, "int", 65536.ToString()); label8.Text = ("1"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pPinwheels, "int", 131072.ToString()); label8.Text = ("2"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pPinwheels, "int", 196608.ToString()); label8.Text = ("3"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pPinwheels, "int", 262144.ToString()); label8.Text = ("4"); break; }
                    case 393216: { mem.WriteMemory(Pointers.pPinwheels, "int", 327680.ToString()); label8.Text = ("5"); break; }
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (label11.Text != ("6"))
            {
                switch (mem.ReadInt(Pointers.pJumpingStones))
                {
                    default: { mem.WriteMemory(Pointers.pJumpingStones, "int", 65536.ToString()); label11.Text = ("1"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pJumpingStones, "int", 131072.ToString()); label11.Text = ("2"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pJumpingStones, "int", 196608.ToString()); label11.Text = ("3"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pJumpingStones, "int", 262144.ToString()); label11.Text = ("4"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pJumpingStones, "int", 327680.ToString()); label11.Text = ("5"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pJumpingStones, "int", 393216.ToString()); label11.Text = ("6"); break; }
                }
            }
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            if (label11.Text != ("0"))
            {
                switch (mem.ReadInt(Pointers.pJumpingStones))
                {
                    default: { mem.WriteMemory(Pointers.pJumpingStones, "int", 0.ToString()); label11.Text = ("0"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pJumpingStones, "int", 0.ToString()); label11.Text = ("0"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pJumpingStones, "int", 65536.ToString()); label11.Text = ("1"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pJumpingStones, "int", 131072.ToString()); label11.Text = ("2"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pJumpingStones, "int", 196608.ToString()); label11.Text = ("3"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pJumpingStones, "int", 262144.ToString()); label11.Text = ("4"); break; }
                    case 393216: { mem.WriteMemory(Pointers.pJumpingStones, "int", 327680.ToString()); label11.Text = ("5"); break; }
                }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (label12.Text != ("6"))
            {
                switch (mem.ReadInt(Pointers.pFeathers))
                {
                    default: { mem.WriteMemory(Pointers.pFeathers, "int", 65536.ToString()); label12.Text = ("1"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pFeathers, "int", 131072.ToString()); label12.Text = ("2"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pFeathers, "int", 196608.ToString()); label12.Text = ("3"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pFeathers, "int", 262144.ToString()); label12.Text = ("4"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pFeathers, "int", 327680.ToString()); label12.Text = ("5"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pFeathers, "int", 393216.ToString()); label12.Text = ("6"); break; }
                }
            }
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            if (label12.Text != ("0"))
            {
                switch (mem.ReadInt(Pointers.pFeathers))
                {
                    default: { mem.WriteMemory(Pointers.pFeathers, "int", 0.ToString()); label12.Text = ("0"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pFeathers, "int", 0.ToString()); label12.Text = ("0"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pFeathers, "int", 65536.ToString()); label12.Text = ("1"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pFeathers, "int", 131072.ToString()); label12.Text = ("2"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pFeathers, "int", 196608.ToString()); label12.Text = ("3"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pFeathers, "int", 262144.ToString()); label12.Text = ("4"); break; }
                    case 393216: { mem.WriteMemory(Pointers.pFeathers, "int", 327680.ToString()); label12.Text = ("5"); break; }
                }
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (label15.Text != ("6"))
            {
                switch (mem.ReadInt(Pointers.pDominoes))
                {
                    default: { mem.WriteMemory(Pointers.pDominoes, "int", 65536.ToString()); label15.Text = ("1"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pDominoes, "int", 131072.ToString()); label15.Text = ("2"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pDominoes, "int", 196608.ToString()); label15.Text = ("3"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pDominoes, "int", 262144.ToString()); label15.Text = ("4"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pDominoes, "int", 327680.ToString()); label15.Text = ("5"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pDominoes, "int", 393216.ToString()); label15.Text = ("6"); break; }
                }
            }
        }
        private void Button14_Click(object sender, EventArgs e)
        {
            if (label15.Text != ("0"))
            {
                switch (mem.ReadInt(Pointers.pDominoes))
                {
                    default: { mem.WriteMemory(Pointers.pDominoes, "int", 0.ToString()); label15.Text = ("0"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pDominoes, "int", 0.ToString()); label15.Text = ("0"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pDominoes, "int", 65536.ToString()); label15.Text = ("1"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pDominoes, "int", 131072.ToString()); label15.Text = ("2"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pDominoes, "int", 196608.ToString()); label15.Text = ("3"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pDominoes, "int", 262144.ToString()); label15.Text = ("4"); break; }
                    case 393216: { mem.WriteMemory(Pointers.pDominoes, "int", 327680.ToString()); label15.Text = ("5"); break; }
                }
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            if (label16.Text != ("6"))
            {
                switch (mem.ReadInt(Pointers.pPiggyBanks))
                {
                    default: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 65536.ToString()); label16.Text = ("1"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 131072.ToString()); label16.Text = ("2"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 196608.ToString()); label16.Text = ("3"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 262144.ToString()); label16.Text = ("4"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 327680.ToString()); label16.Text = ("5"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 393216.ToString()); label16.Text = ("6"); break; }
                }
            }
        }
        private void Button15_Click(object sender, EventArgs e)
        {
            if (label16.Text != ("0"))
            {
                switch (mem.ReadInt(Pointers.pPiggyBanks))
                {
                    default: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 0.ToString()); label16.Text = ("0"); break; }
                    case 65536: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 0.ToString()); label16.Text = ("0"); break; }
                    case 131072: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 65536.ToString()); label16.Text = ("1"); break; }
                    case 196608: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 131072.ToString()); label16.Text = ("2"); break; }
                    case 262144: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 196608.ToString()); label16.Text = ("3"); break; }
                    case 327680: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 262144.ToString()); label16.Text = ("4"); break; }
                    case 393216: { mem.WriteMemory(Pointers.pPiggyBanks, "int", 327680.ToString()); label16.Text = ("5"); break; }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (label4.Text != ("10"))
            {
                switch (mem.ReadString(Pointers.pLevelName).ToLower())
                {
                    case ("totalski"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("sud0"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("cavedoc"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("carota"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("north"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 256.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 512.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 768.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1024.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1280.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1536.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1792.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 2048.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 2304.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 2560.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("lecanyon"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("cock01"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("pyramide"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                    case ("marmite"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 1.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 2.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 3.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 4.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 5.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 6.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 7.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 8.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 9.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 10.ToString()); label4.Location = new Point(6, 4); break; }
                            }
                            break;
                        }
                }
                switch (mem.ReadInt(Pointers.pSilverspadesText))
                {
                    default: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2561.ToString()); label4.Text = ("1"); break; }
                    case 2561: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2562.ToString()); label4.Text = ("2"); break; }
                    case 2562: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2563.ToString()); label4.Text = ("3"); break; }
                    case 2563: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2564.ToString()); label4.Text = ("4"); break; }
                    case 2564: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2565.ToString()); label4.Text = ("5"); break; }
                    case 2565: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2566.ToString()); label4.Text = ("6"); break; }
                    case 2566: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2567.ToString()); label4.Text = ("7"); break; }
                    case 2567: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2568.ToString()); label4.Text = ("8"); break; }
                    case 2568: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2569.ToString()); label4.Text = ("9"); break; }
                    case 2569: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2570.ToString()); label4.Text = ("10"); break; }
                }
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (label4.Text != ("0"))
            {
                switch (mem.ReadString(Pointers.pLevelName).ToLower())
                {
                    case ("totalski"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesTotalski, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("sud0"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesSud0, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("cavedoc"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesCavedoc, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("carota"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesCarota, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("north"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 256.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 512.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 768.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1024.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1280.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1536.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 1792.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 2048.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesNorth, "int", 2304.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("lecanyon"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesLecanyon, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("cock01"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesCock01, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("pyramide"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesPyramide, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                    case ("marmite"):
                        {
                            switch (mem.ReadInt(Pointers.pSilverspadesText))
                            {
                                default: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 0.ToString()); break; }
                                case 2561: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 0.ToString()); break; }
                                case 2562: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 1.ToString()); break; }
                                case 2563: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 2.ToString()); break; }
                                case 2564: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 3.ToString()); break; }
                                case 2565: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 4.ToString()); break; }
                                case 2566: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 5.ToString()); break; }
                                case 2567: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 6.ToString()); break; }
                                case 2568: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 7.ToString()); break; }
                                case 2569: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 8.ToString()); break; }
                                case 2570: { mem.WriteMemory(Pointers.pSilverspadesMarmite, "int", 9.ToString()); label4.Location = new Point(9, 4); break; }
                            }
                            break;
                        }
                }
                switch (mem.ReadInt(Pointers.pSilverspadesText))
                {
                    default: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2560.ToString()); label4.Text = ("0"); break; }
                    case 2561: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2560.ToString()); label4.Text = ("0"); break; }
                    case 2562: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2561.ToString()); label4.Text = ("1"); break; }
                    case 2563: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2562.ToString()); label4.Text = ("2"); break; }
                    case 2564: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2563.ToString()); label4.Text = ("3"); break; }
                    case 2565: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2564.ToString()); label4.Text = ("4"); break; }
                    case 2566: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2565.ToString()); label4.Text = ("5"); break; }
                    case 2567: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2566.ToString()); label4.Text = ("6"); break; }
                    case 2568: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2567.ToString()); label4.Text = ("7"); break; }
                    case 2569: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2568.ToString()); label4.Text = ("8"); break; }
                    case 2570: { mem.WriteMemory(Pointers.pSilverspadesText, "int", 2569.ToString()); label4.Text = ("9"); break; }
                }
            }
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            if (label22.Text != ("Yes"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x07"); break; }
                    case 8: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x0F"); break; }
                    case 112: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x77"); break; }
                    case 120: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x78"); break; }
                    case 128: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x87"); break; }
                    case 136: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x8F"); break; }
                    case 240: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF7"); break; }
                    case 248: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xFF"); break; }
                }
                mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickAttack, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickMechanism, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickMoveStoneL, "byte", "0x01");
                label22.Text = ("Yes");
                label22.ForeColor = Color.White;
                label22.BackColor = Color.DarkGoldenrod;
                label22.Location = new Point(3, 4);
                panel24.BackColor = Color.DarkGoldenrod;
                button28.Enabled = false;
                button28.BackColor = Color.WhiteSmoke;
                button21.Enabled = true;
                button21.BackColor = Color.DarkGoldenrod;
            }
        }
        private void Button21_Click(object sender, EventArgs e)
        {
            if (label22.Text != ("No"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 7: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 15: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x08"); break; }
                    case 119: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x70"); break; }
                    case 127: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x78"); break; }
                    case 135: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x80"); break; }
                    case 143: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x88"); break; }
                    case 247: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF0"); break; }
                    case 255: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF8"); break; }
                }
                mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x00");
                mem.WriteMemory(Pointers.pStickAttack, "byte", "0x0");
                mem.WriteMemory(Pointers.pStickMechanism, "byte", "0x00");
                mem.WriteMemory(Pointers.pStickMoveStoneL, "byte", "0x00");
                label22.Text = ("No");
                label22.ForeColor = Color.FromArgb(80, 80, 80);
                label22.BackColor = Color.WhiteSmoke;
                label22.Location = new Point(10, 4);
                panel24.BackColor = Color.WhiteSmoke;
                button28.Enabled = true;
                button28.BackColor = Color.DarkGoldenrod;
                button21.Enabled = false;
                button21.BackColor = Color.WhiteSmoke;
            }
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            if (label19.Text != ("Yes"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x08"); break; }
                    case 7: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x0F"); break; }
                    case 112: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x78"); break; }
                    case 119: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x7F"); break; }
                    case 128: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x88"); break; }
                    case 135: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x8F"); break; }
                    case 240: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF8"); break; }
                    case 247: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xFF"); break; }
                }
                mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickBlowpipe, "byte", "0x01");
                label19.Text = ("Yes");
                label19.ForeColor = Color.White;
                label19.BackColor = Color.BurlyWood;
                label19.Location = new Point(3, 4);
                panel21.BackColor = Color.BurlyWood;
                button25.Enabled = false;
                button25.BackColor = Color.WhiteSmoke;
                button18.Enabled = true;
                button18.BackColor = Color.BurlyWood;
            }
        }
        private void Button18_Click(object sender, EventArgs e)
        {
            if (label19.Text != ("No"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 8: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 15: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x07"); break; }
                    case 120: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x70"); break; }
                    case 127: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x77"); break; }
                    case 136: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x80"); break; }
                    case 143: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x87"); break; }
                    case 248: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF0"); break; }
                    case 255: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF7"); break; }
                }
                mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x00");
                mem.WriteMemory(Pointers.pStickBlowpipe, "byte", "0x00");
                label19.Text = ("No");
                label19.ForeColor = Color.FromArgb(80, 80, 80);
                label19.BackColor = Color.WhiteSmoke;
                label19.Location = new Point(10, 4);
                panel21.BackColor = Color.WhiteSmoke;
                button25.Enabled = true;
                button25.BackColor = Color.BurlyWood;
                button18.Enabled = false;
                button18.BackColor = Color.WhiteSmoke;
            }
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            if (label21.Text != ("Yes"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x80"); break; }
                    case 7: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x87"); break; }
                    case 8: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x88"); break; }
                    case 15: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x8F"); break; }
                    case 112: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF0"); break; }
                    case 119: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF7"); break; }
                    case 120: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF8"); break; }
                    case 127: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xFF"); break; }
                }
                mem.WriteMemory(Pointers.pBowtieInventoryIcon, "byte", "0x01");
                label21.Text = ("Yes");
                label21.ForeColor = Color.White;
                label21.BackColor = Color.Coral;
                label21.Location = new Point(3, 4);
                panel23.BackColor = Color.Coral;
                button27.Enabled = false;
                button27.BackColor = Color.WhiteSmoke;
                button20.Enabled = true;
                button20.BackColor = Color.Coral;
            }
        }
        private void Button20_Click(object sender, EventArgs e)
        {
            if (label21.Text != ("No"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 128: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 135: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x07"); break; }
                    case 136: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x08"); break; }
                    case 143: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x0F"); break; }
                    case 240: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x70"); break; }
                    case 247: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x77"); break; }
                    case 248: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x78"); break; }
                    case 255: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x7F"); break; }
                }
                mem.WriteMemory(Pointers.pBowtieInventoryIcon, "byte", "0x00");
                label21.Text = ("No");
                label21.ForeColor = Color.FromArgb(80, 80, 80);
                label21.BackColor = Color.WhiteSmoke;
                label21.Location = new Point(10, 4);
                panel23.BackColor = Color.WhiteSmoke;
                button27.Enabled = true;
                button27.BackColor = Color.Coral;
                button20.Enabled = false;
                button20.BackColor = Color.WhiteSmoke;
            }
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            if (label17.Text != ("Yes"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x70"); break; }
                    case 7: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x77"); break; }
                    case 8: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x78"); break; }
                    case 15: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x7F"); break; }
                    case 128: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF0"); break; }
                    case 135: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF7"); break; }
                    case 136: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xF8"); break; }
                    case 143: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0xFF"); break; }
                }
                mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickPogo, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickPogoAttack, "byte", "0x01");
                mem.WriteMemory(Pointers.pStickMoveStoneH, "byte", "0x01");
                label17.Text = ("Yes");
                label17.ForeColor = Color.White;
                label17.BackColor = Color.RosyBrown;
                label17.Location = new Point(3, 4);
                panel19.BackColor = Color.RosyBrown;
                button23.Enabled = false;
                button23.BackColor = Color.WhiteSmoke;
                button16.Enabled = true;
                button16.BackColor = Color.RosyBrown;
            }
        }
        private void Button16_Click(object sender, EventArgs e)
        {
            if (label17.Text != ("No"))
            {
                switch (mem.ReadByte(Pointers.pWeapon1))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 112: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x00"); break; }
                    case 119: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x07"); break; }
                    case 120: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x08"); break; }
                    case 127: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x0F"); break; }
                    case 240: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x80"); break; }
                    case 247: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x87"); break; }
                    case 248: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x88"); break; }
                    case 255: { mem.WriteMemory(Pointers.pWeapon1, "byte", "0x8F"); break; }
                }
                mem.WriteMemory(Pointers.pStickInventoryIcon, "byte", "0x00");
                mem.WriteMemory(Pointers.pStickPogo, "byte", "0x00");
                mem.WriteMemory(Pointers.pStickPogoAttack, "byte", "0x00");
                mem.WriteMemory(Pointers.pStickMoveStoneH, "byte", "0x00");
                label17.Text = ("No");
                label17.ForeColor = Color.FromArgb(80, 80, 80);
                label17.BackColor = Color.WhiteSmoke;
                label17.Location = new Point(10, 4);
                panel19.BackColor = Color.WhiteSmoke;
                button23.Enabled = true;
                button23.BackColor = Color.RosyBrown;
                button16.Enabled = false;
                button16.BackColor = Color.WhiteSmoke;
            }
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            if (label18.Text != ("Yes"))
            {
                switch (mem.ReadByte(Pointers.pWeapon2))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x01"); break; }
                    case 2: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x03"); break; }
                }
                mem.WriteMemory(Pointers.pDivinghelmetInventoryIcon, "byte", "0x01");
                label18.Text = ("Yes");
                label18.ForeColor = Color.White;
                label18.BackColor = Color.CadetBlue;
                label18.Location = new Point(3, 4);
                panel20.BackColor = Color.CadetBlue;
                button24.Enabled = false;
                button24.BackColor = Color.WhiteSmoke;
                button17.Enabled = true;
                button17.BackColor = Color.CadetBlue;
            }
        }
        private void Button17_Click(object sender, EventArgs e)
        {
            if (label18.Text != ("No"))
            {
                switch (mem.ReadByte(Pointers.pWeapon2))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x00"); break; }
                    case 1: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x00"); break; }
                    case 3: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x02"); break; }
                }
                mem.WriteMemory(Pointers.pDivinghelmetInventoryIcon, "byte", "0x00");
                label18.Text = ("No");
                label18.ForeColor = Color.FromArgb(80, 80, 80);
                label18.BackColor = Color.WhiteSmoke;
                label18.Location = new Point(10, 4);
                panel20.BackColor = Color.WhiteSmoke;
                button24.Enabled = true;
                button24.BackColor = Color.CadetBlue;
                button17.Enabled = false;
                button17.BackColor = Color.WhiteSmoke;
            }
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            if (label20.Text != ("Yes"))
            {
                switch (mem.ReadByte(Pointers.pWeapon2))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x02"); break; }
                    case 1: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x03"); break; }
                }
                mem.WriteMemory(Pointers.pChameleonbeltInventoryIcon, "byte", "0x01");
                label20.Text = ("Yes");
                label20.ForeColor = Color.White;
                label20.BackColor = Color.MediumSeaGreen;
                label20.Location = new Point(3, 4);
                panel22.BackColor = Color.MediumSeaGreen;
                button26.Enabled = false;
                button26.BackColor = Color.WhiteSmoke;
                button19.Enabled = true;
                button19.BackColor = Color.MediumSeaGreen;
            }
        }
        private void Button19_Click(object sender, EventArgs e)
        {
            if (label20.Text != ("No"))
            {
                switch (mem.ReadByte(Pointers.pWeapon2))
                {
                    default: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x00"); break; }
                    case 2: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x00"); break; }
                    case 3: { mem.WriteMemory(Pointers.pWeapon2, "byte", "0x01"); break; }
                }
                mem.WriteMemory(Pointers.pChameleonbeltInventoryIcon, "byte", "0x00");
                label20.Text = ("No");
                label20.ForeColor = Color.FromArgb(80, 80, 80);
                label20.BackColor = Color.WhiteSmoke;
                label20.Location = new Point(10, 4);
                panel22.BackColor = Color.WhiteSmoke;
                button26.Enabled = true;
                button26.BackColor = Color.MediumSeaGreen;
                button19.Enabled = false;
                button19.BackColor = Color.WhiteSmoke;
            }
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            if (label23.Text != ("16"))
            {
                switch (mem.ReadByte(Pointers.pRedspadesCurrent))
                {
                    default: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x01"); break; }
                    case 1: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x02"); break; }
                    case 2: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x03"); break; }
                    case 3: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x04"); break; }
                    case 4: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x05"); break; }
                    case 5: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x06"); break; }
                    case 6: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x07"); break; }
                    case 7: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x08"); break; }
                    case 8: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x09"); break; }
                    case 9: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0A"); break; }
                    case 10: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0B"); break; }
                    case 11: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0C"); break; }
                    case 12: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0D"); break; }
                    case 13: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0E"); break; }
                    case 14: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0F"); break; }
                    case 15: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x10"); break; }
                }
                if (Int32.Parse(label23.Text) >= Int32.Parse(label35.Text))
                {
                    switch (mem.ReadByte(Pointers.pRedspadesCurrent))
                    {
                        case 7: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x07"); break; }
                        case 8: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x08"); break; }
                        case 9: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x09"); break; }
                        case 10: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0A"); break; }
                        case 11: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0B"); break; }
                        case 12: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0C"); break; }
                        case 13: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0D"); break; }
                        case 14: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0E"); break; }
                        case 15: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0F"); break; }
                        case 16: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x10"); break; }
                    }
                }
            }
        }
        private void Button22_Click(object sender, EventArgs e)
        {
            if (label23.Text != ("0"))
            {
                switch (mem.ReadByte(Pointers.pRedspadesCurrent))
                {
                    default: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x00"); break; }
                    case 1: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x00"); break; }
                    case 2: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x01"); break; }
                    case 3: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x02"); break; }
                    case 4: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x03"); break; }
                    case 5: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x04"); break; }
                    case 6: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x05"); break; }
                    case 7: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x06"); break; }
                    case 8: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x07"); break; }
                    case 9: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x08"); break; }
                    case 10: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x09"); break; }
                    case 11: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0A"); break; }
                    case 12: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0B"); break; }
                    case 13: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0C"); break; }
                    case 14: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0D"); break; }
                    case 15: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0E"); break; }
                    case 16: { mem.WriteMemory(Pointers.pRedspadesCurrent, "byte", "0x0F"); break; }
                }
            }
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            if (label35.Text != ("16"))
            {
                switch (mem.ReadByte(Pointers.pRedspadesMax))
                {
                    default: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x01"); break; }
                    case 1: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x02"); break; }
                    case 2: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x03"); break; }
                    case 3: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x04"); break; }
                    case 4: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x05"); break; }
                    case 5: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x06"); break; }
                    case 6: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x07"); break; }
                    case 7: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x08"); break; }
                    case 8: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x09"); break; }
                    case 9: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0A"); break; }
                    case 10: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0B"); break; }
                    case 11: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0C"); break; }
                    case 12: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0D"); break; }
                    case 13: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0E"); break; }
                    case 14: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x0F"); break; }
                    case 15: { mem.WriteMemory(Pointers.pRedspadesMax, "byte", "0x10"); break; }
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                pID = mem.GetProcIdFromName(Pointers.executableName);
                if (pID > 0)
                {
                    processRunning = mem.OpenProcess(Pointers.executableName);

                    Console.WriteLine(mem.ReadString(Pointers.pTitleScreenCheck).ToLower());

                    if (InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            panel1.BackColor = Color.PaleGreen;
                            label1.Text = (" Game Status: Active");
                            if (!IsInTitleScreen())
                            {
                                switch (mem.ReadString(Pointers.pLevelName).ToLower())
                                {
                                    case ("Totalski"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: Totalski (Ski Slope)"); break; }
                                    case ("Sud0"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: Sud0 (South Plain)"); break; }
                                    case ("Cavedoc"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: Cavedoc (Doc's Cave)"); break; }
                                    case ("Carota"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: Carota (Vegetable's HQ)"); break; }
                                    case ("North"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: North (North Plain)"); break; }
                                    case ("lecanyon"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: LeCanyon (Canyon)"); break; }
                                    case ("cock01"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: cock01 (Glacier Cocktail)"); break; }
                                    case ("Pyramide"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: Pyramide (Pyramid)"); break; }
                                    case ("Marmite"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: Marmite (Pressure Cooker)"); break; }
                                    case ("land"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: land (Grogh's HQ)"); break; }
                                    case ("outro"): { Form2.SetMonitorValues("CurrentLevel", "Current Level: outro (Outro)"); break; }
                                }
                                Form2.SetMonitorValues("CurrentSaveGame", "Current Save Game: " + mem.ReadString(Pointers.pSaveGameName));
                                switch (mem.ReadInt(Pointers.pSprings))
                                {
                                    default: { Form2.SetMonitorValues("Springs", "Springs: 0/6"); label6.Text = ("0"); break; }
                                    case 65536: { Form2.SetMonitorValues("Springs", "Springs: 1/6"); label6.Text = ("1"); break; }
                                    case 131072: { Form2.SetMonitorValues("Springs", "Springs: 2/6"); label6.Text = ("2"); break; }
                                    case 196608: { Form2.SetMonitorValues("Springs", "Springs: 3/6"); label6.Text = ("3"); break; }
                                    case 262144: { Form2.SetMonitorValues("Springs", "Springs: 4/6"); label6.Text = ("4"); break; }
                                    case 327680: { Form2.SetMonitorValues("Springs", "Springs: 5/6"); label6.Text = ("5"); break; }
                                    case 393216: { Form2.SetMonitorValues("Springs", "Springs: 6/6"); label6.Text = ("6"); break; }
                                }
                                label6.ForeColor = Color.White;
                                label6.BackColor = Color.FromArgb(80, 80, 80);
                                panel7.BackColor = Color.FromArgb(80, 80, 80);
                                if (label6.Text == ("6"))
                                {
                                    button4.Enabled = false;
                                    button4.BackColor = Color.WhiteSmoke;
                                    button5.Enabled = true;
                                    button5.BackColor = Color.FromArgb(80, 80, 80);
                                }
                                else if (label6.Text == ("0"))
                                {
                                    button4.Enabled = true;
                                    button4.BackColor = Color.FromArgb(80, 80, 80);
                                    button5.Enabled = false;
                                    button5.BackColor = Color.WhiteSmoke;
                                }
                                else if (label6.Text != ("0") && label6.Text != ("6"))
                                {
                                    button4.Enabled = true;
                                    button4.BackColor = Color.FromArgb(80, 80, 80);
                                    button5.Enabled = true;
                                    button5.BackColor = Color.FromArgb(80, 80, 80);
                                }
                                switch (mem.ReadInt(Pointers.pPinwheels))
                                {
                                    default: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 0/6"); label8.Text = ("0"); break; }
                                    case 65536: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 1/6"); label8.Text = ("1"); break; }
                                    case 131072: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 2/6"); label8.Text = ("2"); break; }
                                    case 196608: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 3/6"); label8.Text = ("3"); break; }
                                    case 262144: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 4/6"); label8.Text = ("4"); break; }
                                    case 327680: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 5/6"); label8.Text = ("5"); break; }
                                    case 393216: { Form2.SetMonitorValues("Pinwheels", "pPinwheels: 6/6"); label8.Text = ("6"); break; }
                                }
                                label8.ForeColor = Color.White;
                                label8.BackColor = Color.SandyBrown;
                                panel9.BackColor = Color.SandyBrown;
                                if (label8.Text == ("6"))
                                {
                                    button6.Enabled = false;
                                    button6.BackColor = Color.WhiteSmoke;
                                    button7.Enabled = true;
                                    button7.BackColor = Color.SandyBrown;
                                }
                                else if (label8.Text == ("0"))
                                {
                                    button6.Enabled = true;
                                    button6.BackColor = Color.SandyBrown;
                                    button7.Enabled = false;
                                    button7.BackColor = Color.WhiteSmoke;
                                }
                                else if (label8.Text != ("0") && label8.Text != ("6"))
                                {
                                    button6.Enabled = true;
                                    button6.BackColor = Color.SandyBrown;
                                    button7.Enabled = true;
                                    button7.BackColor = Color.SandyBrown;
                                }
                                switch (mem.ReadInt(Pointers.pJumpingStones))
                                {
                                    default: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 0/6"); label11.Text = ("0"); break; }
                                    case 65536: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 1/6"); label11.Text = ("1"); break; }
                                    case 131072: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 2/6"); label11.Text = ("2"); break; }
                                    case 196608: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 3/6"); label11.Text = ("3"); break; }
                                    case 262144: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 4/6"); label11.Text = ("4"); break; }
                                    case 327680: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 5/6"); label11.Text = ("5"); break; }
                                    case 393216: { Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 6/6"); label11.Text = ("6"); break; }
                                }
                                label11.ForeColor = Color.White;
                                label11.BackColor = Color.LightSlateGray;
                                panel12.BackColor = Color.LightSlateGray;
                                if (label11.Text == ("6"))
                                {
                                    button8.Enabled = false;
                                    button8.BackColor = Color.WhiteSmoke;
                                    button10.Enabled = true;
                                    button10.BackColor = Color.LightSlateGray;
                                }
                                else if (label11.Text == ("0"))
                                {
                                    button8.Enabled = true;
                                    button8.BackColor = Color.LightSlateGray;
                                    button10.Enabled = false;
                                    button10.BackColor = Color.WhiteSmoke;
                                }
                                else if (label11.Text != ("0") && label11.Text != ("6"))
                                {
                                    button8.Enabled = true;
                                    button8.BackColor = Color.LightSlateGray;
                                    button10.Enabled = true;
                                    button10.BackColor = Color.LightSlateGray;
                                }
                                switch (mem.ReadInt(Pointers.pFeathers))
                                {
                                    default: { Form2.SetMonitorValues("Feathers", "pFeathers: 0/6"); label12.Text = ("0"); break; }
                                    case 65536: { Form2.SetMonitorValues("Feathers", "pFeathers: 1/6"); label12.Text = ("1"); break; }
                                    case 131072: { Form2.SetMonitorValues("Feathers", "pFeathers: 2/6"); label12.Text = ("2"); break; }
                                    case 196608: { Form2.SetMonitorValues("Feathers", "pFeathers: 3/6"); label12.Text = ("3"); break; }
                                    case 262144: { Form2.SetMonitorValues("Feathers", "pFeathers: 4/6"); label12.Text = ("4"); break; }
                                    case 327680: { Form2.SetMonitorValues("Feathers", "pFeathers: 5/6"); label12.Text = ("5"); break; }
                                    case 393216: { Form2.SetMonitorValues("Feathers", "pFeathers: 6/6"); label12.Text = ("6"); break; }
                                }
                                label12.ForeColor = Color.White;
                                label12.BackColor = Color.Plum;
                                panel13.BackColor = Color.Plum;
                                if (label12.Text == ("6"))
                                {
                                    button9.Enabled = false;
                                    button9.BackColor = Color.WhiteSmoke;
                                    button11.Enabled = true;
                                    button11.BackColor = Color.Plum;
                                }
                                else if (label12.Text == ("0"))
                                {
                                    button9.Enabled = true;
                                    button9.BackColor = Color.Plum;
                                    button11.Enabled = false;
                                    button11.BackColor = Color.WhiteSmoke;
                                }
                                else if (label12.Text != ("0") && label12.Text != ("6"))
                                {
                                    button9.Enabled = true;
                                    button9.BackColor = Color.Plum;
                                    button11.Enabled = true;
                                    button11.BackColor = Color.Plum;
                                }
                                switch (mem.ReadInt(Pointers.pDominoes))
                                {
                                    default: { Form2.SetMonitorValues("Dominoes", "pDominoes: 0/6"); label15.Text = ("0"); break; }
                                    case 65536: { Form2.SetMonitorValues("Dominoes", "pDominoes: 1/6"); label15.Text = ("1"); break; }
                                    case 131072: { Form2.SetMonitorValues("Dominoes", "pDominoes: 2/6"); label15.Text = ("2"); break; }
                                    case 196608: { Form2.SetMonitorValues("Dominoes", "pDominoes: 3/6"); label15.Text = ("3"); break; }
                                    case 262144: { Form2.SetMonitorValues("Dominoes", "pDominoes: 4/6"); label15.Text = ("4"); break; }
                                    case 327680: { Form2.SetMonitorValues("Dominoes", "pDominoes: 5/6"); label15.Text = ("5"); break; }
                                    case 393216: { Form2.SetMonitorValues("Dominoes", "pDominoes: 6/6"); label15.Text = ("6"); break; }
                                }
                                label15.ForeColor = Color.White;
                                label15.BackColor = Color.FromArgb(128, 64, 0);
                                panel16.BackColor = Color.FromArgb(128, 64, 0);
                                if (label15.Text == ("6"))
                                {
                                    button12.Enabled = false;
                                    button12.BackColor = Color.WhiteSmoke;
                                    button14.Enabled = true;
                                    button14.BackColor = Color.FromArgb(128, 64, 0);
                                }
                                else if (label15.Text == ("0"))
                                {
                                    button12.Enabled = true;
                                    button12.BackColor = Color.FromArgb(128, 64, 0);
                                    button14.Enabled = false;
                                    button14.BackColor = Color.WhiteSmoke;
                                }
                                else if (label15.Text != ("0") && label15.Text != ("6"))
                                {
                                    button12.Enabled = true;
                                    button12.BackColor = Color.FromArgb(128, 64, 0);
                                    button14.Enabled = true;
                                    button14.BackColor = Color.FromArgb(128, 64, 0);
                                }
                                switch (mem.ReadInt(Pointers.pPiggyBanks))
                                {
                                    default: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 0/6"); label16.Text = ("0"); break; }
                                    case 65536: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 1/6"); label16.Text = ("1"); break; }
                                    case 131072: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 2/6"); label16.Text = ("2"); break; }
                                    case 196608: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 3/6"); label16.Text = ("3"); break; }
                                    case 262144: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 4/6"); label16.Text = ("4"); break; }
                                    case 327680: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 5/6"); label16.Text = ("5"); break; }
                                    case 393216: { Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 6/6"); label16.Text = ("6"); break; }
                                }
                                label16.ForeColor = Color.White;
                                label16.BackColor = Color.DeepPink;
                                panel17.BackColor = Color.DeepPink;
                                if (label16.Text == ("6"))
                                {
                                    button13.Enabled = false;
                                    button13.BackColor = Color.WhiteSmoke;
                                    button15.Enabled = true;
                                    button15.BackColor = Color.DeepPink;
                                }
                                else if (label16.Text == ("0"))
                                {
                                    button13.Enabled = true;
                                    button13.BackColor = Color.DeepPink;
                                    button15.Enabled = false;
                                    button15.BackColor = Color.WhiteSmoke;
                                }
                                else if (label16.Text != ("0") && label16.Text != ("6"))
                                {
                                    button13.Enabled = true;
                                    button13.BackColor = Color.DeepPink;
                                    button15.Enabled = true;
                                    button15.BackColor = Color.DeepPink;
                                }
                                switch (mem.ReadByte(Pointers.pWeapon1))
                                {
                                    default:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 7:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 8:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 15:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 112:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 119:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 120:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 127:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                            label21.Text = ("No");
                                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                                            label21.BackColor = Color.WhiteSmoke;
                                            label21.Location = new Point(10, 4);
                                            panel23.BackColor = Color.WhiteSmoke;
                                            button27.Enabled = true;
                                            button27.BackColor = Color.Coral;
                                            button20.Enabled = false;
                                            button20.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 128:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 135:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 136:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 143:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                            label17.Text = ("No");
                                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                                            label17.BackColor = Color.WhiteSmoke;
                                            label17.Location = new Point(10, 4);
                                            panel19.BackColor = Color.WhiteSmoke;
                                            button23.Enabled = true;
                                            button23.BackColor = Color.RosyBrown;
                                            button16.Enabled = false;
                                            button16.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 240:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 247:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                            label19.Text = ("No");
                                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                                            label19.BackColor = Color.WhiteSmoke;
                                            label19.Location = new Point(10, 4);
                                            panel21.BackColor = Color.WhiteSmoke;
                                            button25.Enabled = true;
                                            button25.BackColor = Color.BurlyWood;
                                            button18.Enabled = false;
                                            button18.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 248:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: No");
                                            label22.Text = ("No");
                                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                                            label22.BackColor = Color.WhiteSmoke;
                                            label22.Location = new Point(10, 4);
                                            panel24.BackColor = Color.WhiteSmoke;
                                            button28.Enabled = true;
                                            button28.BackColor = Color.DarkGoldenrod;
                                            button21.Enabled = false;
                                            button21.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                    case 255:
                                        {
                                            Form2.SetMonitorValues("Stick", "Stick: Yes");
                                            label22.Text = ("Yes");
                                            label22.ForeColor = Color.White;
                                            label22.BackColor = Color.DarkGoldenrod;
                                            label22.Location = new Point(3, 4);
                                            panel24.BackColor = Color.DarkGoldenrod;
                                            button28.Enabled = false;
                                            button28.BackColor = Color.WhiteSmoke;
                                            button21.Enabled = true;
                                            button21.BackColor = Color.DarkGoldenrod;
                                            Form2.SetMonitorValues("Blowpipe", "Blowipe: Yes");
                                            label19.Text = ("Yes");
                                            label19.ForeColor = Color.White;
                                            label19.BackColor = Color.BurlyWood;
                                            label19.Location = new Point(3, 4);
                                            panel21.BackColor = Color.BurlyWood;
                                            button25.Enabled = false;
                                            button25.BackColor = Color.WhiteSmoke;
                                            button18.Enabled = true;
                                            button18.BackColor = Color.BurlyWood;
                                            Form2.SetMonitorValues("BowTie", "Bow Tie: Yes");
                                            label21.Text = ("Yes");
                                            label21.ForeColor = Color.White;
                                            label21.BackColor = Color.Coral;
                                            label21.Location = new Point(3, 4);
                                            panel23.BackColor = Color.Coral;
                                            button27.Enabled = false;
                                            button27.BackColor = Color.WhiteSmoke;
                                            button20.Enabled = true;
                                            button20.BackColor = Color.Coral;
                                            Form2.SetMonitorValues("PogoStick", "Pogo Stick: Yes");
                                            label17.Text = ("Yes");
                                            label17.ForeColor = Color.White;
                                            label17.BackColor = Color.RosyBrown;
                                            label17.Location = new Point(3, 4);
                                            panel19.BackColor = Color.RosyBrown;
                                            button23.Enabled = false;
                                            button23.BackColor = Color.WhiteSmoke;
                                            button16.Enabled = true;
                                            button16.BackColor = Color.RosyBrown;
                                            break;
                                        }
                                }
                                switch (mem.ReadByte(Pointers.pWeapon2))
                                {
                                    default:
                                        {
                                            Form2.SetMonitorValues("DivingHelmet", "Diving Helmet: No");
                                            label18.Text = ("No");
                                            label18.ForeColor = Color.FromArgb(80, 80, 80);
                                            label18.BackColor = Color.WhiteSmoke;
                                            label18.Location = new Point(10, 4);
                                            panel20.BackColor = Color.WhiteSmoke;
                                            button24.Enabled = true;
                                            button24.BackColor = Color.CadetBlue;
                                            button17.Enabled = false;
                                            button17.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("ChameleonBelt", "Chameleon Belt: No");
                                            label20.Text = ("No");
                                            label20.ForeColor = Color.FromArgb(80, 80, 80);
                                            label20.BackColor = Color.WhiteSmoke;
                                            label20.Location = new Point(10, 4);
                                            panel22.BackColor = Color.WhiteSmoke;
                                            button26.Enabled = true;
                                            button26.BackColor = Color.MediumSeaGreen;
                                            button19.Enabled = false;
                                            button19.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 1:
                                        {
                                            Form2.SetMonitorValues("DivingHelmet", "Diving Helmet: Yes");
                                            label18.Text = ("Yes");
                                            label18.ForeColor = Color.White;
                                            label18.BackColor = Color.CadetBlue;
                                            label18.Location = new Point(3, 4);
                                            panel20.BackColor = Color.CadetBlue;
                                            button24.Enabled = false;
                                            button24.BackColor = Color.WhiteSmoke;
                                            button17.Enabled = true;
                                            button17.BackColor = Color.CadetBlue;
                                            Form2.SetMonitorValues("ChameleonBelt", "Chameleon Belt: No");
                                            label20.Text = ("No");
                                            label20.ForeColor = Color.FromArgb(80, 80, 80);
                                            label20.BackColor = Color.WhiteSmoke;
                                            label20.Location = new Point(10, 4);
                                            panel22.BackColor = Color.WhiteSmoke;
                                            button26.Enabled = true;
                                            button26.BackColor = Color.MediumSeaGreen;
                                            button19.Enabled = false;
                                            button19.BackColor = Color.WhiteSmoke;
                                            break;
                                        }
                                    case 2:
                                        {
                                            Form2.SetMonitorValues("DivingHelmet", "Diving Helmet: No");
                                            label18.Text = ("No");
                                            label18.ForeColor = Color.FromArgb(80, 80, 80);
                                            label18.BackColor = Color.WhiteSmoke;
                                            label18.Location = new Point(10, 4);
                                            panel20.BackColor = Color.WhiteSmoke;
                                            button24.Enabled = true;
                                            button24.BackColor = Color.CadetBlue;
                                            button17.Enabled = false;
                                            button17.BackColor = Color.WhiteSmoke;
                                            Form2.SetMonitorValues("ChameleonBelt", "Chameleon Belt: Yes");
                                            label20.Text = ("Yes");
                                            label20.ForeColor = Color.White;
                                            label20.BackColor = Color.MediumSeaGreen;
                                            label20.Location = new Point(3, 4);
                                            panel22.BackColor = Color.MediumSeaGreen;
                                            button26.Enabled = false;
                                            button26.BackColor = Color.WhiteSmoke;
                                            button19.Enabled = true;
                                            button19.BackColor = Color.MediumSeaGreen;
                                            break;
                                        }
                                    case 3:
                                        {
                                            Form2.SetMonitorValues("DivingHelmet", "Diving Helmet: Yes");
                                            label18.Text = ("Yes");
                                            label18.ForeColor = Color.White;
                                            label18.BackColor = Color.CadetBlue;
                                            label18.Location = new Point(3, 4);
                                            panel20.BackColor = Color.CadetBlue;
                                            button24.Enabled = false;
                                            button24.BackColor = Color.WhiteSmoke;
                                            button17.Enabled = true;
                                            button17.BackColor = Color.CadetBlue;
                                            Form2.SetMonitorValues("ChameleonBelt", "Chameleon Belt: Yes");
                                            label20.Text = ("Yes");
                                            label20.ForeColor = Color.White;
                                            label20.BackColor = Color.MediumSeaGreen;
                                            label20.Location = new Point(3, 4);
                                            panel22.BackColor = Color.MediumSeaGreen;
                                            button26.Enabled = false;
                                            button26.BackColor = Color.WhiteSmoke;
                                            button19.Enabled = true;
                                            button19.BackColor = Color.MediumSeaGreen;
                                            break;
                                        }
                                }
                                Form2.SetMonitorValues("PosX", ("Position X: ") + mem.ReadFloat(Pointers.pPosX).ToString());
                                Form2.SetMonitorValues("PosY", ("Position Y: ") + mem.ReadFloat(Pointers.pPosY).ToString());
                                Form2.SetMonitorValues("PosZ", ("Position Z: ") + mem.ReadFloat(Pointers.pPosZ).ToString());
                                switch (mem.ReadByte(Pointers.pRedspadesCurrent))
                                {
                                    default: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 0"); label23.Text = ("0"); break; }
                                    case 1: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 1"); label23.Text = ("1"); break; }
                                    case 2: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 2"); label23.Text = ("2"); break; }
                                    case 3: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 3"); label23.Text = ("3"); break; }
                                    case 4: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 4"); label23.Text = ("4"); break; }
                                    case 5: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 5"); label23.Text = ("5"); break; }
                                    case 6: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 6"); label23.Text = ("6"); break; }
                                    case 7: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 7"); label23.Text = ("7"); break; }
                                    case 8: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 8"); label23.Text = ("8"); break; }
                                    case 9: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 9"); label23.Text = ("9"); break; }
                                    case 10: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 10"); label23.Text = ("10"); break; }
                                    case 11: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 11"); label23.Text = ("11"); break; }
                                    case 12: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 12"); label23.Text = ("12"); break; }
                                    case 13: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 13"); label23.Text = ("13"); break; }
                                    case 14: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 14"); label23.Text = ("14"); break; }
                                    case 15: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 15"); label23.Text = ("15"); break; }
                                    case 16: { Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades Current: 16"); label23.Text = ("16"); break; }
                                }
                                label23.ForeColor = Color.White;
                                label23.BackColor = Color.Crimson;
                                panel25.BackColor = Color.Crimson;
                                if (label23.Text == ("16"))
                                {
                                    button29.Enabled = false;
                                    button29.BackColor = Color.WhiteSmoke;
                                    button22.Enabled = true;
                                    button22.BackColor = Color.Crimson;
                                }
                                if (label23.Text == ("0"))
                                {
                                    button29.Enabled = true;
                                    button29.BackColor = Color.Crimson;
                                    button22.Enabled = false;
                                    button22.BackColor = Color.WhiteSmoke;
                                }
                                else if (label23.Text != ("16") && label23.Text != ("0"))
                                {
                                    button29.Enabled = true;
                                    button29.BackColor = Color.Crimson;
                                    button22.Enabled = true;
                                    button22.BackColor = Color.Crimson;
                                }
                                switch (mem.ReadByte(Pointers.pRedspadesMax))
                                {
                                    default: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 0"); label35.Text = ("0"); break; }
                                    case 1: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 1"); label35.Text = ("1"); break; }
                                    case 2: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 2"); label35.Text = ("2"); break; }
                                    case 3: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 3"); label35.Text = ("3"); break; }
                                    case 4: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 4"); label35.Text = ("4"); break; }
                                    case 5: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 5"); label35.Text = ("5"); break; }
                                    case 6: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 6"); label35.Text = ("6"); break; }
                                    case 7: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 7"); label35.Text = ("7"); break; }
                                    case 8: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 8"); label35.Text = ("8"); break; }
                                    case 9: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 9"); label35.Text = ("9"); break; }
                                    case 10: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 10"); label35.Text = ("10"); break; }
                                    case 11: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 11"); label35.Text = ("11"); break; }
                                    case 12: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 12"); label35.Text = ("12"); break; }
                                    case 13: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 13"); label35.Text = ("13"); break; }
                                    case 14: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 14"); label35.Text = ("14"); break; }
                                    case 15: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 15"); label35.Text = ("15"); break; }
                                    case 16: { Form2.SetMonitorValues("RedSpadesMax", "Red Spades Max: 16"); label35.Text = ("16"); break; }
                                }
                                label35.ForeColor = Color.White;
                                label35.BackColor = Color.Crimson;
                                panel32.BackColor = Color.Crimson;
                                if (label35.Text == ("16"))
                                {
                                    button31.Enabled = false;
                                    button31.BackColor = Color.WhiteSmoke;
                                }
                                if (label35.Text == ("0"))
                                {
                                    button31.Enabled = true;
                                    button31.BackColor = Color.Crimson;
                                }
                                else if (label35.Text != ("16") && label35.Text != ("0"))
                                {
                                    button31.Enabled = true;
                                    button31.BackColor = Color.Crimson;
                                }
                                switch (mem.ReadInt(Pointers.pSilverspadesText))
                                {
                                    default:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 0/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("0"); break;
                                        }
                                    case 2560:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 0/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("0"); break;
                                        }
                                    case 2561:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 1/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("1"); break;
                                        }
                                    case 2562:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 2/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("2"); break;
                                        }
                                    case 2563:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 3/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("3"); break;
                                        }
                                    case 2564:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 4/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("4"); break;
                                        }
                                    case 2565:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 5/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("5"); break;
                                        }
                                    case 2566:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 6/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("6"); break;
                                        }
                                    case 2567:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 7/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("7"); break;
                                        }
                                    case 2568:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 8/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("8"); break;
                                        }
                                    case 2569:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 9/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("9"); break;
                                        }
                                    case 2570:
                                        {
                                            Form2.SetMonitorValues("SilverSpades", "Silver Spades: 10/10 (" + mem.ReadString(Pointers.pLevelName) + (")"));
                                            label4.Text = ("10"); break;
                                        }
                                }
                                if (mem.ReadString(Pointers.pLevelName) != ("land") && mem.ReadString(Pointers.pLevelName) != ("LAND") && mem.ReadString(Pointers.pLevelName) != ("outro") && mem.ReadString(Pointers.pLevelName) != ("OUTRO"))
                                {
                                    label4.ForeColor = Color.White;
                                    label4.BackColor = Color.DarkGray;
                                    panel5.BackColor = Color.DarkGray;
                                    if (label4.Text == ("10"))
                                    {
                                        label4.Location = new Point(6, 4);
                                        button2.Enabled = false;
                                        button2.BackColor = Color.WhiteSmoke;
                                        button3.Enabled = true;
                                        button3.BackColor = Color.DarkGray;
                                    }
                                    if (label4.Text == ("0"))
                                    {
                                        label4.Location = new Point(9, 4);
                                        button2.Enabled = true;
                                        button2.BackColor = Color.DarkGray;
                                        button3.Enabled = false;
                                        button3.BackColor = Color.WhiteSmoke;
                                    }
                                    else if (label4.Text != ("10") && label4.Text != ("0"))
                                    {
                                        label4.Location = new Point(9, 4);
                                        button2.Enabled = true;
                                        button2.BackColor = Color.DarkGray;
                                        button3.Enabled = true;
                                        button3.BackColor = Color.DarkGray;
                                    }
                                }
                                checkBox1.Enabled = true;
                                checkBox2.Enabled = true;
                                checkBox3.Enabled = true;
                                if (checkBox1.Checked) { mem.WriteMemory(Pointers.pInvincible, "bytes", "0x90,0x90,0x90"); }
                                else { mem.WriteMemory(Pointers.pInvincible, "bytes", "0x88,0x41,0x14"); }
                                if (checkBox2.Checked) { mem.WriteMemory(Pointers.pModefly, "bytes", "0x01"); }
                                else { mem.WriteMemory(Pointers.pModefly, "bytes", "0x00"); }
                                if (mem.ReadByte(Pointers.pWeapon1) != 255 || mem.ReadByte(Pointers.pWeapon2) != 3) { checkBox3.Checked = false; }
                                else if (mem.ReadByte(Pointers.pWeapon1) == 255 && mem.ReadByte(Pointers.pWeapon2) == 3) { checkBox3.Checked = true; }
                            }
                            else
                            {
                                Form2.SetMonitorValues("CurrentLevel", "Current Level: Title Screen");
                                Form2.SetMonitorValues("CurrentSaveGame", "Current Save Game:");
                                Form2.SetMonitorValues("Springs", "Springs: 0");
                                label6.Text = ("0");
                                label6.ForeColor = Color.FromArgb(80, 80, 80);
                                label6.BackColor = Color.WhiteSmoke;
                                panel7.BackColor = Color.WhiteSmoke;
                                button4.Enabled = false;
                                button4.BackColor = Color.WhiteSmoke;
                                button5.Enabled = false;
                                button5.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("Pinwheels", "pPinwheels: 0");
                                label8.Text = ("0");
                                label8.ForeColor = Color.FromArgb(80, 80, 80);
                                label8.BackColor = Color.WhiteSmoke;
                                panel9.BackColor = Color.WhiteSmoke;
                                button6.Enabled = false;
                                button6.BackColor = Color.WhiteSmoke;
                                button7.Enabled = false;
                                button7.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("JumpingStones", "Jumping Stones: 0");
                                label11.Text = ("0");
                                label11.ForeColor = Color.FromArgb(80, 80, 80);
                                label11.BackColor = Color.WhiteSmoke;
                                panel12.BackColor = Color.WhiteSmoke;
                                button8.Enabled = false;
                                button8.BackColor = Color.WhiteSmoke;
                                button10.Enabled = false;
                                button10.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("Feathers", "pFeathers: 0");
                                label12.Text = ("0");
                                label12.ForeColor = Color.FromArgb(80, 80, 80);
                                label12.BackColor = Color.WhiteSmoke;
                                panel13.BackColor = Color.WhiteSmoke;
                                button9.Enabled = false;
                                button9.BackColor = Color.WhiteSmoke;
                                button11.Enabled = false;
                                button11.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("Dominoes", "pDominoes: 0");
                                label15.Text = ("0");
                                label15.ForeColor = Color.FromArgb(80, 80, 80);
                                label15.BackColor = Color.WhiteSmoke;
                                panel16.BackColor = Color.WhiteSmoke;
                                button12.Enabled = false;
                                button12.BackColor = Color.WhiteSmoke;
                                button14.Enabled = false;
                                button14.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("PiggyBanks", "Piggy Banks: 0");
                                label16.Text = ("0");
                                label16.ForeColor = Color.FromArgb(80, 80, 80);
                                label16.BackColor = Color.WhiteSmoke;
                                panel17.BackColor = Color.WhiteSmoke;
                                button13.Enabled = false;
                                button13.BackColor = Color.WhiteSmoke;
                                button15.Enabled = false;
                                button15.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("Stick", "Stick: No");
                                label22.Text = ("No");
                                label22.ForeColor = Color.FromArgb(80, 80, 80);
                                label22.BackColor = Color.WhiteSmoke;
                                panel24.BackColor = Color.WhiteSmoke;
                                button28.Enabled = false;
                                button28.BackColor = Color.WhiteSmoke;
                                button21.Enabled = false;
                                button21.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("Blowpipe", "Blowipe: No");
                                label19.Text = ("No");
                                label19.ForeColor = Color.FromArgb(80, 80, 80);
                                label19.BackColor = Color.WhiteSmoke;
                                panel21.BackColor = Color.WhiteSmoke;
                                button25.Enabled = false;
                                button25.BackColor = Color.WhiteSmoke;
                                button18.Enabled = false;
                                button18.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("BowTie", "Bow Tie: No");
                                label21.Text = ("No");
                                label21.ForeColor = Color.FromArgb(80, 80, 80);
                                label21.BackColor = Color.WhiteSmoke;
                                panel23.BackColor = Color.WhiteSmoke;
                                button27.Enabled = false;
                                button27.BackColor = Color.WhiteSmoke;
                                button20.Enabled = false;
                                button20.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("DivingHelmet", "Diving Helmet: No");
                                label18.Text = ("No");
                                label18.ForeColor = Color.FromArgb(80, 80, 80);
                                label18.BackColor = Color.WhiteSmoke;
                                panel20.BackColor = Color.WhiteSmoke;
                                button24.Enabled = false;
                                button24.BackColor = Color.WhiteSmoke;
                                button17.Enabled = false;
                                button17.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("ChameleonBelt", "Chameleon Belt: No");
                                label20.Text = ("No");
                                label20.ForeColor = Color.FromArgb(80, 80, 80);
                                label20.BackColor = Color.WhiteSmoke;
                                panel22.BackColor = Color.WhiteSmoke;
                                button26.Enabled = false;
                                button26.BackColor = Color.WhiteSmoke;
                                button19.Enabled = false;
                                button19.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("PogoStick", "Pogo Stick: No");
                                label17.Text = ("No");
                                label17.ForeColor = Color.FromArgb(80, 80, 80);
                                label17.BackColor = Color.WhiteSmoke;
                                panel19.BackColor = Color.WhiteSmoke;
                                button23.Enabled = false;
                                button23.BackColor = Color.WhiteSmoke;
                                button16.Enabled = false;
                                button16.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("PosX", ("Position X: 0.0"));
                                Form2.SetMonitorValues("PosY", ("Position Y: 0.0"));
                                Form2.SetMonitorValues("PosZ", ("Position Z: 0.0"));
                                Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades: 0");
                                Form2.SetMonitorValues("RedSpadesMax", "Red Spades: 0");
                                label23.Text = ("0");
                                label23.ForeColor = Color.FromArgb(80, 80, 80);
                                label23.BackColor = Color.WhiteSmoke;
                                label23.Location = new Point(9, 4);
                                panel25.BackColor = Color.WhiteSmoke;
                                button29.Enabled = false;
                                button29.BackColor = Color.WhiteSmoke;
                                button22.Enabled = false;
                                button22.BackColor = Color.WhiteSmoke;
                                label35.Text = ("0");
                                label35.ForeColor = Color.FromArgb(80, 80, 80);
                                label35.BackColor = Color.WhiteSmoke;
                                label35.Location = new Point(9, 4);
                                panel32.BackColor = Color.WhiteSmoke;
                                button31.Enabled = false;
                                button31.BackColor = Color.WhiteSmoke;
                                Form2.SetMonitorValues("SilverSpades", "Silver Spades: 0");
                                label4.Text = ("0");
                                label4.ForeColor = Color.FromArgb(80, 80, 80);
                                label4.BackColor = Color.WhiteSmoke;
                                label4.Location = new Point(9, 4);
                                panel5.BackColor = Color.WhiteSmoke;
                                button2.Enabled = false;
                                button2.BackColor = Color.WhiteSmoke;
                                button3.Enabled = false;
                                button3.BackColor = Color.WhiteSmoke;
                                checkBox1.Enabled = false;
                                checkBox1.Checked = false;
                                checkBox2.Enabled = false;
                                checkBox2.Checked = false;
                                checkBox3.Enabled = false;
                                checkBox3.Checked = false;
                            }
                        });
                    }
                }
                else if (pID <= 0)
                {
                    if (InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            panel1.BackColor = Color.FromArgb(255, 192, 192);
                            label1.Text = ("Game Status: Inactive");
                            Form2.SetMonitorValues("CurrentLevel", "Current Level:");
                            Form2.SetMonitorValues("CurrentSaveGame", "Current Save Game:");
                            Form2.SetMonitorValues("Springs", "Springs:");
                            label6.Text = ("");
                            label6.ForeColor = Color.FromArgb(80, 80, 80);
                            label6.BackColor = Color.WhiteSmoke;
                            panel7.BackColor = Color.WhiteSmoke;
                            button4.Enabled = false;
                            button4.BackColor = Color.WhiteSmoke;
                            button5.Enabled = false;
                            button5.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("Pinwheels", "pPinwheels:");
                            label8.Text = ("");
                            label8.ForeColor = Color.FromArgb(80, 80, 80);
                            label8.BackColor = Color.WhiteSmoke;
                            panel9.BackColor = Color.WhiteSmoke;
                            button6.Enabled = false;
                            button6.BackColor = Color.WhiteSmoke;
                            button7.Enabled = false;
                            button7.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("JumpingStones", "Jumping Stones:");
                            label11.Text = ("");
                            label11.ForeColor = Color.FromArgb(80, 80, 80);
                            label11.BackColor = Color.WhiteSmoke;
                            panel12.BackColor = Color.WhiteSmoke;
                            button8.Enabled = false;
                            button8.BackColor = Color.WhiteSmoke;
                            button10.Enabled = false;
                            button10.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("Feathers", "pFeathers:");
                            label12.Text = ("");
                            label12.ForeColor = Color.FromArgb(80, 80, 80);
                            label12.BackColor = Color.WhiteSmoke;
                            panel13.BackColor = Color.WhiteSmoke;
                            button9.Enabled = false;
                            button9.BackColor = Color.WhiteSmoke;
                            button11.Enabled = false;
                            button11.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("Dominoes", "pDominoes:");
                            label15.Text = ("");
                            label15.ForeColor = Color.FromArgb(80, 80, 80);
                            label15.BackColor = Color.WhiteSmoke;
                            panel16.BackColor = Color.WhiteSmoke;
                            button12.Enabled = false;
                            button12.BackColor = Color.WhiteSmoke;
                            button14.Enabled = false;
                            button14.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("PiggyBanks", "Piggy Banks:");
                            label16.Text = ("");
                            label16.ForeColor = Color.FromArgb(80, 80, 80);
                            label16.BackColor = Color.WhiteSmoke;
                            panel17.BackColor = Color.WhiteSmoke;
                            button13.Enabled = false;
                            button13.BackColor = Color.WhiteSmoke;
                            button15.Enabled = false;
                            button15.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("Stick", "Stick:");
                            label22.Text = ("");
                            label22.ForeColor = Color.FromArgb(80, 80, 80);
                            label22.BackColor = Color.WhiteSmoke;
                            panel24.BackColor = Color.WhiteSmoke;
                            button28.Enabled = false;
                            button28.BackColor = Color.WhiteSmoke;
                            button21.Enabled = false;
                            button21.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("Blowpipe", "Blowipe:");
                            label19.Text = ("");
                            label19.ForeColor = Color.FromArgb(80, 80, 80);
                            label19.BackColor = Color.WhiteSmoke;
                            panel21.BackColor = Color.WhiteSmoke;
                            button25.Enabled = false;
                            button25.BackColor = Color.WhiteSmoke;
                            button18.Enabled = false;
                            button18.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("BowTie", "Bow Tie:");
                            label21.Text = ("");
                            label21.ForeColor = Color.FromArgb(80, 80, 80);
                            label21.BackColor = Color.WhiteSmoke;
                            panel23.BackColor = Color.WhiteSmoke;
                            button27.Enabled = false;
                            button27.BackColor = Color.WhiteSmoke;
                            button20.Enabled = false;
                            button20.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("DivingHelmet", "Diving Helmet:");
                            label18.Text = ("");
                            label18.ForeColor = Color.FromArgb(80, 80, 80);
                            label18.BackColor = Color.WhiteSmoke;
                            panel20.BackColor = Color.WhiteSmoke;
                            button24.Enabled = false;
                            button24.BackColor = Color.WhiteSmoke;
                            button17.Enabled = false;
                            button17.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("ChameleonBelt", "Chameleon Belt:");
                            label20.Text = ("");
                            label20.ForeColor = Color.FromArgb(80, 80, 80);
                            label20.BackColor = Color.WhiteSmoke;
                            panel22.BackColor = Color.WhiteSmoke;
                            button26.Enabled = false;
                            button26.BackColor = Color.WhiteSmoke;
                            button19.Enabled = false;
                            button19.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("PogoStick", "Pogo Stick:");
                            label17.Text = ("");
                            label17.ForeColor = Color.FromArgb(80, 80, 80);
                            label17.BackColor = Color.WhiteSmoke;
                            panel19.BackColor = Color.WhiteSmoke;
                            button23.Enabled = false;
                            button23.BackColor = Color.WhiteSmoke;
                            button16.Enabled = false;
                            button16.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("PosX", ("Position X:"));
                            Form2.SetMonitorValues("PosY", ("Position Y:"));
                            Form2.SetMonitorValues("PosZ", ("Position Z:"));
                            Form2.SetMonitorValues("RedSpadesCurrent", "Red Spades:");
                            Form2.SetMonitorValues("RedSpadesMax", "Red Spades:");
                            label23.Text = ("");
                            label23.ForeColor = Color.FromArgb(80, 80, 80);
                            label23.BackColor = Color.WhiteSmoke;
                            label23.Location = new Point(9, 4);
                            panel25.BackColor = Color.WhiteSmoke;
                            button29.Enabled = false;
                            button29.BackColor = Color.WhiteSmoke;
                            button22.Enabled = false;
                            button22.BackColor = Color.WhiteSmoke;
                            label35.Text = ("");
                            label35.ForeColor = Color.FromArgb(80, 80, 80);
                            label35.BackColor = Color.WhiteSmoke;
                            label35.Location = new Point(9, 4);
                            panel32.BackColor = Color.WhiteSmoke;
                            button31.Enabled = false;
                            button31.BackColor = Color.WhiteSmoke;
                            Form2.SetMonitorValues("SilverSpades", "Silver Spades:");
                            label4.Text = ("");
                            label4.ForeColor = Color.FromArgb(80, 80, 80);
                            label4.BackColor = Color.WhiteSmoke;
                            label4.Location = new Point(9, 4);
                            panel5.BackColor = Color.WhiteSmoke;
                            button2.Enabled = false;
                            button2.BackColor = Color.WhiteSmoke;
                            button3.Enabled = false;
                            button3.BackColor = Color.WhiteSmoke;
                            checkBox1.Enabled = false;
                            checkBox1.Checked = false;
                            checkBox2.Enabled = false;
                            checkBox2.Checked = false;
                            checkBox3.Enabled = false;
                            checkBox3.Checked = false;
                        });
                    }
                }
            }
        }
    }
}
