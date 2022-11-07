
# PerseveranceImageRetrieval

For this project my goal was to learn to access and use a NASA API 
(specifically their "Mars Rover Photos" API) to retrieve photos taken by
my personal favorite Mars Rover, Perseverance. Currently it has basic 
nagivation controls that allow the user to navigate through the most recent images
from Perseverance. I also wanted to give the user the ability to see a calculation of
how long Perseverance has been on Mars. To do this I used DateTime,
TimeSpan, and Subtract to subtract the landing date from the current date and
display the difference. In addition to adding the Features below, I gave the 
window an updated look using XAML. I added functional more appealing buttons,
a font that resembles the NASA font while being legible, and changed
the colors used throughout to the match the Orioles Orange, and Midnight Blue
that NASA uses for most of it's branding.


## Features


- Connects to an external/3rd party API and reads data for use in the application - connects to the Mars Rover Photos API and uses the information. More information about this API can be found here: https://api.nasa.gov/ and here: https://github.com/chrisccerami/mars-photo-api (Chris Cerami maintains the API)
- Reading data from an external file- This program deserializes JSON for use in the application.
- Calculate and display data based on an external factor- TimeOnMars calculates using the current Date and time and is used to display how many days, hours, minutes, and seconds that Perseverance has been on Mars.
- Master Loop- This allows the user to repeatedly perform actions to request images from the API and exit the program.
- Build a conversion tool that converts one type to another- DaysToSols uses the Time calculation in TimeOnMars to convert Days to Sols.


## General Notes


- On several Sol dates (for example 604) Nasa seemed preoccupied with taking a large number of nearly identical images of the panelling on the rover. If you have seen two or more images in a row that are similar please check the first number in the text under the image, this is the image ID number. It will change if it is retrieving 'different' images as it should.
- The code checks if there are greater than 0 images for the sol, if there are 0 that day will be skipped (example 605). I was unable to find information on why this Sol has no images listed. Even if you put the API link into the browser and specify sol 605 the Photos array is empty, so the issue seems to be on that end.


