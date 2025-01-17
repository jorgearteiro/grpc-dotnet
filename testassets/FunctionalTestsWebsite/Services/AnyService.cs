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

using Any;
using Grpc.Core;
using AnyMessage = Google.Protobuf.WellKnownTypes.Any;

namespace FunctionalTestsWebsite.Services
{
    public class AnyService : Any.AnyService.AnyServiceBase
    {
        public override Task<AnyMessageResponse> DoAny(AnyMessage request, ServerCallContext context)
        {
            AnyMessageResponse anyMessageResponse;
            switch (request.TypeUrl)
            {
                case "type.googleapis.com/any.AnyProductRequest":
                    var product = request.Unpack<AnyProductRequest>();
                    anyMessageResponse = new AnyMessageResponse
                    {
                        Message = $"{product.Quantity} x {product.Name}"
                    };
                    break;
                case "type.googleapis.com/any.AnyUserRequest":
                    var user = request.Unpack<AnyUserRequest>();
                    anyMessageResponse = new AnyMessageResponse
                    {
                        Message = $"{user.Name} - {(user.Enabled ? "Enabled" : "Disabled")}"
                    };
                    break;
                default:
                    throw new InvalidOperationException("Unexpected type URL.");
            }

            return Task.FromResult(anyMessageResponse);
        }
    }
}
