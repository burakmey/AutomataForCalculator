using System;
using System.Drawing;
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
                                        "7", "8", "9", " / ",
                                        "4", "5", "6", " x ",
                                        "1", "2", "3", " - ",
                                        "(", "0", ")", " + ",
                                        "+/-", "", ".", "=" };
        static int buttonCount = 24;
        static string inputResult = "";
        static int spaceBetweenButtons = 5;
        Size minFormSize = new Size(361, 459);
        Size minButtonPanelSize = new Size(335, 385);
        Size minButtonSize = new Size(80, 50);
        Button[] buttons = new Button[buttonCount];
        Panel buttonsPanel;
        DFAModel dfa;
        public Calculator()
        {
            InitializeComponent();
            //Create buttons panel
            buttonsPanel = new Panel
            {
                Location = new Point(5, 90),
                Name = "buttonPanel",
                Size = minButtonPanelSize,
                TabIndex = 2,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            Controls.Add(buttonsPanel);
            //Create buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Name = buttonNames[i];
                buttons[i].Text = buttonTexts[i];
                buttons[i].Location = new Point((i % 4) * (minButtonSize.Width + spaceBetweenButtons), (i / 4) * (minButtonSize.Height + spaceBetweenButtons));
                buttons[i].Size = minButtonSize;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 1;
                buttons[i].FlatAppearance.BorderColor = SystemColors.ActiveBorder;
                buttons[i].BackColor = SystemColors.ControlLightLight;
                buttons[i].Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
                buttons[i].TabStop = false;
                buttons[i].Click += new EventHandler(ButtonClick);
                buttonsPanel.Controls.Add(buttons[i]);
            }
            //Useless buttons
            buttons[0].Enabled = false;
            buttons[1].Enabled = false;
            buttons[21].Enabled = false;
            //Create DFA
            dfa = new DFAModel();
        }
        void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            topLabel.Focus();
            if (button.Text == "C")
            {
                inputResult = "";
            }
            else if (button.Text == "<-")
            {
                if (inputResult == "")
                {
                    //Do nothing
                }
                else if (inputResult[inputResult.Length - 1] == ' ')
                {
                    inputResult = inputResult.Remove(inputResult.Length - 3, 3);
                }
                else
                {
                    inputResult = inputResult.Remove(inputResult.Length - 1);
                }
            }
            else if (button.Text == "+/-")
            {
                if (inputResult.Length - 1 >= 0 && inputResult[inputResult.Length - 1] == '-')
                {
                    inputResult = inputResult.Remove(inputResult.Length - 1);
                }
                else
                {
                    inputResult += "-";
                }
            }
            else if (button.Text == "=")
            {
                if (inputResult == "")
                {

                }
            }
            else
            {
                inputResult += button.Text;
            }
            inputTextBox.Text = inputResult;
            inputTextBox.SelectionStart = inputTextBox.Text.Length;
            string correctness;
            if (RunDFA())
            {
                correctness = "Correct";
                topLabel.ForeColor = Color.Green;
            }
            else
            {
                correctness = "Incorrect";
                topLabel.ForeColor = Color.Red;
            }
            if (inputResult.Length == 0)
            {
                topLabel.Text = "";
            }
            else
            {
                topLabel.Text = $"{correctness} syntax";
            }
        }
        bool RunDFA()
        {
            char c;
            dfa.SetStartState();
            for (int i = 0; i < inputResult.Length; i++)
            {
                c = inputResult[i];
                if (c == ' ')
                    continue;
                if (dfa.State(c) == -1)
                    return dfa.IsFinal;
            }
            return dfa.IsFinal;
        }
        void CalculatorResize(object sender, EventArgs e)
        {
            Width -= (Width - minFormSize.Width) % 4;
            Height -= (Height - minFormSize.Height) % 6;
            ButtonsPanelResize((Width - minFormSize.Width) / 4, (Height - minFormSize.Height) / 6);
        }
        //w and h represent how many pixels each button will extend.
        void ButtonsPanelResize(int w, int h)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Location = new Point((i % 4) * (minButtonSize.Width + spaceBetweenButtons + w), (i / 4) * (minButtonSize.Height + spaceBetweenButtons + h));
                buttons[i].Size = new Size(minButtonSize.Width + w, minButtonSize.Height + h);
            }
        }
    }
}
