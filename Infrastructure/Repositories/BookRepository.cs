﻿using Application.Abstractions;
using Application.Entities;
using Infrastructure.Repositories.Generic;

namespace Infrastructure.Repositories;

internal sealed class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}
