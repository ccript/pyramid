﻿using System;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class popup_calendar : System.Web.UI.Page
{

    private static object _lock = new object();
    protected void Page_Load(object sender, EventArgs e)
    {
        originalImage.ImageUrl = Global.PROFILE_PICTURE + Session["SignUpUserId"].ToString() + ".jpg";
        originalImage1.ImageUrl = Global.PROFILE_PICTURE + Session["SignUpUserId"].ToString() + ".jpg";
    }

    protected void btnCrop_Click(object sender, EventArgs e)
    {
        int X1 = Convert.ToInt32(Request.Form["x1"]);
        int Y1 = Convert.ToInt32(Request["y1"]);
        int X2 = Convert.ToInt32(Request.Form["x2"]);
        int Y2 = Convert.ToInt32(Request.Form["y2"]);
        int X = System.Math.Min(X1, X2);
        int Y = System.Math.Min(Y1, Y2);
        int w = Convert.ToInt32(Request.Form["w"]);
        int h = Convert.ToInt32(Request.Form["h"]);

        // That can be any image type (jpg,jpeg,png,gif) from any where in the local server
        string originalFile = Server.MapPath(Global.PROFILE_PICTURE + Session["SignUpUserId"].ToString() + ".jpg");
        string newFullPathName = null;

        using (Image img = Image.FromFile(originalFile))
        {
            using (System.Drawing.Bitmap _bitmap = new System.Drawing.Bitmap(w, h))
            {
                _bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                using (Graphics _graphic = Graphics.FromImage(_bitmap))
                {
                    _graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    _graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    _graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    _graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    _graphic.DrawImage(img, 0, 0, w, h);
                    _graphic.DrawImage(img, new Rectangle(0, 0, w, h), X, Y, w, h, GraphicsUnit.Pixel);

                    string extension = Path.GetExtension(originalFile);
                    //string croppedFileName = Guid.NewGuid().ToString();
                    string croppedFileName = Session["SignUpUserId"].ToString();
                    string path = Server.MapPath("cropped/");
                    
                    // If the image is a gif file, change it into png
                    if (extension.EndsWith("gif", StringComparison.OrdinalIgnoreCase))
                    {
                        extension = ".jpg";
                    }

                    newFullPathName = string.Concat(path, croppedFileName, extension);

                   /* if (File.Exists(originalFile))
                    {
                        File.Delete(originalFile);
                    }
                    
                    File.Create(newFullPathName);
                    */
                    
                    //string oldfile = newFullPathName;
                    //string newfile = Server.MapPath(Global.PROFILE_PICTURE) + Session["UserId"] + ".jpg";
                    //string backup = Server.MapPath(Global.PROFILE_PICTURE) +"backup.jpg";
                    
                  
                    //    if (System.IO.File.Exists(newfile))
                    //{
                       
                    //        //System.IO.File.Delete(newfile);
 
                        
                    //}
                    using (EncoderParameters encoderParameters = new EncoderParameters(1))
                    {
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                        _bitmap.Save(newFullPathName, GetImageCodec(extension), encoderParameters);
                    }
                                       // lblCroppedImage.Text = string.Format("<img src='profileimages/{0}' alt='Cropped image'>", croppedFileName + extension);
                }
            }
        }
        
        if (File.Exists(originalFile))
        {
            File.Delete(originalFile);
        }

        if (File.Exists(newFullPathName))
        {
            File.Move(newFullPathName, originalFile);

           
        }
    }


    /// <summary>
    /// Find the right codec
    /// </summary>
    /// <param name="extension"></param>
    /// <returns></returns>
    public static ImageCodecInfo GetImageCodec(string extension)
    {
        extension = extension.ToUpperInvariant();
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FilenameExtension.Contains(extension))
            {
                return codec;
            }
        }
        return codecs[1];
    }

    //public static void replaceOrifinalFile()
    //{
    //    string oldfile = Server.MapPath("../Resources/images/Male.png");
    //    string newfile = Server.MapPath(Global.PROFILE_PICTURE) + userid + ".jpg";
    //    string backup = Server.MapPath(Global.PROFILE_PICTURE) + "backup.jpg";
    //    if (System.IO.File.Exists(newfile))
    //    {
    //        System.IO.File.Delete(newfile);

    //        System.IO.File.Copy(oldfile, newfile);
    //    }

    //    imgProfile.ImageUrl = Global.PROFILE_PICTURE + userid + ".jpg";
    //}
}