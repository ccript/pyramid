using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Diagnostics;


public class Video
{
	public Video()
	{
        		
	}

    public static string buildName(FileUpload FileUpload1)
    {
        return FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("\\") + 1, FileUpload1.PostedFile.FileName.Length - FileUpload1.PostedFile.FileName.LastIndexOf(".")) + "." + FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1);
    }

    public static string getFullPath(FileUpload FileUpload1)
    {
        return Path.Combine(HttpContext.Current.Server.MapPath(Global.PATH_COMPRESSED_USER_VIDEO), buildName(FileUpload1));
    }

    public static string getFileNameWithoutExtension(FileUpload FileUpload1)
    {
        return Path.GetFileNameWithoutExtension(getFullPath(FileUpload1));
    }

    public static string inputFilePath(FileUpload FileUpload1)
    {
        return HttpContext.Current.Server.MapPath(Global.PATH_COMPRESSED_USER_VIDEO) + buildName(FileUpload1);
    }

    public static string getOutPutFileName(FileUpload FileUpload1)
    {
        return HttpContext.Current.Server.MapPath(Global.PATH_COMPRESSED_USER_VIDEO) + "SWF\\" + getFileNameWithoutExtension(FileUpload1) + ".swf";
    }

    public static void Upload(FileUpload FileUpload1)
    {

        //Save The file
        FileUpload1.PostedFile.SaveAs(getFullPath(FileUpload1));
    
        string uploadedvideoname = getFileNameWithoutExtension(FileUpload1) + ".swf";
            
        Process proc;
        proc = new Process();
        proc.StartInfo.FileName = HttpContext.Current.Server.MapPath(Global.PATH_COMPRESSED_USER_VIDEO) + "\\ffmpeg\\ffmpeg.exe";        
        proc.StartInfo.Arguments = "-i \"" + inputFilePath(FileUpload1) + "\" -deinterlace -ab 32 -r 15 -ar 22050 -ac 1 \"" + getOutPutFileName(FileUpload1) + "\"";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.CreateNoWindow = false;
        proc.StartInfo.RedirectStandardOutput = false;
        bool started = false;
        try
        {            
            started = proc.Start();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
        }

        proc.WaitForExit();
        proc.Close();
    }

    public static string uploadedVideoLiteral(FileUpload FileUpload1)
    {
        string uploadedvideoliteral = "";

        uploadedvideoliteral += "<br/><br/><img name='image' id='image' src='" + Global.PATH_COMPRESSED_USER_VIDEO + "Thumb/" + Video.getFileNameWithoutExtension(FileUpload1) + ".jpg" + "'/>";
        uploadedvideoliteral += "<embed src='" + Global.PATH_COMPRESSED_USER_VIDEO + "Players/flvplayer.swf' width='320' height='215' bgcolor='#FFFFFF' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' flashvars='file=" + Global.PATH_COMPRESSED_USER_VIDEO + "SWF/" + Video.getFileNameWithoutExtension(FileUpload1) + "&autostart=false&frontcolor=0xCCCCCC&backcolor=0x000000&lightcolor=0x996600&showdownload=false&showeq=false&repeat=false&volume=100&useaudio=false&usecaptions=false&usefullscreen=true&usekeys=true'></embed>";

        return uploadedvideoliteral;
    }

    public static string getUploadedVideoEmbedLiteral(string wallpost, string uploadedvideoname)
    {
        return wallpost + "<br/><br/><embed src='" + Global.PATH_COMPRESSED_USER_VIDEO + "Players/flvplayer.swf' width='320' height='215' bgcolor='#FFFFFF' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' flashvars='file=" + Global.PATH_COMPRESSED_USER_VIDEO + "SWF/" + uploadedvideoname + "&autostart=true&frontcolor=0xCCCCCC&backcolor=0x000000&lightcolor=0x996600&showdownload=false&showeq=false&repeat=false&volume=100&useaudio=false&usecaptions=false&usefullscreen=true&usekeys=true'></embed>";
    }
}