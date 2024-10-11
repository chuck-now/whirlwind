using BaseLib;
using Ayo.Core.Services.Collect.Admin;
using Ayo.Core.Services.Manager.Admin;

namespace Ayo.API.Controllers
{
    public partial class AdminController : ApiControllerBase
    {
        private readonly IRobotAdminService _robotAdminService;
        private readonly IAccountAdminService _accountAdminService;

        public AdminController()
        {
            _robotAdminService = BaseLibEngine.Instance.Resolve<IRobotAdminService>();
            _accountAdminService = BaseLibEngine.Instance.Resolve<IAccountAdminService>();
        }
    }
}