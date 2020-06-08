using BlogApp.Core.Data;
using BlogApp.Core.Users;
using BlogApp.Core.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DomainServices.Users
{
    public class UserContext : IUserContext
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IDictionary<Guid, IUserInfo> _userMap;
        private readonly IUserInfo _user;

        public UserContext(IUserAccessor userAccessor, IUserRepository userRepository)
        {
            _userAccessor = userAccessor;
            _userRepository = userRepository;
            _userMap = new Dictionary<Guid, IUserInfo>();
            _user = GetUser();
        }

        public Guid UserId => _user.Id;

        public bool IsAuthenticated => _user.Id != Guid.Empty;

        public string Email => _user.Email;

        public string DisplayName => throw new NotImplementedException();

        private IUserInfo GetUser()
        {
            var userId = _userAccessor.GetCurrentUserId();

            if (userId == Guid.Empty)
            {
                return new User
                {
                    Id = userId,
                    Email = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty
                };
            }

            if (_userMap.ContainsKey(userId))
            {
                return _userMap[userId];
            }

            var userEntity = _userRepository.Get(userId);
            IUserInfo user = new User(userEntity);

            return _userMap[userId] = user;

        }
    }
}
