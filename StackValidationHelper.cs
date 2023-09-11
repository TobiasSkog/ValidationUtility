namespace ValidationHelper
{
    internal class StackValidationHelper
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
