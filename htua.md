Read [this][def] for info.

[def]: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-8.0&tabs=linux

Using bearer authentication. Creating local token by doing beow for the required scope. Check [Program.cs](./Program.cs) and `appsettings.Development.json` for more info.

```
dotnet user-jwts create --name MyTestUser --scope "myapi:secrets"

dotnet user-jwts create
dotnet user-jwts print {ID} --show-all

curl -i -H "Authorization: Bearer $TOKEN" http://localhost:5111/secret
```
