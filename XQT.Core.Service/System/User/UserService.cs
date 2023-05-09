using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;
using Microsoft.EntityFrameworkCore;
using XQT.Core.Common.Extensions;
using System.Linq.Expressions;
using XQT.Core.Model;
using XQT.Core.EntityFramework;

namespace XQT.Core.Service
{
    public class UserService : IUserService
    {
        private readonly XQTContext _context;

        public UserService(XQTContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IResponseOutput> GetPageAsync(PageInput<UserPageDto> dto)
        {
            var users = await _context
                             .UserEntities
                             .AsNoTracking()
                             .WhereIf(dto.Filter.UserName.NotNull(), a => a.UserName.Contains(dto.Filter.UserName))
                             .WhereIf(dto.Filter.UserStatus.HasValue && dto.Filter.UserStatus != 0, a => a.UserStatus == dto.Filter.UserStatus)
                            .SortBy(a => dto.SortField, dto.SortDirection)
                            .Skip((dto.PageNumber - 1) * dto.PageSize)
                            .Take(dto.PageSize)
                            .ToListAsync();

            return ResponseOutput.Ok(users);
        }
    }
}
