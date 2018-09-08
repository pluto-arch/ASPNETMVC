using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Models;
using Blog.IRepository.ISysRepository;

namespace Blog.Repository.SysRepository
{
    /// <summary>
    /// 用户信息的仓储接口实现
    /// </summary>
    public class SysUserInfoRepository : BaseRepository<SysUserInfo>, ISysUserInfoRepository
    {
        #region 注入
        private new readonly IDbContext _db;
        public SysUserInfoRepository(IDbContext db)
        {
            this._db = db;
            base._db = db;
        }
        #endregion


    }
}
