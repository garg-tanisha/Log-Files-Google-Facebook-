# Log-Files-Google-Facebook

Tasks : 

1) Use MSTest to write tests 
2) Create a method, which reads from the “log.txt” file and saves that value
3) Use Timer to call the above method again and again after a time interval
4) Write 2 TestMethods - Google Search and Facebook Login automation using Selenium Driver
5) Print content from the "log.txt" file every 10 seconds

Workflow:

a. Fields
1) Initilize instance of ChromeDriver class

b. Methods

i. your_method (called every 10 seconds)
1) calls ReadLogFile method

ii. ReadLogFile method
1) extract data from "log.txt"
2) store data in variables 
3) print the data

c. ClassInitialize
1) Initilize a new instance of the Timer class, and sets the Timer.Interval property to the specified number of milliseconds
2) Start raising the Timer.Elapsed event by setting Timer.Enabled to true

d. TestInitialize 
1) Maximize browser
2) Set implicit time wait ( which stays for entire session)

e. TestMethods 

i. TestMethod0 (Google Search WorkFlow) 
1) Go to the Url "http://google.com"
2) Finds the element with the Name "q" and enters "Regression Testing" there and press Enter (keyboard)
3) Press browser's back button
4) Press browser's front button                  
5) Refresh current page
6) Prints current page title from the browser
7) Exception handling is also used

ii. TestMethod1 (Facebook Login WorkFlow) 
1) Go to the Url "http://facebook.com"
2) Finds the element with the Id "email" and fills "enter your email" there
3) Finds the element with the Id "pass" and fills "password" there and press Enter (keyboard)
4) Extract the profile element and click            
5) Extract the "Friends" tab and click 
6) Verify if the Friends tab is displayed on current page
7) Exception handling is also used

f. TestCleanup : 
1) Closes the browser
2) Quits
