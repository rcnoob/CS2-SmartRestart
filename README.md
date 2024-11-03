# CS2-SmartRestart
 A plugin to prevent maptime issues

# What it does
 The plugin will, every 30 minutes, restart the current map if there are no players connected
 
 If there are players connected, it will force restart if maptime reaches 24 hours

# Why its needed
 CSGO was a set rate of 64t each second. CS2 is, well, the same sorta, with some added floating point voodoo subtick math
 
 This results in inaccuracy over long periods of maptime
 
 At 24 hours, screen tearing begins, and core game mechanics like jump height are altered
 
 At 72 hours, the game runs at essentially 0.5 timescale
