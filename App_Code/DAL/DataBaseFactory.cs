using System.Reflection;
using System.Configuration;
using System;

namespace Pramyid
{
    public sealed class DatabaseFactory
    {        
        private DatabaseFactory() { }

        public static DAC CreateDatabase()
        {            
            try
            {
                //DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");
                Type database = Type.GetType("_MongoDatabase");
                
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                DAC createdObject = (DAC)constructor.Invoke(null);
                createdObject.connectionString = "mongodb://localhost:27017/SocialDB";//sectionHandler.ConnectionString

                return createdObject;
            }
            catch (Exception excep)
            {
                throw new Exception(excep.Message);
            }
        }
    }
}