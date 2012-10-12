using System;
using System.Collections;
using System.Linq;
using System.Text;
using ObjectLayer;

namespace BuinessLayer
{
    interface subscriber
    {
        void update(string publisherId, string subscriberId, WallBO obj, string tagstatus, string twid);
    }
}
