import re
import random
import json
import xml.etree.ElementTree

sample_list = []

for line in open("pre_random_sample.txt","r"):
    sample_list.append(line)

fp = open("concept_dataset.dat","w")

for i in range(40000):
    fp.write(random.choice(sample_list))

fp.close()