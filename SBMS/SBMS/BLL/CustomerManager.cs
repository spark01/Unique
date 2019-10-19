using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SBMS.Model;
using SBMS.Repository;

namespace SBMS.BLL
{
    class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public List<Customer> Dispaly()
        {
            return _customerRepository.Dispaly();
        }

        public List<Customer> Search(Customer customer)
        {
            return _customerRepository.Search(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}
