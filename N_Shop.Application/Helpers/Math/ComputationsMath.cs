using N_Shop.Application.Constants.Enums;
using N_Shop.Application.Contracts.Infrastructure.Math;

namespace N_Shop.Application.Helpers.Math
{
    public class ComputationsMath : IComputationsMath
    {
        public int Operation(ComputationsMathEnum computationsMathEnum, params int[] values)
        {
            int result = 0;
            if (computationsMathEnum == ComputationsMathEnum.Plus)
            {
                foreach (var val in values)
                {
                    result += val;
                }
            }
            if (computationsMathEnum == ComputationsMathEnum.Multiplied)
            {
                int value = 1;
                foreach (var val in values)
                {
                    result = value * val;
                    value = result;
                }
            }
            return result;
        }
    }
}
