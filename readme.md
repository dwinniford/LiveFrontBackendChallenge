New JWT saved with ID '318d29f0'.
Name: dwinn

Token: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImR3aW5uIiwic3ViIjoiZHdpbm4iLCJqdGkiOiIzMThkMjlmMCIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjI0MjgyIiwiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNjkiLCJodHRwOi8vbG9jYWxob3N0OjUwMDciLCJodHRwczovL2xvY2FsaG9zdDo3MjI1Il0sIm5iZiI6MTcyNTU2OTA5MiwiZXhwIjoxNzMzNDMxNDkyLCJpYXQiOjE3MjU1NjkwOTMsImlzcyI6ImRvdG5ldC11c2VyLWp3dHMifQ.dy99FGBVwHB3kE8VnQKHOoDHwEVUW6xGt4BmyOtPYTA

dotnet user-jwts print 318d29f0 --show-all

To test the api endpoints in swagger first create a jwt token with the following commmand

```
dotnet user-jwts create
```

Copy the token into the authorize field in swagger.

Valid request objects for Post Referral:

```
{
  "userId": 1,
  "referralCode": "111111"
}
{
  "userId": 2,
  "referralCode": "222222"
}
{
  "userId": 3,
  "referralCode": "333333"
}

```
