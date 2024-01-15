# 筑波大学公式サイトから、未提出課題の情報を取得するソースコード

# from time import sleep 
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.chrome.service import Service as ChromeService
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.options import Options
 
option = Options()
option.add_argument("--headless")

driver = webdriver.Chrome(service=ChromeService(ChromeDriverManager().install()),options=option)
driver.get("https://manaba.tsukuba.ac.jp/ct/home_library_query") 

User = "s2210573"
Pass = ""
# sleep(1) 

id_element = driver.find_element_by_name("j_username")
id_element.send_keys(User)
pw_element = driver.find_element_by_name("j_password")
pw_element.send_keys(Pass)

login_button = driver.find_element_by_name("_eventId_proceed")
login_button.click()
# sleep(1) 

driver.get("https://manaba.tsukuba.ac.jp/ct/home_library_query")


# sleep(1) 
# print(driver.page_source)

soup = BeautifulSoup(driver.page_source, 'html.parser')

couses = []
couses_infs = []
# res = []

for my_couse in soup.find_all("div",class_="mycourse-title"):
    # print(my_couse.string)
    couses.append(my_couse.string) 

for couses_inf in soup.find_all(class_="center"):
    # print(couses_inf.string)
    if (couses_inf.string == None):
        couses_infs.append("期日なし")
    else:
        couses_infs.append(couses_inf.string)

for i in range(len(couses)):
    print(f"{couses_infs[3*i-1]} {couses[i]}")

# print(res)

driver.close() 
