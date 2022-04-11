using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Utils
{
    public static class RetryHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task RetryOnExceptionAsync(
            int times, TimeSpan delay, Func<Task> operation)
        {
            await RetryOnExceptionAsync<Exception>(times, delay, operation);
        }

        public static async Task RetryOnExceptionAsync<TException>(
            int times, TimeSpan delay, Func<Task> operation) where TException : Exception
        {
            if (times <= 0) 
                throw new ArgumentOutOfRangeException(nameof(times));

            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    await operation();
                    break;
                }
                catch (TException ex)
                {
                    if (attempts == times)
                        throw;

                    await CreateDelayForException(times, attempts, delay, ex);
                }
            } while (true);
        }
        
        private static Task CreateDelayForException(
            int times, int attempts, TimeSpan delay, Exception ex)
        {
            var delay = IncreasingDelayInSeconds(attempts);
            Log.Warn($"Exception on attempt {attempts} of {times}. " + 
                      "Will retry after sleeping for {delay}.", ex);
            return Task.Delay(delay);
        }
        
        internal static int[] DelayPerAttemptInSeconds = 
        {
            (int) TimeSpan.FromSeconds(2).TotalSeconds,
            (int) TimeSpan.FromSeconds(30).TotalSeconds,
            (int) TimeSpan.FromMinutes(2).TotalSeconds,
            (int) TimeSpan.FromMinutes(10).TotalSeconds,
            (int) TimeSpan.FromMinutes(30).TotalSeconds
        };
        
        static int IncreasingDelayInSeconds(int failedAttempts)
        {
            if (failedAttempts <= 0) throw new ArgumentOutOfRangeException();

            return failedAttempts > DelayPerAttemptInSeconds.Length ? DelayPerAttemptInSeconds.Last() : DelayPerAttemptInSeconds[failedAttempts];
        }
    }
}

public class Client {

    public void Operation(){
        var maxRetryAttempts = 3;  
        var pauseBetweenFailures = TimeSpan.FromSeconds(2);  
        await RetryHelper.RetryOnExceptionAsync<HttpRequestException>
            (maxRetryAttempts, pauseBetweenFailures, async () => {
                var response = await httpClient.DeleteAsync(
                "https://example.com/api/products/1");
            response.EnsureSuccessStatusCode();
    }); 
    }
}