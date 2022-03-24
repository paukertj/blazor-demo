# blazor-demo
A few examples of Blazor usage.

## JsInterop
This demo demonstrate usage of JsInterop in Blazor. There is a shared library in the example, that contains simple camera implementation written in JavaScript, that is propagated into Blazor component. This component is used in two web projects - Blazor Server website and Blazor WASM website.
### Here you can see following examples
- JavaScript call from Blazor
- JavaScript callback to Blazor
- JavaScript isolation
- CSS isolation
- Component binding
### How to run it
Open `./JsInterop/JsInteropDemo.sln` solution, for Blazor Server demo run `./JsInterop/ServerSideDemo/ServerSideDemo.csproj`, for Blazor WASM demo run `./JsInterop/WasmDemo/WasmDemo.csproj`. Implementation itself is in `./JsInterop/WasmDemo/WasmDemo.csproj`.

## MultiFrontedWithReact
This demo demonstrate very naive implementation of integration Blazor WASM application into existing React application. 
### Here you can see following examples
- Naive injecting Blazor application into React application
- Blazor and React build by NPM script
### How to run it
Navigate itself into `./MultiFrontedWithReact/react-app` and run `npm run start-all`. 

## SharedAssembly
This demo demonstrate sharing an assembly between Client and Server. Basically it is an improvement of Blazor WASM default template, where the data are downloaded from the server. Here, the shared library defines how the API looks like, so you can change it on both sides by some refactoring tool for instance.
### Here you can see following examples
- Sharing library between client and server
### How to run it
Open `./SharedAssembly/SharedAssemblyDemo.sln` solution and run both - `./SharedAssembly/Client/Client.csproj` and `./SharedAssembly/Server/Server.csproj`. The shared project is `./SharedAssembly/Shared/Shared.csproj`.