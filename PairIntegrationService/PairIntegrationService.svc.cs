using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PairIntegrationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PairIntegrationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PairIntegrationService.svc or PairIntegrationService.svc.cs at the Solution Explorer and start debugging.
    public class PairIntegrationService : IPairIntegration
    {

        public Pair Add(Pair p1, Pair p2)
        {
           Pair result =new Pair();
           result.First = p1.First + p2.First;
           result.Second = p1.Second + p2.Second;

            return result;
        }

        public Pair Substract(Pair p1, Pair p2)
        {
           Pair result=new Pair();

            result.First = p1.First - p2.First;
            result.Second = p1.Second - p2.Second;

            return result;
        }
    }
}
