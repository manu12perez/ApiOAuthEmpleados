using System.Security.Claims;
using ApiOAuthEmpleados.Models;
using Newtonsoft.Json;

namespace ApiOAuthEmpleados.Helpers
{
    public class HelperEmpleadoToken
    {
        private IHttpContextAccessor contextAccessor;

        public HelperEmpleadoToken(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public EmpleadoModel GetEmpleado()
        {
            Claim claim = this.contextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserData");
            string json = claim.Value;
            string jsonEmpleado = HelperCryptography.DecryptString(json);
            EmpleadoModel model = JsonConvert.DeserializeObject<EmpleadoModel>(jsonEmpleado);
            return model;
        }
    }
}
