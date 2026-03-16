namespace Solidaria.Core;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Guarda una transacción simple en la base de datos indicada  (sin transacción explícita).
    /// </summary>
    Task SaveChangesAsync(
        string dbChoice, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Inicia una nueva transacción en la base de datos indicada con nivel de aislamiento por parámetro.
    /// </summary>
    Task BeginTransactionAsync(
        string dbChoice,
        System.Data.IsolationLevel? isolationLevel = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirma los cambios realizados en la base de datos indicada sin necesidad de confirmar la transacción global.
    /// </summary>
    Task CommitAsync(
        string dbChoice,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirma la transacción activa, persistiendo todos los cambios en las bases de datos involucradas.
    /// </summary>
    Task CommitAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Revierte los cambios pendientes en la base de datos indicada.
    /// </summary>
    Task RollbackAsync(
        string dbChoice, 
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Revierte los cambios pendientes en todas las bases de datos.
    /// </summary>
    Task RollbackAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Provee acceso al Repositorio de Comandos EF para operaciones de escritura sobre la base de datos indicada.
    /// </summary>
    IEFCommandRepository<T> CommandRepository<T>(string dbChoice) where T : class;

    /// <summary>
    /// Provee acceso al Repositorio de Consultas EF para operaciones de lectura sobre la base de datos indicada.
    /// </summary>
    IEFQueryRepository<T> QueryRepository<T>(string dbChoice) where T : class;

    /// <summary>
    /// Provee acceso al repositorio Dapper para ejecutar SQL crudo o consultas ligeras.
    /// </summary>
    IDapperRepository DapperRepository(string dbChoice);
}
