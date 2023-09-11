namespace ValidationUtility
{
    internal class ListValidationHelper
    {
        public static void AddObjectsToList<T>(T[] objects, List<T> list)
        {
            foreach (var obj in objects)
            {
                try
                {
                    list.Add(obj);
                }
                catch (ArgumentException ex)
                {
                    ExceptionHelper.ExceptionDetails(ex);
                }
            }
        }

        public static void FindFirstInList<T>(List<T> list, Func<T, string> getProperty, string findItem)
        {
            try
            {
                var results = list.FirstOrDefault(item => getProperty(item) == findItem);

                if (results != null)
                {
                    Console.WriteLine(results);
                }
                else
                {
                    Console.WriteLine($"List did not contain \"{findItem}\".");
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionDetails(ex);
            }
        }

        public static void FindAllInList<T>(List<T> list, Func<T, string> getProperty, string findItem)
        {
            try
            {
                var results = list.Where(item => getProperty(item) == findItem).ToList();

                if (results.Count > 0)
                {
                    foreach (var item in results)
                    {
                        Console.WriteLine(item);
                    }
                }

                else
                {
                    Console.WriteLine($"List did not contain \"{findItem}\".");
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.ExceptionDetails(ex);
            }

        }
    }
}
