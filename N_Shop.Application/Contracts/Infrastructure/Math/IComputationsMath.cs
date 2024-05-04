using N_Shop.Application.Constants.Enums;

namespace N_Shop.Application.Contracts.Infrastructure.Math
{
    public interface IComputationsMath
    {
        public int Operation(ComputationsMathEnum computationsMathEnum, params int[] values);
    }
}
