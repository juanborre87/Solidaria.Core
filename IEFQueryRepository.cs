using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Solidaria.Core;

public interface IEFQueryRepository<T> where T : class
{
    // ───────────────────────────────────────────────────────────────
    // Métodos sin paginación
    // ───────────────────────────────────────────────────────────────

    /// <summary>
    /// Devuelve la primera entidad que cumpla el filtro o null si no existe.
    /// </summary>
    Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> expr,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve la primera entidad que coincide con el filtro, incluyendo entidades relacionadas mediante Include/ThenInclude.
    /// </summary>
    Task<T?> FirstOrDefaultIncludeMultipleAsync(
        Expression<Func<T, bool>> expr,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve una lista de entidades que coinciden con el filtro construido, con ordenamiento opcional.
    /// </summary>
    Task<List<T>> WhereAsync(
        Expression<Func<T, bool>> expr,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve una lista de entidades que coinciden con el filtro construido, incluyendo entidades relacionadas con Include/ThenInclude, con ordenamiento opcional.
    /// </summary>
    Task<List<T>> WhereIncludeMultipleAsync(
        Expression<Func<T, bool>> expr,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve todas las entidades.
    /// </summary>
    Task<List<T>> ListAllAsync(
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve todas las entidades incluyendo relacionadas con Include/ThenInclude, con ordenamiento opcional.
    /// </summary>
    Task<List<T>> IncludeMultipleAsync(
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Ejecuta una consulta SQL personalizada y devuelve una lista de entidades del tipo <typeparamref name="T"/>.
    /// </summary>
    Task<List<T>> FromSqlQueryAsync(
        string sql,
        object[]? parameters = null,
        bool tracking = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Ejecuta un comando SQL (<c>INSERT</c>, <c>UPDATE</c> o <c>DELETE</c>) directamente contra la base de datos.
    /// </summary>
    Task<int> ExecuteSqlCommandAsync(
        string sql,
        object[]? parameters = null,
        CancellationToken cancellationToken = default);

    // ───────────────────────────────────────────────────────────────
    // Métodos con paginación
    // ───────────────────────────────────────────────────────────────

    /// <summary>
    /// Devuelve una lista paginada de entidades que coinciden con el filtro construido, con ordenamiento opcional.
    /// </summary>
    Task<PagedResult<T>> WherePagedAsync(
        Expression<Func<T, bool>> expr,
        int pageNumber,
        int pageSize,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve una lista paginada que coincide con el filtro, incluyendo relacionadas con Include/ThenInclude y orden opcional.
    /// </summary>
    Task<PagedResult<T>> WhereIncludeMultiplePagedAsync(
        Expression<Func<T, bool>> expr,
        int pageNumber,
        int pageSize,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve todas las entidades en un resultado paginado con orden opcional.
    /// </summary>
    Task<PagedResult<T>> ListAllPageAsync(
        int pageNumber,
        int pageSize,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Devuelve todas las entidades incluyendo relacionadas con Include/ThenInclude en un resultado paginado con orden opcional.
    /// </summary>
    Task<PagedResult<T>> IncludeMultiplePageAsync(
        int pageNumber,
        int pageSize,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool tracking = true,
        CancellationToken cancellationToken = default);

}
