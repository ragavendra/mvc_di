### Info
Project demonstrates `mvc` and `di` in controllers. Keycloak bearer auth server is also setup.

Read [this][def] for info.

[def]: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-8.0&tabs=linux

Using bearer authentication. Creating local token by doing beow for the required scope. Check [Program.cs](./Program.cs) and `appsettings.Development.json` for more info.

```
dotnet user-jwts create --name MyTestUser --scope "myapi:secrets"

dotnet user-jwts create
dotnet user-jwts print {ID} --show-all

curl -i -H "Authorization: Bearer $TOKEN" http://localhost:5111/secret
```

Using Keycloak as Bearer auth server. Run it as a docker image. Follow - [this]()

```
docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:23.0.7 start-dev
```
Create realm, user and all.

Use below curl to fetch the bearer token.
```
curl --data "grant_type=password&client_id=myclient&username=myuser&password=passwd&client_secret=cliSecret" localhost:8080/realms/myrealm/protocol/openid-connect/token
```

Having issues with r-admin ( resource admin )
