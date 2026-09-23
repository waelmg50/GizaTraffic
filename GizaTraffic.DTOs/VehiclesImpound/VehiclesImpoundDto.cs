namespace GizaTraffic.DTOs.VehiclesImpound
{
    public class VehiclesImpoundDto
    {
        public int VehicleImpoundId { get; set; }
        public string? VehicleNo { get; set; } = string.Empty;
        public string? OwnerName { get; set; } = string.Empty;
        public string? VehicleImpoundNumber { get; set; } = string.Empty;
        public string? VehicleSector { get; set; }
        public string? CaseReportNumber { get; set; } = string.Empty;
        public string? CaseReportType { get; set; } = string.Empty;
    }
}
