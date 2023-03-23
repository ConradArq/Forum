using Forum.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories.Managers
{
    public class ElementOwnerManager
    {

        public static IElementOwnerRepository CreateElementOwnerRepository(Type entityType)
        {
            return (IElementOwnerRepository)Activator.CreateInstance(entityType);
        }

        public static bool UserOwnElement(Type entityType, int elementID, int userID)
        {
            IElementOwnerRepository elementOwnerRepository = CreateElementOwnerRepository(entityType);
            return elementOwnerRepository.UserOwnElement(elementID, userID);
        }
    }
}
