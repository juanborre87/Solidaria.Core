using System.Data;

namespace Solidaria.Core;

public interface IDapperRepository
{
    /// <summary>
    /// Ejecuta una consulta y devuelve una secuencia de elementos del tipo <typeparamref name="T"/>.
    /// </summary>
    Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? param = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Ejecuta una consulta y devuelve un único elemento del tipo <typeparamref name="T"/>.
    /// Lanza una excepción si no se devuelve ningún registro o más de un registro.
    /// </summary>
    Task<T> QuerySingleAsync<T>(
        string sql,
        object? param = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Ejecuta un comando (como INSERT, UPDATE, DELETE) y devuelve el número de filas afectadas.
    /// </summary>
    Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        CommandType commandType = CommandType.Text,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Selecciona el DbContext que se utilizará para las operaciones de Dapper
    /// </summary>
    void Use(string dbChoice);

    /// <summary>
    /// Devuelve la conexión subyacente (abierta) para operaciones avanzadas.
    /// </summary>
    IDbConnection GetConnection();
}
