using Forum.Core.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories.Repositories.Messages
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository, IElementOwnerRepository
    {
        #region Security

        public bool UserOwnElement(int elementID, int userID)
        {
            var element = this.FindBy(x => x.ID == elementID && x.CreationUserID == userID).FirstOrDefault();
            bool isOwnElement = element != null;
            return isOwnElement;
        }

        #endregion
    }
}
