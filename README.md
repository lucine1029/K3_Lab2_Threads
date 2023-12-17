Labb 2: Trådar

# About the task
In this lab you will build a program that simulates a car race where two (or more) cars race against each other. There are no graphics, only in the console, but the cars will run in different threads and really compete against each other.

# What you will do
🚘 **The cars**
- [ ] Every car should be an object
- [ ] Each car must have a name 
- [ ] We must have at least two cars in this competition

**The Competition**
- [ ] The competition involves the cars driving a distance of, for example, 10 km
- [ ] All cars must start at 0 km
- [ ] All cars have a basic speed of, for example, 120 km/h. No car is slower or faster than the others from the start.
- [ ] The cars do not need to accelerate. They get right up to their speed.
- [ ] Each Car object must run in its own thread

⚠️ **Problem on the Road**
- [ ] There should be some random events that can happen to a car.
- [ ] The events are listed below and there you see what can happen, how likely it is to happen and what is happening. You can invent more or other events if you want.
    
     | Event | Probability | Effect |
     | --- | --- | --- |
     | Out of gas | 1/50 | Needs to refuel, stops 30 seconds |
     | Puncture | 2/50 | Needs tire change, stops 20 seconds |
     | Bird on the windshield | 5/50 | Need to wash windshield, stops 10 seconds |
     | Engine failure | 10/50 | The speed of the car is reduced by 10km/h |
- [ ] Every 30 seconds, an event must be randomly generated for each car. Only one event can occur at a time.

🏎️ **Run the race!**
- [ ] All cars must start at the same time
- [ ] Print in the console when the cars start
- [ ] Print to the console when a car gets a problem. Write which car and which problem.
- [ ] Print when a car reaches the finish line. If it is the first, it should also be printed that it won!
- [ ] The user must be able to choose to have the position in the competition printed on command. For example, the user can press enter or type "status" as an input. When this is done all the cars and how far they have come should be printed as well as their speed.
