﻿using Microsoft.EntityFrameworkCore.Query;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    public interface IIncludeDbQuery<out TEntity, out TProperty> : IIncludableQueryable<TEntity, TProperty>
    {
    }
}
