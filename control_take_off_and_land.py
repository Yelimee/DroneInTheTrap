import time
import RPi.GPIO as GPIO
# for tcp communication
import socket
import sys

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)

GPIO.setup(12, GPIO.OUT)
GPIO.setup(32, GPIO.OUT)
GPIO.setup(7,  GPIO.OUT)
GPIO.setup(18, GPIO.OUT)

Right_Side_Front = GPIO.PWM(12, 210)
Right_Side_Back  = GPIO.PWM(32, 210)
Left_Side_Front  = GPIO.PWM(7,  210)
Left_Side_Back   = GPIO.PWM(18, 210)

Right_Side_Front.start(0)
Right_Side_Back.start(0)
Left_Side_Front.start(0)
Left_Side_Back.start(0)

def gpio_function(frequency):
	v = frequency # accept value 25~55

	if v < 56:
		Right_Side_Front.ChangeDutyCycle(v)
        	Right_Side_Back.ChangeDutyCycle(v)
                Left_Side_Front.ChangeDutyCycle(v)
                Left_Side_Back.ChangeDutyCycle(v)
        else:
        	Right_Side_Front.stop()
        	Right_Side_Back.stop()
        	Left_Side_Front.stop()
        	Left_Side_Back.stop()

        	GPIO.cleanup()
        	quit()
        	
# open a socket, etc
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = ('192.168.43.196', 9293)
print >>sys.stderr, 'starting up on %s port %s' % server_address
sock.bind(server_address)

sock.listen(1)

while True:
	print >>sys.stderr, 'waiting for a connection'
	connection, client_address = sock.accept()
	# not socket.accept()

	try:
        print >>sys.stderr, 'connection from', client_address
        	
        while True:
        	data = connection.recv(256)
        	print >>sys.stderr, 'received %s' % data
        	gpio_function(data)	
        	if data:
        		print >>sys.stderr, 'sendging message back to the client'
        		connection.sendall(str(int(data) * 10))
        			
        	else:
        		print >>sys.stderr, 'no more data from', client_address
        		break
        		
    finally:
       	connection.close()
