using awsmSeeSharpGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    class Queries
    {

        static public awsm_Users GetUserByUserName(string userName)
        {
            using (var context = new Context())
            {
                var user = context.Users
                            .Where(users => users.UserName == userName)
                            .FirstOrDefault();
                return user;

            }
        }
    }
}
