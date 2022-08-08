# Pling-Ponger
## How to run
1. Download Zip File
2. Extract
3. Navigate to "\PlingPonger\\"
4. Run the program  VIA "dotnet run"

## Why?

I created it because it would be something slightly challenging; I also figured that it would be good practice for a language that I initially didnt like. It was quite fun overall for a very basic concept.

## How it Works
Very simple and easy to read if you look at it.
### Paddles
Simply moves up and down. In the preceeding function they have their own limits according to the canvas Y limit. 
### Ball
Checks for collision of a paddle or the top/bottom. It then Bounces according to the case (1-4)
It then iterates itself onto the canvas and moves accordingly hiding its tracks. To end it catches an IndexOutOfBounds Exception and determins the winner from there :)
### Canvas
A 30 Long 10 tall array.

## Extras
Have fun with this simple game, I am thinking about implementing an ai!
Please feel free to leave an issue or PR if you have any question or complaints
