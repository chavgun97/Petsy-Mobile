using Petsy.Services.FireBaseRealTimeDataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Petsy.Services.Interfaces
{
    /**
     OnChangeOrAddMsgHandlerNotify - Subscrible receive message event
     SendMsg - sending message
     GetAllMsg - getting all message
     */
    interface IChatApi
    {
        delegate void OnChangeOrAddMsgHandler(Message msg);

        
        event OnChangeOrAddMsgHandler OnChangeOrAddMsgHandlerNotify;

        Task SendMsg(string text);

        Task<List<Message>> GetAllMsg();
        void SubscribeToMsgChanges();
    }
}
