using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleHealthService.Model;

namespace TeleHealthService.Data
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);
        Task<Appointment> GetByIdAsync(Guid id);
    }
}
