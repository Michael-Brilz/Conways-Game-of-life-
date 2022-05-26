# PWS40.Backend
Backend repository for the PWS40 Assignment


# How to run the backend.

> First navigate in the following directory with any terminal app:

```
\PWS40.Backend\src\PWS40.Backend.Conways.API
```

> Execute now the following command:

```
dotnet build
```
...the application is now being built.

> After finishing the build, run the next command:
```
dotnet run
```

...the application should now running.

> A text similar to the one below should now appear in the terminal.

Build process is being executed...  \
info: Microsoft.Hosting.Lifetime[14] \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Now listening on: https://localhost:7238 \
info: Microsoft.Hosting.Lifetime[14] \
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Now listening on: http://localhost:5238 \
      
> Copy now the underlined url and add __/swagger/index.html__ to the address like:

```
https://localhost:7238/swagger/index.html
```
There you can see now the swagger ui to test the controller functionality.
