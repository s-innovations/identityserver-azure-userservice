# identityserver-azure-userservice

Was playing with the idea that instead of having a SQL store for identities and microsoft introducing azure ad b2c tenants that maybe IdentityServer could work with azure ad tenant as store for users.

[UnitTest1](https://github.com/s-innovations/identityserver-azure-userservice/blob/master/tests/AzureADUserServiceTests/UnitTest1.cs) has the create user, list users and signin prototypes.
[AdUserService](https://github.com/s-innovations/identityserver-azure-userservice/blob/master/src/IdentityServer.AzureAdUserService/AdUserService.cs) has the TODOS of whats needed to create a user service.


## Pro/cons
The benefits are that we get a NOSQL alike store accessible over HTTPS to handle all user/password information. Azure already have users sync across the globe and provides scaling of many users.
The cons are that one needs to implement all the logic/abstraction on top of the rest calls like UserManager of aspnet identity.


## Reason for not just using B2C tenants
I prefer the configuration options and full openidconnect spec being available from identity server.

One can edit the user information of the user that was created in the unit test by navigating to
[https://login.microsoftonline.com/car2cloudb2c.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1_car2cloud-b2c-profile&client_Id=7230cf4a-fb8d-4a01-b6e4-cdbb76a3995b&nonce=defaultNonce&redirect_uri=http%3A%2F%2Flocalhost%3A11809%2F&scope=openid&response_type=id_token&prompt=login](https://login.microsoftonline.com/car2cloudb2c.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1_car2cloud-b2c-profile&client_Id=7230cf4a-fb8d-4a01-b6e4-cdbb76a3995b&nonce=defaultNonce&redirect_uri=http%3A%2F%2Flocalhost%3A11809%2F&scope=openid&response_type=id_token&prompt=login)
and signing in with `myUserName` and `P@ssword!`
