using Microsoft.EntityFrameworkCore;

namespace Solidaria.Core;

public interface IDbContextProvider
{
    /// <summary>
    /// Obtiene un DbContext para el nombre indicado
    /// </summary>
    DbContext GetDbContext(string name, IServiceProvider? scopeProvider = null);

    /// <summary>
    /// Libera el scope asociado al nombre
    /// </summary>
    void DisposeScopeFor(string name);

    /// <summary>
    /// Libera todos los scopes
    /// </summary>
    void DisposeAllScopes();

}
