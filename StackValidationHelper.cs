namespace ValidationUtility
{
  /// <summary>
  /// Validation Helper Class for Lists.<br></br>
  /// Includes the List functionality to Add with exception handling implemented.
  /// </summary>
  // TODO: Implement more functionality like: FindFirst, FindAll
  public class StackValidationHelper
  {
    public static void AddObjectsToStack<T>(T[] objects, Stack<T> stack)
    {
      foreach (var obj in objects)
      {
        try
        {
          stack.Push(obj);
        }
        catch (ArgumentException ex)
        {
          ExceptionHelper.ExceptionDetails(ex);
        }
      }
    }

    public static void ItemsLeftInStack<T>(T[] objects, Stack<T> stack)
    {
      foreach (var obj in objects)
      {
        try
        {
          Console.WriteLine($"{obj}\nItems left in the Stack = {stack.Count}");
        }
        catch (ArgumentException ex)
        {
          ExceptionHelper.ExceptionDetails(ex);
        }
      }
    }

    public static void PopItemsInStack<T>(Stack<T> stack, int maxValue)
    {
      for (int i = 0; i < maxValue; i++)
      {
        try
        {
          Console.WriteLine(stack.Pop());
          Console.WriteLine($"Items left in the Stack = {stack.Count}");
        }
        catch (Exception ex)
        {
          ExceptionHelper.ExceptionDetails(ex);
        }
      }

    }

    public static void PeekItemsInStack<T>(Stack<T> stack, int timesToPeek)
    {
      for (int i = 0; i < timesToPeek; i++)
      {
        try
        {
          Console.WriteLine(stack.Peek().ToString());
          Console.WriteLine($"Items left in the Stack = {stack.Count}");
        }
        catch (Exception ex)
        {
          ExceptionHelper.ExceptionDetails(ex);
        }
      }
    }

    public static void StackContains<T>(T[] objects, Stack<T> stack, int placementInObjArray)
    {
      try
      {
        if (stack.Contains(objects[placementInObjArray - 1]))
        {
          Console.WriteLine($"Emp{placementInObjArray} is in stack");
        }
        else
        {
          Console.WriteLine($"Emp{placementInObjArray} is not in stack");
        }
      }
      catch (Exception ex)
      {
        ExceptionHelper.ExceptionDetails(ex);
      }
    }






  }
}
