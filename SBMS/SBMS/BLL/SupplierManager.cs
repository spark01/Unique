using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMS.Model;
using SBMS.Repository;

namespace SBMS.BLL
{
    class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public List<Supplier> Dispaly()
        {
            return _supplierRepository.Dispaly();
        }
        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }

        public List<Supplier> Search(Supplier supplier)
        {
            return _supplierRepository.Search(supplier);
        }
    }
}
