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
        public string? CaseReportType { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerNationalIDNumber { get; set; }
        public string? DriverName { get; set; }
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
            return $"رقم المركبة: {DisplayVehicleNo()}\nنوع المركبة: {VehicleType}\nرقم شاسيه المركبة: {VehicleChassisNumber}\nرقم موتور المركبة : {VehicleEngineNumber}\nرقم المحضر : {CaseReportNumber}\nنوع المحضر : {CaseReportType}\nاسم المالك: {OwnerName}\nالرقم القومي للمالك : {OwnerNationalIDNumber}\nاسم قائد المركبة أثناء الضبط : {DriverName}\nالرقم القومي لقائد المركبة أثناء الضبط : {DriverNationalIDNumber}\nلون المركبة : {VehicleColor}\nماركة المركبة : {VehicleBrand}\nالموديل : {VehicleModel}\nرقم حجز المركبة: {VehicleImpoundNumber}\nمكان الحجز : {VehicleSector}\nتاريخ الحجز: {ImpoundDate:yyyy-MM-dd}\nتاريخ الخروج: {ExitDate?.ToString(format: "yyyy-MM-dd") ?? ""}\n";
        }
        public string DisplayVehicleNo()
        {
            return DisplayVehicleNo(VehicleNo ?? string.Empty);
        }
        public static string DisplayVehicleNo(string newVehicleNo)
        {
            if (string.IsNullOrWhiteSpace(newVehicleNo))
                return string.Empty;
            //First remove spaces
            string vehicleNo = ArabicNumbers.ToArabicDigits(newVehicleNo.Replace(" ", string.Empty));
            string integralPart = string.Empty;
            if (vehicleNo.Length > 0)
                //The integral part is the  last 4 digits.
                integralPart = vehicleNo[^4..];
            string strAlphabiticsPart = vehicleNo[..^4];
            return $"{(strAlphabiticsPart.Length > 0 ? strAlphabiticsPart[..1] : string.Empty)} {(strAlphabiticsPart.Length > 1 ? strAlphabiticsPart.Substring(1, 1) : string.Empty)} {(strAlphabiticsPart.Length > 2 ? strAlphabiticsPart.Substring(2, 1) : string.Empty)} {integralPart}";
        }
    }
}
