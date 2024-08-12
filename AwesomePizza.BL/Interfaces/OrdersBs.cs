using AwesomePizza.Common.Models.Dto;

namespace AwesomePizza.BL.Interfaces;

public interface IOrdersBs
{
    /// <summary>
    /// Delete orders from ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ResponseDto> Delete(Guid id);
}