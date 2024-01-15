from selenium import webdriver
from selenium.webdriver.chrome.service import Service as ChromeService
from webdriver_manager.chrome import ChromeDriverManager
import time 
from selenium.webdriver.chrome.options import Options
 
option = Options()

option.add_experimental_option(
    "prefs", {"profile.default_content_setting_values.media_stream_mic": 1}
)

driver = webdriver.Chrome(service=ChromeService(ChromeDriverManager().install()),chrome_options=option)

driver.get("https://localhost:12001/") 
details_button = driver.find_element_by_id("details-button")
details_button.click()

proceed_button = driver.find_element_by_id("proceed-link")
proceed_button.click()
start_button = driver.find_element_by_id("start")
start_button.click()

time.sleep(100)
driver.close() 