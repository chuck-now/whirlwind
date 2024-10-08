namespace BaseLib.WebApi
{
    public class BaseLibResponse<TResult> : BaseLibResponse where TResult : class
    {
        public TResult Result { get; set; }
    }
}