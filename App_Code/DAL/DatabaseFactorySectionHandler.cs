﻿using System.Configuration;
using System;

public sealed class DatabaseFactorySectionHandler : ConfigurationSection
{
    [ConfigurationProperty("Name")]
    public string Name
    {
        get { return (string)base["Name"]; }
    }

    [ConfigurationProperty("ConnectionStringName")]
    public string ConnectionStringName
    {
        get { return (string)base["ConnectionStringName"]; }
    }

    public string ConnectionString
    {
        get
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
            catch (Exception excep)
            {
                throw new Exception("Connection string " + ConnectionStringName + " was not found in web.config. " + excep.Message);
            }
        }
    }
}