__Git__:

```yaml
Message: [Main Task ID][Main Name] - [Internal Task ID]Internal name
```
---
__Debug__:
```csharp
if (DebugTools.IsInDesignMode()) return;
```
___
__Logs__:

```csharp
private static readonly ILog 
Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
```

```csharp
Logger.Debug(TraceMessage.Execute(this,""));
```
---    

__Images from Resources__:

```csharp
Engine.Properties.Resources.BordersSelected;
```
---

__Cross-thread operation not valid__:
```csharp
txtVelocity.Invoke(new MethodInvoker(delegate () {
                txtVelocity.Text = spaceShip.Speed.ToString("0.##");
            }));
```
___