using ServiceCenter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.Domain.Entities
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DeviceType { get; set; } = null!;
        public string ProblemDescription { get; set; } = null!;
        public ServiceRequestStatus Status { get; set; } = ServiceRequestStatus.New;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
