# Take.Api.GitChallenge
### 

 1. Objetivo
    ```
        Recuperar reposititorios Github da linguagem C# consumindo API do Github, seguindo os padrões Take de construção para APIs intermediarias.
    ```
    
2. **[If Using SEQ]** Place SEQ's url on the correct property field on `appsettings.json`
```json
    ...
          "serverUrl": "seq-url"
    ...
```

3. Remember to register everything else you create and/or need @ `Startup.cs`

# Handling other exceptions with the Middleware
1. Create a new `Strategy` that inherits from `ExceptionHandlingStrategy`
    * follow the naming format `ExceptionNameHandlingStrategy`
1. Implement the `HandleAsync` method with that specific exception handling
1. Add your new exception handler strategy to the dictionary within the `ServiceCollectionExtensions` class
