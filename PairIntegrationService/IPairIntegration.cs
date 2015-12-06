using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PairIntegrationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPairIntegration
    {

        [OperationContract]
        Pair Add(Pair p1,Pair p2);


        [OperationContract]
        Pair Substract(Pair p1, Pair p2);

        //   CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Pair
    {
        private int m_first;
        private int m_second;

        public Pair()
        {
            m_first = 0;
            m_second = 0;
        }

        public Pair(int first,int second)
        {
            m_first = first;
            m_second = second;
        }



        [DataMember]
        public int First
        {
            get { return m_first; }
            set { m_first = value; }
        }

        [DataMember]
        public int Second
        {
            get { return m_second; }
            set { m_second = value; }
        }
    }
}
