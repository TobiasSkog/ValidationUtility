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
    }
}
