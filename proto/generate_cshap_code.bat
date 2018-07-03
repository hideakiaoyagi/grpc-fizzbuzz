set PROTOC=%USERPROFILE%\.nuget\packages\google.protobuf.tools\3.5.0\tools\windows_x64\protoc.exe
set PLUGIN=%USERPROFILE%\.nuget\packages\grpc.tools\1.8.0\tools\windows_x64\grpc_csharp_plugin.exe

set PROTO_FILE=fizzbuzz.proto
set SRC_DIR=.
set DST_DIR=.

%PROTOC% --proto_path=%SRC_DIR% --csharp_out=%DST_DIR% --grpc_out=%DST_DIR% --plugin=protoc-gen-grpc=%PLUGIN% %PROTO_FILE%
