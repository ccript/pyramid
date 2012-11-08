using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuinessLayer;
using DataLayer;
using ObjectLayer;
using System.Data;
using System.Security.Authentication;

public class ProxyVirtualSubject : ProxyImagerInterface
{
    private ProxyRealSubject image = null;

	public ProxyVirtualSubject()
	{
	}

    public List<Media> getImage(string albumid)
    {
        image = new ProxyRealSubject(albumid);

        return image.getImage(albumid);
    }
}