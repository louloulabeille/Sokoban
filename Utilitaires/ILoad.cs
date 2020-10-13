using System;
using System.Collections;
using System.Collections.Generic;

namespace Utilitaires
{
    public interface ILoad
    {
        List<List<char>> Load(string path, int level);
    }
}
