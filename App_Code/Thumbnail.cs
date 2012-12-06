using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;

/// <summary>
/// Summary description for Thumbnail
/// </summary>
public class Thumbnail
{
	public Thumbnail()
	{
	}

    public static string thumbnailName(FileUpload FileUpload1)
    {
        return HttpContext.Current.Server.MapPath(Global.PATH_COMPRESSED_USER_VIDEO) + "Thumb\\" + Video.getFileNameWithoutExtension(FileUpload1) + ".jpg";
    }

    public static void Build(FileUpload FileUpload1)
    {        
        Process thumbproc = new Process();
        thumbproc = new Process();

        thumbproc.StartInfo.FileName = HttpContext.Current.Server.MapPath(Global.PATH_COMPRESSED_USER_VIDEO) + "\\ffmpeg\\ffmpeg.exe";
 
        thumbproc.StartInfo.Arguments = "-i \"" + Video.inputFilePath(FileUpload1) + "\" -f image2 -vframes 1 -ss 3 -s 150x130 \"" + thumbnailName(FileUpload1) + "\"";
        thumbproc.StartInfo.UseShellExecute = false;
        thumbproc.StartInfo.CreateNoWindow = false;
        thumbproc.StartInfo.RedirectStandardOutput = false;
        try
        {
            thumbproc.Start();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
        }
        thumbproc.WaitForExit();
        thumbproc.Close();

        File.Delete(Video.inputFilePath(FileUpload1));
    }
}