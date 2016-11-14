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
        private List<string> imageUrls = new List<string>();
        private List<string> filenames = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Mat matInputImage = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\verkeersborden1.jpg", LoadImageType.AnyColor);
            Mat matInputGrayImage = new Mat();
            CvInvoke.CvtColor(matInputImage, matInputGrayImage, ColorConversion.Bgr2Gray);
            Verkeersborden();
            ZoekVerkeersbordenOpImg(matInputGrayImage);
        }
        private void ZoekVerkeersbordenOpImg(Mat matInputImage)
        {
            long _matchTime;
            Mat verkeersbord = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\Verkeersborden\D1aro.png", LoadImageType.AnyColor);
            Mat verkeersbordGray = new Mat();
            CvInvoke.CvtColor(verkeersbord, verkeersbordGray, ColorConversion.Bgr2Gray);
            Mat outputImage = TraficSignDetector.Draw(verkeersbordGray, matInputImage, out _matchTime);
            imageBox1.Image = outputImage;

            /*Mat verkeersbord = new Mat();
            Mat outputImage = new Mat();
            List<string> gevondenVerkeersborden = new List<string>();

            for (int i = 0; i < 149; i++)
            {
                try
                {
                    long _matchTime;
                    verkeersbord = CvInvoke.Imread(@"C:\Users\Anthony\Desktop\NMCT\3NMCT\Audio & Visual Productions\Project\verkeersbordDetectie\Images\Verkeersborden\" + filenames[i], LoadImageType.AnyColor);
                    outputImage = TraficSignDetector.Draw(verkeersbord, matInputImage, out _matchTime);

                    if (outputImage != null)
                    {
                        gevondenVerkeersborden.Add(filenames[i]);
                    }
                }
                catch (Exception)
                {

                }
            }
            imageBox1.Image = outputImage;*/
        }
        private void Verkeersborden()
        {
            imageUrls = TraficSignboards.getImageUrls();
            filenames = TraficSignboards.getFilenames();
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
