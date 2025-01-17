#!/bin/bash
# Copyright 2019 The gRPC Authors
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

# Updates the GrpcSharpVersion property so that we can build
# dev nuget packages differentiated by timestamp.

set -e

cd "$(dirname "$0")"

DEV_DATETIME_SUFFIX=$(date -u "+%Y%m%d%H%M")
# expand the -dev suffix to contain current timestamp
sed -ibak "s/-dev<\/GrpcDotnetVersion>/-dev${DEV_DATETIME_SUFFIX}<\/GrpcDotnetVersion>/" version.props
