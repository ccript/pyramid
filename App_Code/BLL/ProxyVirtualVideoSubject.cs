using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

public class ProxyVirtualVideoSubject : ProxyVideoInterface
{
    private ProxyRealVideoSubject video = null;

	public ProxyVirtualVideoSubject()
	{	}

    public List<Media> getVideo(string albumid)
    {
        video = new ProxyRealVideoSubject(albumid);
        return video.getVideo(albumid);
    }

}