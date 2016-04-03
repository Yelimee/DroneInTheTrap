import time

import RPi.GPIO as GPIO
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)

GPIO.setup(12, GPIO.OUT)
GPIO.setup(32, GPIO.OUT)
GPIO.setup(7, GPIO.OUT)
GPIO.setup(18, GPIO.OUT)

Right_Side_Front = GPIO.PWM(12,210)
Right_Side_Back = GPIO.PWM(32, 210)
Left_Side_Front = GPIO.PWM(7, 210)
Left_Side_Back = GPIO.PWM(18, 210)

Right_Side_Front.start(0)
Right_Side_Back.start(0)
Left_Side_Front.start(0)
Left_Side_Back.start(0)

state = True

R_F = 0
R_B = 0
L_F = 0
L_B = 0

v = 0 # accept value 25~55
	
try:
        while state:
		v = int(raw_input())
		
		if v < 100:
                        R_F = v
                        R_B = v
                        L_F = v
                        L_B = v

                else:
                        state = False
                        print("ok")

                Right_Side_Front.ChangeDutyCycle(R_F)
                Right_Side_Back.ChangeDutyCycle(R_B)
                Left_Side_Front.ChangeDutyCycle(L_F)
                Left_Side_Back.ChangeDutyCycle(L_B)

except KeyboardInterrupt:
        print("User Cancel")

finally:
        Right_Side_Front.stop()
        Right_Side_Back.stop()
        Left_Side_Front.stop()
        Left_Side_Back.stop()

        GPIO.cleanup()
        quit()
