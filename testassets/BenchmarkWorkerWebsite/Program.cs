﻿#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace BenchmarkWorkerWebsite
{
    public class Program
    {
        static readonly CancellationTokenSource QuitWorkerCts = new CancellationTokenSource();
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync(QuitWorkerCts.Token);
        }

        public static void QuitWorker()
        {
            QuitWorkerCts.Cancel();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        // Port on which to listen to commands from QpsDriver
                        int driverPort = context.Configuration.GetValue<int>("driver_port", 50053);

                        options.ListenAnyIP(driverPort, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
