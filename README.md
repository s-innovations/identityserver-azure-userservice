# identityserver-azure-userservice

Was playing with the idea that instead of having a SQL store for identities and microsoft introducing azure ad b2c tenants that maybe IdentityServer could work with azure ad tenant as store for users.

[UnitTest1](https://github.com/s-innovations/identityserver-azure-userservice/blob/master/tests/AzureADUserServiceTests/UnitTest1.cs) has the create user, list users and signin prototypes.
[AdUserService](https://github.com/s-innovations/identityserver-azure-userservice/blob/master/src/IdentityServer.AzureAdUserService/AdUserService.cs) has the TODOS of whats needed to create a user service.


## Pro/cons
The benefits are that we get a NOSQL alike store accessible over HTTPS to handle all user/password information. Azure already have users sync across the globe and provides scaling of many users.
The cons are that one needs to implement all the logic/abstraction on top of the rest calls like UserManager of aspnet identity.


## Reason for not just using B2C tenants
I prefer the configuration options and full openidconnect spec being available from identity server.
