(***************************
COPYRIGHT LESTER COVEY (me@lestercovey.ml),
2021

***************************)
open System
open Constant
open System.Net
open System.IO

let mutable pass = ""

let die withError =
    Console.ForegroundColor <- ConsoleColor.Red
    printfn "%s" (Strings.Fatal + withError)
    Console.ResetColor()
    exit 1
let makeRequest requestString = 
    try
        use s = WebRequest.Create(Endpoint(requestString, pass).construct).GetResponse().GetResponseStream()
        use sr = new StreamReader(s)
        sr.ReadToEnd()
    with
        | e -> die (e.Message)
let fetchPass =
    printf "%s" Strings.KeyPrompt
    let mutable key = ConsoleKeyInfo()
    let mutable passwd = ""
    while key.Key <> ConsoleKey.Enter do
        key <- Console.ReadKey(true)
        if key.Key = ConsoleKey.Backspace && passwd.Length > 0 then
            passwd <- passwd.[0 .. passwd.Length - 2]
        else
            passwd <- passwd + string key.KeyChar
    passwd

[<EntryPoint>]
let main argv = 
    pass <- fetchPass;
    printfn ""
    printf "%s" Strings.Authorizing
    if (makeRequest Strings.EchoCommand) = Strings.EchoCommand then
        printfn "%s" Strings.Success
    else
        die Strings.FatalAuth
    while true do 
        let s = Console.ReadLine()
        printf "%s" s

        Console.ResetColor()
    0
