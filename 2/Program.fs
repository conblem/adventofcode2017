// Learn more about F# at http://fsharp.org

open System
open System.IO

let split (x: String) = 
    x.Split [|'\t'|]
    |> List.ofArray
    |> List.map int

let cheksum x =
    let min = List.min x
    let max = List.max x
    max - min

[<EntryPoint>]
let main argv =
    let result = 
        "./2/input.txt"
        |> File.ReadAllLines 
        |> List.ofArray
        |> List.map split
        |> List.map cheksum
        |> List.sum
    printfn "%i" result
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
