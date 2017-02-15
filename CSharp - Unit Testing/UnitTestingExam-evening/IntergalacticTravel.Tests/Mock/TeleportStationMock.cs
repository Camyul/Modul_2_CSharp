using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using IntergalacticTravel;

namespace IntergalacticTravel.Tests.Mock
{
    public class TeleportStationMock : TeleportStation
    {
        public TeleportStationMock(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return this.owner;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return this.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.location;
            }
        }
    }
}
