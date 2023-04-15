using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInBox();
        List<Message> GetListSendBox();
        void AddMessage(Message message);

        Message GetByIdMessage(int id);

        void MessageDelete(Message message);

        void MessageUpdate(Message message);
    }
}
