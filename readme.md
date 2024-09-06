To test the api endpoints in swagger first create a jwt token with the following commmand

```
dotnet user-jwts create
```

Copy the token into the authorize field in swagger.

Valid request objects for Post Referral:

```
{
  "userId": 1,
  "referralCode": "111111",
  "name": "any name",
  "phone": "1234567890"
}
{
  "userId": 2,
  "referralCode": "222222",
  "name": "any name",
  "phone": "1234567890"
}
{
  "userId": 3,
  "referralCode": "333333",
  "name": "any name",
  "email": "oryoucantry@email.com"
}

```
