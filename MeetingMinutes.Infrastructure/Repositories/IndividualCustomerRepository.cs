﻿using Dapper;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.DBContext;

namespace MeetingMinutes.Infrastructure.Repositories;

public class IndividualCustomerRepository : IIndividualCustomerRepository
{
    private readonly IDbContext _dbContext;
    public IndividualCustomerRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<IndividualCustomer>> GetAllIndividualCustomersAsync()
    {
        using var connection = _dbContext.CreateConnection();
        const string sql = "SELECT * FROM Individual_Customer_Tbl  WHERE IsActive = 1";
        var result = await connection.QueryAsync<IndividualCustomer>(sql);
        return result;
    }
}