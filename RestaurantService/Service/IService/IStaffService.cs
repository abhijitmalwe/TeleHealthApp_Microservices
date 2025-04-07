
using StaffService.Entities;

namespace StaffService.Service.IService
{
    public interface IStaffService
    {
        Task<string> RegisterStaffAsync(Staff staff);
    }
}
