# 音楽再生用ソースコード

from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.chrome.service import Service as ChromeService
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.options import Options
import sys
import time 

prompt = str(sys.argv[1])
 
option = Options()

driver = webdriver.Chrome(service=ChromeService(ChromeDriverManager().install()),options=option)
driver.get(f"https://www.youtube.com/results?search_query= + {prompt}") 

time.sleep(1)

movies = driver.find_elements_by_id("dismissible")
movies[0].click()

time.sleep(300)

driver.clone()