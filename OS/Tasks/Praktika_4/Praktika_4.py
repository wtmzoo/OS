import time

a = 0
b = 3
c = 3

start_time = time.time()
for i in range(100000000):
    a += (((b * 2) + c) - i)


print("--- %s seconds ---" % (time.time() - start_time))

