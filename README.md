
# PerseveranceImageRetrieval

This program helped me learn to access and use a NASA API (specifically their "Mars Rover Photos" API) to retrieve photos taken by my personal favorite Mars rover, Perseverance. I wanted the program to return photos from the most recent Sol for Perseverance, and show a calculation of how long Perseverance has been on Mars. I also wanted to allow the user to navigate through photos and view them with the image ID, Sol, and Earth date they were taken displayed. Sols are the number of Mars days (not Earth days) that the rover has been on Mars. This meant that the current Sol had to be calculated so the program could count down from current Sol (currently 608 at the time of writing this) down to sol date 1 which is the landing date for Perseverance. To display the calculation of how long Perseverance has been on Mars, I used the DateTime, Timespan, and Subtract. I subtracted the landing date from the current date and displayed the difference under the About Rover button. I then used the result of that calculation to convert Earth Days that Perseverance has been on Mars to Sols that Perseverance has been on mars. In addition to the Features list below, I had fun learning how to give the program a more updated look using XAML. I added buttons with rounded edges, a font that resembles the NASA font while still being legible, and added a color scheme throughout that matches the Orioles Orange, and Midnight Blue that NASA uses in its logo and promotional material. 



## Features


- Connects to an external/3rd party API and reads data for use in the application - connects to the Mars Rover Photos API and uses the information throughout. More information about this API can be found here: https://api.nasa.gov/ and here: https://github.com/chrisccerami/mars-photo-api (Chris Cerami maintains the API)
- Reading data from an external file- This program deserializes JSON for use in the application (this was listed in the examples of this feature on the requirements page).
- Calculate and display data based on an external factor- TimeOnMars calculates using the current Date and time and is used to display how many days, hours, minutes, and seconds that Perseverance has been on Mars.
- Master Loop- This allows the user to repeatedly perform actions to request images from the API and exit the program.
- Build a conversion tool that converts one type to another- DaysToSols uses the TimePassed calculation in TimeOnMars to convert Days to Sols.


## General Notes


- On several Sol dates (for example 604) Nasa seemed preoccupied with taking a large number of nearly identical images of the panelling on the rover. If you have seen two or more images in a row that are similar please check the first number in the text under the image, this is the image ID number. It will change if it is retrieving 'different' images as it should.
- The code checks if there are greater than 0 images for the Sol, if there are 0 that day will be skipped (example Sol 605). I was unable to find information on why this Sol has no images in the array. Even if you put the API link into the browser and specify sol 605 the Photos array is empty, so the issue seems to be on the API end.


