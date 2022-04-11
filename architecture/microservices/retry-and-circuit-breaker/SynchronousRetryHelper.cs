public static class RetryHelper
{
    private static ILog logger = LogManager.GetLogger(); //use a logger or trace of your choice
    
    public static void RetryOnException(int times, TimeSpan delay,  Action operation)
    {
        var attempts = 0;
        do
        {
            try
            {
                attempts++;
                operation();
                break; // Success! Lets exit the loop!
            }
            catch (Exception ex)
            {               
                if (attempts == times)
                    throw;
                
                logger.Error($"Exception caught on attempt {attempts} - will retry after delay {delay}", ex);   
                             
                Task.Delay(delay).Wait();
            }
        } while (true);
    }
}

// Consumer Code 
public class Client {

    public void Operation(){
        var maxRetryAttempts = 3;
        var pauseBetweenFailures = TimeSpan.FromSeconds(2);
        RetryHelper.RetryOnException(maxRetryAttempts, pauseBetweenFailures, () => {
            product = httpClient.Get("https://example.com/api/products/1");
        });
    }
}