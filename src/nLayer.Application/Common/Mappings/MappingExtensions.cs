﻿namespace nLayer.Application.Common.Mappings;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

public static class MappingExtensions
{
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(
        this IQueryable queryable,
        IConfigurationProvider configuration)
        where TDestination : class
            => queryable
                .ProjectTo<TDestination>(configuration)
                .AsNoTracking()
                .ToListAsync();
}