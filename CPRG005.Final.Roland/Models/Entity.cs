using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG005.Final.Roland.Models
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
