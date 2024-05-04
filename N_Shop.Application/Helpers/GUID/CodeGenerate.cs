using N_Shop.Application.Contracts.Infrastructure.GUID;

namespace N_Shop.Application.Helpers.GUID
{
    public class CodeGenerate : ICodeGenerate
    {
        public string GenerateGUID()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
