# Ball physics

## Motivation

I want to play volley ball in 2D by simulating soft and deformable bodies. So, the
ball is soft and the bat too. But how this can be done?

## Possible solution

My first idea was too write my own physics engine. Instead of using ridig
body engines, that can be found out there in the big net, I could do my own
collision detection while stepping through the simulation.

You might say: Cool! A new engine with a different body system. Finally, someone
had the guts to do this. OK, let's do this.

...but actually it is a very bad idea, because I would pause the volley ball game
idea and start a physics engine.

## Actual solution

HOLY SHIT! That was tight!

What I am actually going to do is to model a deformable body with rigid bodies.

Simple things first, I will create a physics model for the volley ball.

### Which framework?

Because my game and its documentation will run in the browser, I will choose a
port of [Box2D](http://box2d.org/):
[Box2D.ts](https://github.com/flyover/box2d.ts).

### Rigid version
