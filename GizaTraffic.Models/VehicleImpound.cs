using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Utilities;

namespace GizaTraffic.Models
{
    public class VehicleImpound : BaseModel
    {
        [Key]
        public int VehicleImpoundId { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleType { get; set; }
        public string? VehicleChassisNumber { get; set; }
        public string? VehicleEngineNumber { get; set; }
        public string CaseReportNumber { get; set; } = string.Empty;
        public string? CaseReportType { get; set;}
        public string? OwnerName { get; set; }
        public string? OwnerNationalIDNumber { get; set; }
        public string? DriverName { get;set; }
        public string? DriverNationalIDNumber { get; set; }
        public string? VehicleColor { get; set; }
        public string? VehicleBrand { get; set; }
        public string? VehicleModel { get; set; }
        public string VehicleImpoundNumber { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? ImpoundDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ExitDate { get; set; }
        public string VehicleSector { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"رقم المركبة: {ArabicNumbers.ToArabicDigits(VehicleNo)}\nنوع المركبة: {VehicleType}\nرقم شاسيه المركبة: {VehicleChassisNumber}\nرقم موتور المركبة : {VehicleEngineNumber}\nرقم المحضر : {CaseReportNumber}\nنوع المحضر : {CaseReportType}\nاسم المالك: {OwnerName}\nالرقم القومي للمالك : {OwnerNationalIDNumber}\nاسم قائد المركبة أثناء الضبط : {DriverName}\nالرقم القومي لقائد المركبة أثناء الضبط : {DriverNationalIDNumber}\nلون المركبة : {VehicleColor}\nماركة المركبة : {VehicleBrand}\nالموديل : {VehicleModel}\nرقم حجز المركبة: {VehicleImpoundNumber}\nمكان الحجز : {VehicleSector}\nتاريخ الحجز: {ImpoundDate:yyyy-MM-dd}\nتاريخ الخروج: {ExitDate?.ToString(format: "yyyy-MM-dd") ?? ""}\n";
        }
    }
}
