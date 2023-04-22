
using XUnit.Service.Models;

namespace XUnit.Service.Service
{
    public interface IRoleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<RoleModel>> GetList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RoleModel> GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        Task<RoleModel> Add(RoleModel roleModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        Task<RoleModel> Update(RoleModel roleModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);


    }
}
