using System;
using System.Collections;
using System.Linq;
using System.Text;
using ObjectLayer;

namespace BuinessLayer
{
    interface notifier
    {
        void registerSubscriber(string publisherId, string subscriberId);
        void removeSubscriber(string publisherId, string subscriberId);
        void notify_subscribers(string publisherId, WallBO obj, string tagstatus, string twid);
    }
}
