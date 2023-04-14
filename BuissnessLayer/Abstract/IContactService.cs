using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void AddContact(Contact contact);

        Contact GetByIdContact(int id);

        void ContactDelete(Contact contact);

        void ContactUpdate(Contact contact);
    }
}
