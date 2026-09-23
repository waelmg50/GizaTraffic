using System.ComponentModel.DataAnnotations;

namespace GizaTraffic.Models
{
    public class ProgramSetting : BaseModel
    {
        [Key]
        public int ProgramSettingID { get; set; }
        public string QRCodeHeader { get; set; } = string.Empty;
        public string QRCodeFooter { get; set; } = string.Empty;

    }
}
