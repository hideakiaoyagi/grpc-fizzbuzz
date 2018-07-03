#!/bin/bash

PROTOC=~/.nuget/packages/google.protobuf.tools/3.5.0/tools/linux_x64/protoc
PLUGIN=~/.nuget/packages/grpc.tools/1.8.0/tools/linux_x64/grpc_csharp_plugin

PROTO_FILE=fizzbuzz.proto
SRC_DIR=.
DST_DIR=.

$PROTOC --proto_path=$SRC_DIR --csharp_out=$DST_DIR --grpc_out=$DST_DIR --plugin=protoc-gen-grpc=$PLUGIN $PROTO_FILE
