(***************************
COPYRIGHT LESTER COVEY (me@lestercovey.ml),
2021

***************************)
open System

let setColor color =
    Console.ForegroundColor <- color

[<EntryPoint>]
let main argv = 
    while true do 
        let s = Console.ReadLine();
        printf "%s" s;

        ()
    0
