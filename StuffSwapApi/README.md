readme


Get a token by making a POST request to http://localhost:5290/api/Users/GetToken

appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Jwt": {
    "Issuer": "Issuer",
    "Audience": "Audience",
    "Key": "bd1a1ccf8095037f361a4d351e7c0de65f0776bfc2f478ea8d312c763bb6caca"
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=stuff_swap_api;uid=root;pwd=epicodus"
  }
}

further exploration
add token to swagger