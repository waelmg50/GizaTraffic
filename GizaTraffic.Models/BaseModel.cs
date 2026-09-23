using Newtonsoft.Json;

namespace GizaTraffic.Models
{
    public class BaseModel
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
