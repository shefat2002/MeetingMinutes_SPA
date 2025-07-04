﻿using Microsoft.Data.SqlClient;
using System.Data;


namespace MeetingMinutes.Infrastructure.DBContext;
public class DapperDbContext : IDbContext
{
    private readonly string _connectionString;
    public DapperDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

