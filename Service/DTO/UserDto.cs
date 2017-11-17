using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class UserDto
    {
        #region Properties

        public string Username;

        public string avatar;

        #endregion

        #region Methods

        /// <summary>
        /// Create a user DTO from user entity
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserDto Extract(User user)
        {
            var dtoUser = new UserDto()
            {
                Username = user.UserName
            };

            return dtoUser;

        }

        #endregion

    }
}
