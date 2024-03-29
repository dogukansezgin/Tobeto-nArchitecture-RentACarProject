﻿using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MssqlLogger : LoggerServiceBase
{
    private IConfiguration _configuration;
    public MssqlLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        MssqlConfiguration logConfiguration = _configuration.GetSection("SerilogConfigurations:MssqlConfiguration").
            Get<MssqlConfiguration>() ?? throw new Exception("");

        MSSqlServerSinkOptions sinkOptions = new()
        { TableName = logConfiguration.TableName, AutoCreateSqlTable = logConfiguration.AutoCreateSqlTable };

        ColumnOptions columnOptions = new();

        Logger serilogConfig = new LoggerConfiguration().WriteTo.
            MSSqlServer(logConfiguration.ConnectionString, sinkOptions, columnOptions: columnOptions).CreateLogger();

        Logger = serilogConfig;
    }
}
