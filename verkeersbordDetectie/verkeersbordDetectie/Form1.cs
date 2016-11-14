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
using System.IO;
using System.Linq;
using System.Net;
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
            //Mat verkeersbord_Stop = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\Stop.png", LoadImageType.AnyColor);
            //Mat verkeersbord_Stop;

            long _matchTime;

            //TraficSignDetector.FindMatch(matImage, matInputImage, out _matchTime, out _modelkeyPoints, out _observedKeyPoints, _matches, out _mask, out _homography);
            //Mat outputImage = TraficSignDetector.Draw(verkeersbord_Stop, matInputImage, out _matchTime);

            //imageBox1.Image = outputImage;
            Verkeersborden();
        }

        private void Verkeersborden()
        {
            List<string> imageUrls = TraficSignboards.getImageUrls();
            List<string> filenames = TraficSignboards.getFilenames();
            int l = imageUrls.Count;
            for (int i = 0; i < l; i++)
            {
                getVerkeersborden(imageUrls[i], filenames[i]);
            }
            //Mat verkeersbord_Stop = await getMatObjFromUrl();
            //imageBox1.Image = verkeersbord_Stop;
        }

        private void getVerkeersborden(string imageUrl, string filename)
        {
            string saveLocation = @"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\Verkeersborden\"+filename;

            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            WebResponse imageResponse = imageRequest.GetResponse();

            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            FileStream fs = new FileStream(saveLocation, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }
    }
}
