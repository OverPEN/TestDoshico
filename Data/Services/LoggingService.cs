using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Data.Services
{
    public static class LoggingService
    {
        static bool isRunning;
        public static void StartLogger()
        {
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")))
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"));
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "TestDoshicoLog.log"),
                    rollingInterval: RollingInterval.Month,
                    restrictedToMinimumLevel: Debugger.IsAttached ? Serilog.Events.LogEventLevel.Verbose : Serilog.Events.LogEventLevel.Information,
                    outputTemplate: "[ {Timestamp:dd-MM-yyyy HH:mm:ss} {Level:u3} ] {Message:l}{NewLine}{Exception}")
                .CreateLogger();

            isRunning = true;
            LogInformation("Servizio di logging avviato!");
        }

        public static void StopLogger()
        {
            LogInformation("Servizio di logging arrestato!");
            Log.CloseAndFlush();
            isRunning = false;
        }

        public static void LogVerbose(string message)
        {
            if (isRunning)
                Log.Verbose($"{NameOfCallingClass()} - {message}");
        }

        public static void LogDebug(string message)
        {
            if (isRunning)
                Log.Debug($"{NameOfCallingClass()} - {message}");
        }

        public static void LogInformation(string message)
        {
            if (isRunning)
                Log.Information($"{NameOfCallingClass()} - {message}");
        }

        public static void LogWarning(string message)
        {
            if (isRunning)
                Log.Warning($"{NameOfCallingClass()} - {message}");
        }

        public static void LogError(string message, Exception ex = null)
        {
            if (isRunning)
                Log.Verbose($"{NameOfCallingClass()} - {message}", ex);
        }

        public static void LogVerbose(string message, Exception ex)
        {
            if (isRunning)
                Log.Fatal($"{NameOfCallingClass()} - {message}", ex);
        }

        public static string NameOfCallingClass()
        {
            string fullName;
            Type declaringType;
            int skipFrames = 2;
            do
            {
                MethodBase method = new StackFrame(skipFrames, false).GetMethod();
                declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    return method.Name;
                }
                skipFrames++;
                fullName = declaringType.FullName;
            }
            while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));

            return fullName;
        }
    }
}
