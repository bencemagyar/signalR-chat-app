## Backend létrehozás ez alapján:

https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr-typescript-webpack?view=aspnetcore-8.0&tabs=visual-studio-code

Csak ezeket hajtottam végre:

- `dotnet new web -o SignalRWebpack`

- [Configure the server](https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr-typescript-webpack?view=aspnetcore-8.0&tabs=visual-studio-code#configure-the-server) fejezet zöld részeit hozzáadtam

- Hubs/ChatHub.cs -t elkészítettem a leírás alapján

- A Program.cs fájlban beregisztráltam az elkészített ChatHub -ot

## Frontend:

- Új angular projekt
- feltelepítem a SignalR Kliens könyvtárat:
  `npm i @microsoft/signalr`

#### app.component.ts

- Elkészítem az app.component.ts -be a felületet
- elkészítettem egy connection változót, aminek beállítottam az url-t, és lebuildeltem

```ts
connection = new signalR.HubConnectionBuilder()
  .withUrl('http://localhost:5188/hub')
  .build();
```

- az ngOnInitben feliratkozom a Hub-nak a `messageReceived` eseményére, és átadok egy callbacket, ami meg fog hívódni mindig, amikor a backend elsüti ezt az eseményt.
  (ezt azért az ngOnInit-ben teszem, mert a connection létrehozását csak egyszer akarom, hogy lefusson, mert csak egy connection
  kell az egész app-ba. Ez nyitva marad, amíg be nem zárom, ezen fogok majd sokféle event-re reagálni)

```ts
this.connection.on(
  'messageReceived' /* callback, ami meghívódjon, ha a ws szerver messageReceived eseményt süt el*/
);
```

- elstartolom a connectiont

```ts
this.connection.start().then(/* ... */); //...;
```
