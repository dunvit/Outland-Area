
namespace OutlandAreaCommon.Common
{
    public class TraceMessage
    {
        public static string Execute<T>(T classObject, string message, 
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            //return $"[Class: {classObject.GetType().Name}] [Method: {memberName}] [Line: {sourceLineNumber}]\t\t\t\t\t[GameEvent] {message} \n";
            return $"[{classObject.GetType().Name}.{memberName}.{sourceLineNumber}] {message}";

        }
    }
}
