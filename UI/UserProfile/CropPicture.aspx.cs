using System;
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
        originalImage.ImageUrl = Global.PROFILE_PICTURE + SessionClass.getUserId() + Global.PICTURE_EXTENSION_JPG;
    }

    protected void btnCrop_Click(object sender, EventArgs e)
    {                                        
        using (Image img = Image.FromFile(Server.MapPath(Global.PROFILE_PICTURE + SessionClass.getUserId() + Global.PICTURE_EXTENSION_JPG)))
        {
            using (System.Drawing.Bitmap _bitmap = new System.Drawing.Bitmap(Convert.ToInt32(Request.Form["w"]), Convert.ToInt32(Request.Form["h"])))
            {
                _bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                using (Graphics _graphic = Graphics.FromImage(_bitmap))
                {
                    _graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    _graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    _graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    _graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    _graphic.DrawImage(img, 0, 0, Convert.ToInt32(Request.Form["w"]), Convert.ToInt32(Request.Form["h"]));
                    _graphic.DrawImage(img, new Rectangle(0, 0, Convert.ToInt32(Request.Form["w"]), Convert.ToInt32(Request.Form["h"])), System.Math.Min(Convert.ToInt32(Request.Form["x1"]), Convert.ToInt32(Request.Form["x2"])), System.Math.Min(Convert.ToInt32(Request["y1"]), Convert.ToInt32(Request.Form["y2"])), Convert.ToInt32(Request.Form["w"]), Convert.ToInt32(Request.Form["h"]), GraphicsUnit.Pixel);

                    using (EncoderParameters encoderParameters = new EncoderParameters(1))
                    {
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                        _bitmap.Save(string.Concat(Server.MapPath("cropped/"), SessionClass.getUserId(), Global.PICTURE_EXTENSION_JPG), GetImageCodec(Global.PICTURE_EXTENSION_JPG), encoderParameters);
                    }                    
                }
            }
        }

        if (File.Exists(Server.MapPath(Global.PROFILE_PICTURE + SessionClass.getUserId() + Global.PICTURE_EXTENSION_JPG)))
        {
            File.Delete(Server.MapPath(Global.PROFILE_PICTURE + SessionClass.getUserId() + Global.PICTURE_EXTENSION_JPG));
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

}