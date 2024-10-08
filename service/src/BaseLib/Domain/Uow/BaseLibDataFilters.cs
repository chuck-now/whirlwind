using BaseLib.Domain.Entities;

namespace BaseLib.Domain.Uow
{
    /// <summary>
    /// Standard filters of BaseLib.
    /// </summary>
    public static class BaseLibDataFilters
    {
        /// <summary>
        /// "SoftDelete".
        /// Soft delete filter.
        /// Prevents getting deleted data from database.
        /// See <see cref="ISoftDelete"/> interface.
        /// </summary>
        public const string SoftDelete = "SoftDelete";
    }
}