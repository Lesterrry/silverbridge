(***************************
COPYRIGHT LESTER COVEY (me@lestercovey.ml),
2022

***************************)

module Constant
type Strings =
    static member Fatal = "FATAL: "
    static member Success = "SUCCESS"
    static member Authorizing = "Authorizing... "
    static member FatalAuth = "Access denied"
    static member Welcome = "Welcome to Silverbridge\n"
    static member KeyPrompt = "Enter key: "
    static member Prompt = "> "
    static member EmptyOutput = "< EMPTY >"
    static member EchoCommand = "echo"
    static member ExitInternalCommand = "exit"
type Endpoint(cmd: string, pass: string) =
    member private this.Head = "https://api.aydar.media/silverbridge.php?command="
    member private this.Pass = "&password="
    member public this.construct = this.Head + cmd + this.Pass + pass
    new(cmd, pass) = Endpoint(cmd, pass)