using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

public class ProxyRealVideoSubject : ProxyVideoInterface
{
    public ProxyRealVideoSubject(string albumid)
	{
        loadImageFromDisk(albumid);
	}

    public void loadImageFromDisk(string albumid)
    {
        List<Media> videoload = MediaDAL.getMediaByAlbum(albumid);
    }

    public List<Media> getVideo(string albumid)
    {
        return MediaDAL.getMediaByAlbum(albumid);
    }
}
