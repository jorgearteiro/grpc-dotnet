#region Copyright notice and license

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

using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Server
{
    public class InternalService : Internal.InternalBase
    {
        private readonly ILogger _logger;

        public InternalService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<InternalService>();
        }

        public override Task<InternalReply> SayHello(InternalRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Sending hello to {request.Name}");
            return Task.FromResult(new InternalReply { Message = "Hello " + request.Name });
        }
    }
}
