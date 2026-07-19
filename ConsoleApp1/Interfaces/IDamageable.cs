using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Interfaces
{
    public interface IDamageable
    {
        string? Name { get;  }
        void TakeDamage(int damage);
    }
}
