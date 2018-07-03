# gRPC-FizzBuzz

A sample of gRPC programming in Golang and C#.


## About gRPC

https://grpc.io/  
https://github.com/grpc/  


## Interconnectability

Server and Client written in Golang and C# can be combined with each other.

* Golang client connects to Golang server
* Golang client connects to C# server
* C# client connects to Golang server
* C# client connects to C# server


## Instructions

### Instructions for Golang

#### 1. Install gRPC, Protocol Buffers, and more tools.  
see: https://grpc.io/docs/quickstart/go.html#prerequisites

#### 2. Compile the proto file into a Gplang-stub file.
```
$ cd proto
$ ./generate_golang_code.sh
$ ls
fizzbuzz.pb.go
```

#### 3. Run server.
```
$ cd server_golang
$ go run fizzbuzz_server.go
```

#### 4. Start another terminal, and run client.
```
$ cd client_golang
$ go run fizzbuzz_client.go
1
2
Fizz
4
Buzz
...
```


### Instructions for C#

#### 1. Check prerequisites.  
see: https://grpc.io/docs/quickstart/csharp.html#prerequisites

#### 2. Restore dependencies (gRPC, Protocol Buffers, and more tools) by NuGet.
```
$ cd proto
$ dotnet restore
```

#### 3. Compile the proto file into a C#-stub file.
```
$ ./generate_csharp_code.sh
$ ls
Fizzbuzz.cs
FizzbuzzGrpc.cs
```

#### 4. Run server.
```
$ cd server_csharp
$ dotnet run
```

#### 5. Start another terminal, and run client.
```
$ cd client_csharp
$ dotnet run
1
2
Fizz
4
Buzz
...
```
