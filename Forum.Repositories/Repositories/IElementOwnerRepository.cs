using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories.Repositories
{
    public interface IElementOwnerRepository
    {
        bool UserOwnElement(int elementID, int userID);
    }
}
