using AwesomePizza.Common.Models.Dto;

namespace AwesomePizza.BL.Interfaces;

public interface ILookupBs
{
    /// <summary>
    /// Get status
    /// </summary>
    /// <returns></returns>
    Task<List<LookupDto>> Status();
}