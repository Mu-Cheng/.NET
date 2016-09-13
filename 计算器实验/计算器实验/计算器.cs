using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计算器实验
{
    public partial class 计算器 : Form
    {
        public 计算器()
        {
            InitializeComponent();
        }

        private void 计算器_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void EqurBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OutputTextBox.Text = calculation(InputTextBox.Text);
        }

        private string calculation(string text)
        {
            //throw new NotImplementedException();
            Stack st = new Stack();
            Queue ans = new Queue();

            while (text != "")
            {
                int len = getNumOfLen(text);
                string s1 = text.Substring(0,len);
                
                switch (s1)
                {
                    case "+":
                        if (st.Count == 0)
                        {
                            st.Push("+");
                        }else
                        {
                            while (st.Count != 0)
                            {
                                string op = (string)st.Peek();
                                if (op == "(")
                                    break;
                                ans.Enqueue(op);
                                st.Pop();
                            }

                            st.Push(s1);
                        }
                       
                        break;
                    case "-":
                        if (st.Count == 0)
                        {
                            st.Push("-");
                        }
                        else
                        {
                            while (st.Count != 0)
                            {
                                string op = (string)st.Peek();
                                if (op == "(")
                                    break;
                                ans.Enqueue(op);
                                st.Pop();
                            }
                            st.Push(s1);
                        }



                        break;
                    case "*":
                        if (st.Count == 0)
                        {
                            st.Push("*");
                        }
                        else
                        {
                            while (st.Count != 0)
                            {
                                string op = (string)st.Peek();
                                if (op == "+" || op == "-")
                                    break;
                                if (op == "(")
                                    break;
                                ans.Enqueue(op);
                                st.Pop();
                            }
                            st.Push(s1);
                        }
                        break;
                    case "/":
                        if (st.Count == 0)
                        {
                            st.Push("/");
                        }
                        else
                        {
                            while (st.Count != 0)
                            {
                                string op = (string)st.Peek();
                                if (op == "+" || op == "-")
                                    break;
                                if (op == "(")
                                    break;
                                ans.Enqueue(op);
                                st.Pop();
                            }
                            st.Push(s1);
                        }
                        break;
                    case "(":
                        st.Push("(");
                        break;
                    case ")":
                        while (st.Count != 0)
                        {
                            string op = (string)st.Pop();
                            if (op == "(")
                                break;
                            ans.Enqueue(op);
                        
                        }
                        break;
                    default:
                        ans.Enqueue(s1);
                        break;
                }

                text = text.Substring(len);
            }

            while (st.Count != 0)
            {
                string op = (string)st.Pop();
                ans.Enqueue(op);
            }
            string op1, op2, result;
            double a, b, c;
            while (ans.Count != 0)
            {
                string s = (string)ans.Dequeue();

                switch (s)
                {
                    case "+":
                        op1 = (string)st.Pop();
                        op2 = (string)st.Pop();
                        a = Convert.ToDouble(op1);
                        b = Convert.ToDouble(op2);
                        c = a + b;
                        result = c.ToString();

                        st.Push(result);
                        break;
                    case "-":
                        op1 = (string)st.Pop();
                        op2 = (string)st.Pop();
                        a = Convert.ToDouble(op1);
                        b = Convert.ToDouble(op2);
                        c = b - a;
                        result = c.ToString();

                        st.Push(result);
                        break;
                    case "*":
                        op1 = (string)st.Pop();
                        op2 = (string)st.Pop();
                        a = Convert.ToDouble(op1);
                        b = Convert.ToDouble(op2);
                        c = a * b;
                        result = c.ToString();

                        st.Push(result);
                        break;
                    case "/":
                        op1 = (string)st.Pop();
                        op2 = (string)st.Pop();
                        a = Convert.ToDouble(op1);
                        b = Convert.ToDouble(op2);
                        if (Math.Abs(a)<1e-8)
                        {
                            return "除0错误";
                        }
                        c = b / a;
                        result = c.ToString();

                        st.Push(result);
                        break;
                    default:
                        st.Push(s);
                        break;
                }


            }

            return (string)st.Pop();
        }

        private int getNumOfLen(string text)
        {
            //throw new NotImplementedException();
            int i;
            int ans = 0;
            int len = text.Length;
            char[] s = text.ToCharArray();
            for(i = 0; i < len; i++)
            {
                if ('0' <= s[i] && s[i] <= '9'||s[i]=='.')
                    ans++;
                else
                {
                    if(ans == 0)
                    {
                        ans++;
    
                    }
                    break;
                }
            }
            return ans;
        }

        private void BreakBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text = "";
            OutputTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void MulBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (InputTextBox.Text == "") return;
            int len = getNumOfLen(InputTextBox.Text);
            string s = InputTextBox.Text.Substring(0, len);
            if (s == "0") return;
            InputTextBox.Text += btn.Text;
        }

        private void PointBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void DivBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void LeftBrackets_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InputTextBox.Text += btn.Text;
        }

        private void BreakOneBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(InputTextBox.Text!="")
                InputTextBox.Text = InputTextBox.Text.Substring(0, InputTextBox.Text.Length-1);
           
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
