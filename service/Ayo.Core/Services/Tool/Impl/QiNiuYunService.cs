using BaseLib;
using Qiniu.Storage;
using Qiniu.Util;
using Ayo.Core.Configuration;
using Ayo.Core.Dto.Tool.Params;

namespace Ayo.Core.Services.Tool.Impl
{
    public partial class QiNiuYunService : ServiceBase, IQiNiuYunService
    {
        private readonly AppOptions _appOptions;

        public QiNiuYunService()
        {
            _appOptions = BaseLibEngine.Instance.Resolve<AppOptions>();
        }

        public GetQiniuyunUploadInfoOutput GetQiniuyunUploadInfo()
        {
            GetQiniuyunUploadInfoOutput output = new GetQiniuyunUploadInfoOutput();

            Mac mac = new Mac(_appOptions.UploadOptions.QiNIuAccessKey, _appOptions.UploadOptions.QiNIuSecretKey);

            PutPolicy putPolicy = new PutPolicy
            {
                Scope = _appOptions.UploadOptions.QiNIuScope
            };

            putPolicy.SetExpires(7200);//两小时

            output.Token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            output.Url = _appOptions.UploadOptions.QiNIuOutUrl;

            return output;
        }
    }
}