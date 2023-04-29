using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
<Lu Yingjie>, <AF35AN>
This solution was prepared and submitted by the student stated above for the 
assignment of the Programming course. I declare that this solution is my own 
work. I have not copied or used third party solutions. I have not passed my 
solution to my classmates, neither made it public.
Students’ regulation of Eötvös Loránd University (ELTE Regulations Vol. II. 
74/C.§) states that as long as a student presents another student’s work -
or at least the significant part of it - as his/her own performance, it will 
count as a disciplinary fault. The most serious consequence of a disciplinary 
fault can be dismissal of the student from the University.
*/
namespace Snowball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Input.Text))
                return;
            string[] inputArray = Input.Text.Split('\n');
            StringBuilder stringBuilder = new StringBuilder("");
            stringBuilder.Append(OneLine(inputArray,"40")+"\n");
            stringBuilder.Append(TwoLine(inputArray) + "\n");
            stringBuilder.Append(ThreeLine(inputArray,50) + "\n");
            stringBuilder.Append(FourLine(inputArray) + "\n");
            Output.Text = stringBuilder.ToString();
        }
        private int OneLine(string[] inputArray,string a)
        {
            int res = 0;
            int huihe = 0;
            huihe = inputArray[1].Split(' ').Length-1;
                for (int i=1; i< huihe; i++)
                {
                for (int j = 1; j < inputArray.Length; j++)
                {
                    string[] index = inputArray[j].Split(' ');
                    if (index[i].Equals(a))
                    {
                        res++;
                        break;
                    }
                }
               }
            
            return res;
        }
        private int TwoLine(string[] inputArray)
        {
            int res = 1;
            int sum = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                string[] index = inputArray[i].Split(' ');
                int tempsum = 0;
                for (int j = 1; j < index.Length; j++)
                {
                    tempsum +=int.Parse(index[j]);
                }
                if (sum < tempsum)
                {
                    res = i;
                    sum = tempsum;
                }
            }
            return res;
        }
        private string ThreeLine(string[] inputArray,int M)
        {
            string res = "";
            int sum = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                string[] index = inputArray[i].Split(' ');
                int tempsum = 0;
                for (int j = 1; j < index.Length; j++)
                {
                    tempsum += int.Parse(index[j]);
                }
                if (M < tempsum)
                {
                    res += " "+i;
                    sum++; 
                }
            }
            return sum.ToString()+res;
        }
        private string FourLine(string[] inputArray)
        {
            int SumMin = 0;
            int SiglnMax = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                string[] index = inputArray[i].Split(' ');
                int tempsum = 0;
                for (int j = 1; j < index.Length; j++)
                {
                    tempsum += int.Parse(index[j]);
                }
                if (SumMin == 0 || SumMin > tempsum)
                    SumMin = tempsum;
            }
            for (int i = 1; i < inputArray.Length; i++)
            {
                string[] index = inputArray[i].Split(' ');
                int temp = int.Parse(index[1]);
                for (int j = 2; j < index.Length; j++)
                {
                    temp = temp < int.Parse(index[j]) ? temp : int.Parse(index[j]);
                }
                SiglnMax = SiglnMax > temp ? SiglnMax : temp;
            }
            return SumMin< SiglnMax?"YES":"NO";
        }
    }
}
