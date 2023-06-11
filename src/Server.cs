using System.Net;
using System.Net.Sockets;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
TcpListener server = new TcpListener(IPAddress.Any, 6379);
server.Start();


var socket = server.AcceptSocket(); // wait for client

while(true)
{
	byte[] buffer = new byte[1024];
	var data = socket.Receive(buffer); // receive data from client
	if(data == 0) break; // client closed connection

	// convert string to byte array
	byte[] response = System.Text.Encoding.ASCII.GetBytes("+PONG\r\n");

	socket.Send(response);
}

