import ipaddress
import time
import os

os.system("color 02")

x = 2**24

while True:
	
	print(f"Hacking {ipaddress.ip_address(x)}")
	time.sleep(1)
	print("...")
	time.sleep(1)
	print("failed ... trying new address\n")
	x += 1
	time.sleep(1)