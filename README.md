# Pyramid-Game
This was the final project for my Unity Game Development Class and as such, it was the most complicated. My original idea was to make a 
samurai-themed stealth game that had a top down view from an angle. Instead of actually planning out all of the parts I would need to make
for this idea I just jumped right in and started making stuff. This process continued in a way that led me to create many assets that went
totally unused in the final product, but I think that this is the way I learned a very important facet of game design: doing work doesn't
always mean doing relevant work. 

Continuing with my samurai idea, I thought that the levels I would make would go inside buildings so I needed to make a way for objects to
fade away when they get between the camera and the player. I developed a way to modify the alpha component of the objects that are 
intersected by a linecast from the camera to the player however, I had difficulty making them return to their full opacity afterwards.
The final iteration of this technique worked pretty well, the way the walls faded in and out was smooth but I couldn't figure out how
to actually apply this to any other part of the design yet.

Next, I decided that making the levels themselves was a good idea considering that they would probably involve the majority of the work.
For the samurai idea, I would need level pieces that would fit together nicely, so using a grid seemed a good idea. My teacher advised
me that making level pieces that would go in each category before figuring out the actual generation would be a bad idea so I started
instead working on just generating little cubicals next to each other. I used a 2D array and it was fairly simple, each cubical had walls
and corner posts that I kept track of as well. Next I decided to randomly disable walls inside of the cubicals to make some sort of
path, although I had to find some way to keep the edges of the map from disabling. To Be Continued...
 
