# Kookmin University Computer Science
# 20133246 Soryung Lee
# This code is a TCP example in Google and I just changed a little.

import socket
import sys

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server_address = ('192.168.43.196', 9294)
# sey 192.168.43.196

print >>sys.stderr, 'starting up on %s port %s' % server_address
sock.bind(server_address)

sock.listen(1)

while True:
    print >>sys.stderr, 'waiting for a connection'
    connection, client_address = sock.accept()

    try:
        print >>sys.stderr, 'connection from', client_address

        while True:
            data = connection.recv(256)
            print >>sys.stderr, 'received %s' % data
            message = str(raw_input("send message: "))
            if data:
                print >>sys.stderr, 'sending message back to the client'
                connection, sendall(message)
            else:
                print >>sys.stderr, 'no more data from', client_address
                break
    finally:
        connection.close()
        
