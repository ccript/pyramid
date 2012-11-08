using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

public class ProxyRealSubject : ProxyImagerInterface
{
	public ProxyRealSubject(string albumid)
	{
        loadImageFromDisk(albumid);
	}

    public void loadImageFromDisk(string albumid)
    {
        List<Media> imageload = MediaDAL.getMediaByAlbum(albumid);
    }

    public List<Media> getImage(string albumid)
    {
        return MediaDAL.getMediaByAlbum(albumid);
    }
}

