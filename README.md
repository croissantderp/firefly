# firefly
A blinky animation project


# how-to
**The editor (the fields in the upper-left corner), is for editing the speed or appearance of animations.**

The first box is for the number of the slot you wish to edit (1 through 5)

The second is for controlling the speed of animations (note that this value can be edited seperate of the other fields and is global)

The third is for the editing the patterns.<br />
  The patterns are stored in the following format: \[horizontal resolution],\[vertical resolution];\[sequence of frames seperated by /]<br />
  each frame is a sequence of 0s and 1s representing on and off pixels seperated by commas (newlines are optional)  <br />
  enter 'default' in the field to reset the animation to the default preset
  
  example input: 
```
5,4;
1,1,1,1,1,
0,0,0,0,0,
1,1,1,1,1,
0,0,0,0,0
/
0,0,0,0,0,
1,1,1,1,1,
0,0,0,0,0,
1,1,1,1,1
```
