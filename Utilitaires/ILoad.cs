using System;
using System.Collections;

namespace Utilitaires
{
    public interface ILoad
    {
        IEnumerable Load(string path, int level);
    }
}
