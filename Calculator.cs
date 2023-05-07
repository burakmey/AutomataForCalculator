using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomataForCalculator
{
    public partial class Calculator : Form
    {
        static readonly string[] buttonNames = { "buttonx", "buttony", "buttonClear", "buttonRemove",
                                        "button7", "button8", "button9", "buttonDivision",
                                        "button4", "button5", "button6", "buttonMultiplication",
                                        "button1", "button2", "button3", "buttonSubtraction",
                                        "buttonParenthesesL", "button0", "buttonParenthesesR", "buttonAddition",
                                        "buttonSign", "buttonz", "buttonPoint", "buttonEqual" };
        static readonly string[] buttonTexts = { "", "", "C", "<-",
                                        "7", "8", "9", "/",
                                        "4", "5", "6", "x",
                                        "1", "2", "3", "-",
                                        "(", "0", ")", "+",
                                        "+/-", "", ".", "=" };
        static int buttonCount = 24;
        Point startingLocation = new Point(5, 110);
        Size buttonSize = new Size(80, 50);
        Button[] buttons = new Button[buttonCount];
        public Calculator()
        {
            InitializeComponent();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = buttonNames[i];
                buttons[i].Text = buttonTexts[i];
                buttons[i].Location = new Point(startingLocation.X + (i % 4) * (buttonSize.Width + startingLocation.X),
                    startingLocation.Y + (i / 4) * (buttonSize.Height + startingLocation.X));
                buttons[i].Size = buttonSize;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 1;
                buttons[i].FlatAppearance.BorderColor = SystemColors.ActiveBorder;
                buttons[i].BackColor = SystemColors.ControlLightLight;
                buttons[i].TabStop = false;
                buttons[i].Click += new EventHandler(ButtonClick);
                Controls.Add(buttons[i]);
            }
        }
        void ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
