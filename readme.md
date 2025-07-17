# About rF2SharedMemoryNet

This project is meant to give you read access to all the data exposed by rFactor 2 shared memory files. It additionally adds some Le Mans Ultimate telemetry that's not available through shared memory.
Le Mans Ultimate telemetry depends on accessing LMU process memory. There is potential that it will break in with next updates.
It is not officially supported so if memory layout changes or they implement anti-cheat it might break.

## Prerequisites

* For this to work it depends on rFactor2 or Le Mans Ultimate to have rFactor2SharedMemoryMapPlugin64.dll enabled.
* .net 8.0

# Quick start
## Instalation

### NuGet
You can install this through NuGet this is the easiet way to access the functionality of this package.
```
nuget install rF2SharedMemoryNet
```

### GitHub Release
You can download a dll from the [releases](https://github.com/Domaslau/rF2SharedMemoryNet/releases) of this repository.

### Build
You can clone the github repo and build it yourself.

``` cmd
git clone https://github.com/Domaslau/rF2SharedMemoryNet.git
```

## Simple Example

Here is a simple example of how to retrieve telemetry data of player vehicle.

``` C#
using rF2SharedMemoryNet;
using rF2SharedMemoryNet.RF2Data.Enums;
using rF2SharedMemoryNet.RF2Data.Structs;

namespace MyApplication{

    [SupportedOSPlatform("windows")]
    public class MyMemoryReader
    {
        private readonly RF2MemoryReader MemoryReader;

        public MyMemoryReader()
        {
            MemoryReader = new();
        }

        public async Task<VehicleTelemetry?> ReadAsyncTelemetry()
        {
            var telemetry = await MemoryReader.GetTelemetryAsync();
            var scoring = await MemoryReader.GetScoringAsync();

            if ((telemetry == null) || (scoring == null))
            {
                return null;
            }

            var playerVehicle = scoring.Value.Vehicles.First(vehicle => (ControlEntity)vehicle.Control == ControlEntity.Player);
            var playerTelemetry = telemetry.Value.Vehicles.First(vehicle => vehicle.ID == playerVehicle.ID);


            return playerTelemetry;
        }

        public void Close()
        {
            MemoryReader.Dispose();
        }
    }
}
```

## LMU Electronics Example

Here is an example with LMU electronics data.

``` C#
using rF2SharedMemoryNet;
using rF2SharedMemoryNet.RF2Data.Enums;
using rF2SharedMemoryNet.LMUData.Models;

namespace MyApplication{

    [SupportedOSPlatform("windows")]
    public class MyMemoryReader
    {
        private readonly RF2MemoryReader MemoryReader;

        public MyMemoryReader()
        {
            MemoryReader = new(enableDMA:true); // Need to set this to true to initialize LMU memory reader.
        }

        public Electronics ReadElectronics()
        {
            return MemoryReader.GetLMUElectronics();
        }

        public void Close()
        {
            MemoryReader.Dispose();
        }
    }
}

```

# Other Info

For all of the methods reffer to [API](https://domaslau.github.io/rF2SharedMemoryNet/api/rF2SharedMemoryNet.html) page.