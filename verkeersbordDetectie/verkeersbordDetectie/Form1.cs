using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace verkeersbordDetectie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Mat matInputImage = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\Stop.png", LoadImageType.AnyColor);
            imageBox1.Image = matInputImage;
        }
    }
}
