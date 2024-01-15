import re
import random
import json
import xml.etree.ElementTree

B_list = ["Air_on","Air_off","Light_on","Light_off","TV_on","TV_off","Another"]
anc = 0

# 書き出し用ファイル
fp = open("pre_random_sample.txt","w")

for line in open("pre.txt","r"):
    line = line.rstrip()
    print(line)
    if re.search(r"shift",line):
        anc += 1
    elif line == "":
        pass
    else:
        fp.write(B_list[anc] + "\t" + line + "\n")

fp.close()



