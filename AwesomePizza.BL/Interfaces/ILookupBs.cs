using AwesomePizza.Common.Models.Dto;

namespace AwesomePizza.BL.Interfaces;

public interface ILookupBs
{
    /// <summary>
    /// Get status
    /// </summary>
    /// <returns></returns>
    Task<List<LookupDto>> Status();
    
    /// <summary>
    /// Get food type
    /// </summary>
    /// <returns></returns>
    Task<List<LookupDto>> FoodType();
    
    /// <summary>
    /// Get ingredient
    /// </summary>
    /// <returns></returns>
    Task<List<LookupDto>> Ingredient();
}