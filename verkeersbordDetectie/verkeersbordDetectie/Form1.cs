using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
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
            Mat matInputImage = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\verkeersborden.jpg", LoadImageType.AnyColor);
            imageBox1.Image = matInputImage;

            Mat matImage = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\Stop.png", LoadImageType.AnyColor);

            long _matchTime;/*
            VectorOfKeyPoint _modelkeyPoints;
            VectorOfKeyPoint _observedKeyPoints;
            VectorOfVectorOfDMatch _matches;
            Mat _mask;
            Mat _homography;*/

            //TraficSignDetector.FindMatch(matImage, matInputImage, out _matchTime, out _modelkeyPoints, out _observedKeyPoints, _matches, out _mask, out _homography);
            Mat outputImage = TraficSignDetector.Draw(matImage, matInputImage, out _matchTime);

            imageBox1.Image = outputImage;

        }
    }
}
