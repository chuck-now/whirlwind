using BaseLib;
using Ayo.Core.Services.Collect.Admin;

namespace Ayo.API.Controllers
{
    public partial class AdminController : ApiControllerBase
    {
        private readonly IRobotAdminService _robotAdminService;

        public AdminController()
        {
            _robotAdminService = BaseLibEngine.Instance.Resolve<IRobotAdminService>();
        }
    }
}