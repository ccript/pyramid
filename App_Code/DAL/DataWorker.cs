using System;
namespace Pramyid
{
    public class DataWorker
    {
        private static DAC _database = null;

        static DataWorker()
        {
            try
            {
                _database = DatabaseFactory.CreateDatabase();
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }

        public static DAC database
        {
            get { return _database; }
        }
    }
}