namespace Solidaria.Core;

public interface IEFCommandRepository<T> where T : class
{
    /// <summary>
    /// Inserta una nueva entidad en una transacción activa sin guardar inmediatamente.
    /// </summary>
    Task AddAsync(
        T entity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Inserta múltiples entidades en una transacción activa sin guardar inmediatamente.
    /// </summary>
    Task AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Actualiza una entidad dentro de una transacción activa sin guardar inmediatamente.
    /// </summary>
    Task UpdateAsync(
        T entity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Actualiza múltiples entidades dentro de una transacción activa sin guardar inmediatamente.
    /// </summary>
    Task UpdateRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Elimina una entidad.
    /// </summary>
    Task DeleteAsync(
        T entity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Elimina múltiples entidades.
    /// </summary>
    Task DeleteRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Guarda todos los cambios pendientes en el contexto actual en la base de datos.
    /// </summary>
    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
