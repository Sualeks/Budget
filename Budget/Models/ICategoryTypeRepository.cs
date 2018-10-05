using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.Models
{
    public interface ICategoryTypeRepository
    {
        IQueryable<CategoryType> CategoryTypes { get; }
    }
}
