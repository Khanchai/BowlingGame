// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System

let fizzBuzz x = 
    match x with
    | _ when x % 3 = 0 && x % 5 = 0 -> Console.WriteLine("Fizz Buzz")
    | _ when x % 3 = 0              -> Console.WriteLine("Fizz")
    | _ when x % 5 = 0              -> Console.WriteLine("Buzz")
    | _                             -> Console.WriteLine(x)
 

let fb (n1, n2) =
    if (n1 < 100) then
        Some (n1, (n2, n1+n2))
    else
        None

[<Literal>]
let Three = 3

let filter123 x =
        match x with 
        // The following line contains literal patterns combined with an OR pattern.
        | 1 | 2 | Three -> printfn "Found 1, 2, or 3!" 
        // The following line contains a variable pattern.
        | var1 -> printfn "%d" var1

type Color =
    | Red = 0
    | Green = 1
    | Blue = 2

let printColorName (color:Color) =
    match color with
    | Color.Red -> printfn "Red"
    | Color.Green -> printfn "Green"
    | Color.Blue -> printfn "Blue"
    | _ -> ()

let apply ( f: int -> int -> int ) x y = f x y

let applyAdd a b = apply (fun x y -> x + y) a b 

[<EntryPoint>]
let main argv = 
    Seq.unfold fb (1,1) |> Seq.iter System.Console.WriteLine |> ignore
    let list = [1..100]
    for x in list do fizzBuzz x
    
    for x in 1..10 do filter123 x

    printColorName Color.Red
    printColorName Color.Green
    printColorName Color.Blue

    let result = applyAdd 20 30
    do
        printfn "%d" result
        applyAdd 2 3 |> printf "%d" 
    
    System.Console.ReadLine() |> ignore // return an integer exit code
    0