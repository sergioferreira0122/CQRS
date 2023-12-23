
namespace App.Abstractions
{
    public interface IMapper<TParameter, KResult>
    {
        KResult Map(TParameter data);
    }
}
