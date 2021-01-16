__Logs__:

```csharp
private static readonly ILog 
Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
```

```csharp
Logger.Debug(TraceMessage.Execute(this,""));
```
---    