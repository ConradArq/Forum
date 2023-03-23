using Forum.Core.Enums.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public interface IMaintainableEntity
    {
        void SetStatus(States status);

        void SetCreationData(DateTime date, int userID);

        void SetModifiedData(DateTime date, int userID);

        void SetDeletedData(DateTime date, int userID);
    }
}
