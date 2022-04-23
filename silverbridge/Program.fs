(***************************
COPYRIGHT LESTER COVEY (me@lestercovey.ml),
2021

***************************)
open System
open Constant
open System.Net
open System.IO

let setColor color =
    Console.ForegroundColor <- color

[<EntryPoint>]
let main argv = 
    setColor ConsoleColor.White;
    printf "%s" Strings.Welcome;
    printf "%s" Strings.KeyPrompt;
    let key = Console.ReadLine();
    // Making request
    use s = WebRequest.Create(Endpoint(Strings.EchoCommand, key).construct).GetResponse().GetResponseStream();
    use sr = new StreamReader(s)
    let rs = sr.ReadToEnd()
    printf "%A" rs;
    exit 0
    while true do 
        let s = Console.ReadLine();
        printf "%s" s;
        
        ()
    0
