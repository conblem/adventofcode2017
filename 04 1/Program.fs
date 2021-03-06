﻿open System
open System.IO

let split (elem: String) = elem.Split [|' '|] |> List.ofArray
let distinct elem =
    elem
    |> List.distinct
    |> (=) elem

[<EntryPoint>]
let main argv =
    let result = 
        "./input.txt"
        |> File.ReadAllLines
        |> List.ofArray
        |> List.map split
        |> List.filter distinct
        |> List.length

    printfn "%i" result
    System.Console.ReadKey () |> ignore
    0
