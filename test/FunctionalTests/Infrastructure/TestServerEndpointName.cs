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

namespace Grpc.AspNetCore.FunctionalTests.Infrastructure
{
    public enum TestServerEndpointName
    {
        Http2,
        Http1,
        Http2WithTls,
        Http1WithTls,
#if NET5_0_OR_GREATER
        UnixDomainSocket,
#endif
#if NET6_0_OR_GREATER
        Http3WithTls,
#endif
    }
}
