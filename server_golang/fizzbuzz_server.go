package main

import (
	"fmt"
	"log"
	"net"
	"strconv"

	"golang.org/x/net/context"
	"google.golang.org/grpc"

	pb "../proto"
)

const (
	port = ":50051"
	fizz = "Kuma"
	buzz = "Mon"
)

type server struct{}

func (s *server) GetFizzbuzzList(ctx context.Context, req *pb.FizzbuzzRequest) (*pb.FizzbuzzResponse, error) {
	if req.StartNumber < 1 {
		return nil, fmt.Errorf("'StartNumber' must be a natural number")
	}
	if req.EndNumber < 1 {
		return nil, fmt.Errorf("'EndNumber' must be a natural number")
	}
	if req.StartNumber > req.EndNumber {
		return nil, fmt.Errorf("'EndNumber' must be equal to or greater than 'StartNumber'")
	}

	wordlist := []string{}

	for i := int(req.StartNumber); i <= int(req.EndNumber); i++ {
		var word string
		switch {
		case i%15 == 0:
			word = fizz + buzz
		case i%3 == 0:
			word = fizz
		case i%5 == 0:
			word = buzz
		default:
			word = strconv.Itoa(i)
		}
		wordlist = append(wordlist, word)
	}

	return &pb.FizzbuzzResponse{WordList: fmt.Sprintf("%v", wordlist)}, nil
}

func main() {
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}

	s := grpc.NewServer()
	pb.RegisterFizzbuzzServiceServer(s, &server{})

	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
