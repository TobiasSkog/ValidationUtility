namespace ValidationUtility
{
  /// <summary>
  /// Validation Helper Class for Lists.<br></br>
  /// Includes the List functionality to Add, FindFirst, FindAll with exception handling implemented.
  /// </summary>
  public class ListValidationHelper
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

    public static void FindFirstInList<T>(List<T> list, Func<T, string> getObjectString, string findItem)
    {
      try
      {

        var results = list.FirstOrDefault(item => getObjectString(item) == findItem);

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

    public static T GetFirstInList<T>(List<T> list, Func<T, string> getObjectString, string findItem)
    {
      try
      {

        var results = list.FirstOrDefault(item => getObjectString(item) == findItem);

        if (results != null)
        {
          return results;
        }
        else
        {
          Console.WriteLine($"List did not contain \"{findItem}\".");
          return default(T);
        }
      }
      catch (Exception ex)
      {
        ExceptionHelper.ExceptionDetails(ex);
        return default(T);
      }
    }


    public static List<T> GetAllInList<T>(List<T> list, Func<T, string> getProperty, string findItem)
    {
      try
      {

        var results = list.Where(item => getProperty(item) == findItem).ToList();

        if (results.Count > 0)
        {
          return results;
        }

        else
        {
          Console.WriteLine($"List did not contain \"{findItem}\".");
          return default(List<T>);
        }
      }
      catch (Exception ex)
      {
        ExceptionHelper.ExceptionDetails(ex);
        return default(List<T>);
      }

    }

    public static void FindAllInList<T>(List<T> list, Func<T, string> getObjectString, string findItem)
    {
      try
      {

        var results = list.Where(item => getObjectString(item) == findItem).ToList();

        if (results.Count > 0)
        {
          foreach (var item in results)
          {
            Console.WriteLine(getObjectString(item));
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

    public static void ListContains<T>(T[] objects, List<T> list, int placementInObjArray)
    {
      try
      {
        if (list.Contains(objects[placementInObjArray - 1]))
        {
          Console.WriteLine($"Employee{placementInObjArray} object exists in the list");
        }
        else
        {
          Console.WriteLine($"Employee{placementInObjArray} object does not exist in the list");
        }
      }
      catch (Exception ex)
      {
        ExceptionHelper.ExceptionDetails(ex);
      }
    }


  }
}
