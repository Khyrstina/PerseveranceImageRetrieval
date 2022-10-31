
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


- Connects to an external/3rd party API and reads data for use in the application.
- Reading data from JSON and deserializing for use in the application.
- Calculates and displays data based on current DateTime and the landing date for Perseverance to display how long Perseverance has been on Mars.
- Allows the user to repeatedly perform actions to request images from the API.
