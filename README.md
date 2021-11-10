# Error repro for https://github.com/Azure/azure-functions-openapi-extension/issues/313

To reproduce, run:

```
dotnet restore
func start
```

and hit http://localhost:7071/api/swagger/ui

This will trigger the `Index was outside the bounds of the array.` error.