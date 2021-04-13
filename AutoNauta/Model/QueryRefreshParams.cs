
namespace AutoNauta.Model
{
    public class QueryRefreshParams : QueryDisconnectParams
    {
        public string op { get; set; } = "getLeftTime";
    }
}