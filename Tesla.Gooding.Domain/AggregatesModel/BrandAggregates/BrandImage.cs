using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Tesla.Framework.Domain.Abstractions;

namespace Tesla.Gooding.Domain.AggregatesModel.BrandAggregates
{
    /// <summary>
    /// 品牌图像
    /// </summary>
    public class BrandImage : Entity<Guid>, ITenantIdentity, IDeleteEntity, IOperateRecord, IAggregateRoot
    {
        #region Field

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public BrandImageType Type { get; private set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string Url { get; private set; } 

        #endregion

        #region Common

        /// <summary>
        /// 租户ID
        /// </summary>
        public long TenantId { get; private set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateOn { get; private set; }

        /// <summary>
        /// 创建Id
        /// </summary>
        public string CreateBy { get; private set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateOn { get; private set; }

        /// <summary>
        /// 更新Id
        /// </summary>
        public string UpdateBy { get; private set; }

        #endregion

        #region Action

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        public void Create(long tenantId, string userId)
        {
            this.TenantId = tenantId;
            this.CreateBy = userId;
            this.CreateOn = DateTime.Now;
            this.UpdateBy = userId;
            this.UpdateOn = DateTime.Now;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(long tenantId, string userId)
        {
            this.IsDeleted = true;

            this.UpdateBy = userId;
            this.UpdateOn = DateTime.Now;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="url"></param>
        public void Modify(long tenantId, string userId, string code, BrandImageType type, string url)
        {
            this.Code = code;
            this.Type = type;
            this.Url = url;

            this.UpdateBy = userId;
            this.UpdateOn = DateTime.Now;
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        public void Recovery(long tenantId, string userId)
        {
            this.IsDeleted = false;

            this.UpdateBy = userId;
            this.UpdateOn = DateTime.Now;
        }

        #endregion
    }
}
