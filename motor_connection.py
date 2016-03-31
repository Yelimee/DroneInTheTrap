import time
import RPi.GPIO as GPIO
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)

GPIO.setup(12, GPIO.OUT)
GPIO.setup(32, GPIO.OUT)
GPIO.setup(7, GPIO.OUT)
GPIO.setup(18, GPIO.OUT)

Right_Side_Front = GPIO.PWM(12, 45)
Right_Side_Back = GPIO.PWM(32, 45)
Left_Side_Front = GPIO.PWM(7, 45)
Left_Side_Back = GPIO.PWM(18, 45)

Right_Side_Front.start(30)
Right_Side_Back.start(30)
Left_Side_Front.start(30)
Left_Side_Back.start(30)

Right_Side_Front.ChangeDutyCycle(7.5)
Right_Side_Back.ChangeDutyCycle(7.5)
Left_Side_Front.ChangeDutyCycle(7.5)
Left_Side_Back.ChangeDutyCycle(7.5)

time.sleep(3)

try:
	while True:
		Right_Side_Front.ChangeDutyCycle(5)
		Right_Side_Back.ChangeDutyCycle(5)
		Left_Side_Front.ChangeDutyCycle(5)
		Left_Side_Back.ChangeDutyCycle(5)
		time.sleep(3)
		Right_Side_Front.ChangeDutyCycle(7.5)
		Right_Side_Back.ChangeDutyCycle(7.5)
		Left_Side_Front.ChangeDutyCycle(7.5)
		Left_Side_Back.ChangeDutyCycle(7.5)
		time.sleep(3)
		
except KeyboardInterrupt:
	print("User Cancel")

finally:
	Right_Side_Front.stop()
	Right_Side_Back.stop()
	Left_Side_Front.stop()
	Left_Side_Back.stop()

	GPIO.cleanup()
	quit()

