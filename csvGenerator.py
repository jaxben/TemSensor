import random
import csv

#About 25 to 37 degrees 
#^^ do it where you can specify start and end value? 
#About 100 values. Last 10 or so values should be 37 or above. 

with open('random_temps.csv', 'w', newline='') as file:
    writer = csv.writer(file)
    for x in range(90): 
      rand = 22+(x/6)+5*random.random()
      writer.writerow([rand])
    for x in range(10):
      num = 37+3*random.random();
      writer.writerow([num])
