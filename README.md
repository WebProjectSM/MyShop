# myWebApp
This site was writen as a .Net 6 with WebApi using Rest Api.
This is monolith server using layers: ui,servise for business layer,reposetory for connecting with DB and DTO for transfer data to the client mapping object using AutoMapper.
The layers are connected using dependency injection, using ORM library of Entity Framework Core 6 (DB first).
A special attention was given on browser caching, using async await and scaling.
Error handling was done for all over the server site. and all errors were logged and managed using the Nlog library.
Configuration is used for some changes and all enters to the site are records using rating middleware
