using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Charon.Modularity;

public static class InitLogger
{
    public static ILogger Logger { get; set; } = NullLogger.Instance;

    public static void LogDebug(EventId eventId, Exception? exception, string? message, params object?[] args)
    {
        Logger.LogDebug(eventId, exception, message, args);
    }

    public static void LogDebug(EventId eventId, string? message, params object?[] args)
    {
        Logger.LogDebug(eventId, message, args);
    }

    public static void LogDebug(Exception? exception, string? message, params object?[] args)
    {
        Logger.LogDebug(exception, message, args);
    }

    public static void LogDebug(string? message, params object?[] args)
    {
        Logger.LogDebug(message, args);
    }

    public static void LogTrace(EventId eventId, Exception? exception, string? message, params object?[] args)
    {
        Logger.LogTrace(eventId, exception, message, args);
    }

    public static void LogTrace(EventId eventId, string? message, params object?[] args)
    {
        Logger.LogTrace(eventId, message, args);
    }

    public static void LogTrace(Exception? exception, string? message, params object?[] args)
    {
        Logger.LogTrace(exception, message, args);
    }

    public static void LogTrace(string? message, params object?[] args)
    {
        Logger.LogTrace(message, args);
    }

    public static void LogInformation(EventId eventId, Exception? exception, string? message, params object?[] args)
    {
        Logger.LogInformation(eventId, exception, message, args);
    }

    public static void LogInformation(EventId eventId, string? message, params object?[] args)
    {
        Logger.LogInformation(eventId, message, args);
    }

    public static void LogInformation(Exception? exception, string? message, params object?[] args)
    {
        Logger.LogInformation(exception, message, args);
    }

    public static void LogInformation(string? message, params object?[] args)
    {
        Logger.LogInformation(message, args);
    }

    public static void LogWarning(EventId eventId, Exception? exception, string? message, params object?[] args)
    {
        Logger.LogWarning(eventId, exception, message, args);
    }

    public static void LogWarning(EventId eventId, string? message, params object?[] args)
    {
        Logger.LogWarning(eventId, message, args);
    }

    public static void LogWarning(Exception? exception, string? message, params object?[] args)
    {
        Logger.LogWarning(exception, message, args);
    }

    public static void LogWarning(string? message, params object?[] args)
    {
        Logger.LogWarning(message, args);
    }

    public static void LogError(EventId eventId, Exception? exception, string? message, params object?[] args)
    {
        Logger.LogError(eventId, exception, message, args);
    }

    public static void LogError(EventId eventId, string? message, params object?[] args)
    {
        Logger.LogError(eventId, message, args);
    }

    public static void LogError(Exception? exception, string? message, params object?[] args)
    {
        Logger.LogError(exception, message, args);
    }

    public static void LogError(string? message, params object?[] args)
    {
        Logger.LogError(message, args);
    }

    public static void LogCritical(EventId eventId, Exception? exception, string? message, params object?[] args)
    {
        Logger.LogCritical(eventId, exception, message, args);
    }

    public static void LogCritical(EventId eventId, string? message, params object?[] args)
    {
        Logger.LogCritical(eventId, message, args);
    }

    public static void LogCritical(Exception? exception, string? message, params object?[] args)
    {
        Logger.LogCritical(exception, message, args);
    }

    public static void LogCritical(string? message, params object?[] args)
    {
        Logger.LogCritical(message, args);
    }
}
