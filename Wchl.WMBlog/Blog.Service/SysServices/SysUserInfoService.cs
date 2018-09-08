using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common.Cache;
using Blog.Domain.Models;
using Blog.IRepository;
using Blog.IRepository.ISysRepository;
using Blog.IService.ISysServices;

namespace Blog.Service.SysServices
{
    public class SysUserInfoService:BaseServices<SysUserInfo>,ISysUserInfoService
    {
        #region 注入
        private const string _cacheKey = nameof(SysUserInfoService) + nameof(SysUserInfo);//缓存的键值

        private new readonly ISysUserInfoRepository _baseDal;
        private new ICacheManager _cache;
        public SysUserInfoService(ISysUserInfoRepository baseDal, ICacheManager cache)
        {
            this._baseDal = baseDal;
            base._baseDal = baseDal;
            base._cache = cache;
            base.cacheKey = _cacheKey;
        }
        #endregion



    }
}
