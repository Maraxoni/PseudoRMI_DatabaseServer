using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreWCF;

namespace PseudoRMI_DatabaseServer
{
    [ServiceContract]
    public interface IDatabaseService
    {
        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        Product GetProductByName(string name);
    }
}
