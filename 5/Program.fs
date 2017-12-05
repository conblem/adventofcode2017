// Learn more about F# at http://fsharp.org

open System
open System.IO

let replace (list: 'T []) index value =
    Array.set list index value
    list

let rec iterate list index =
    match List.tryItem index with
    | Some item -> 
        replace(list index item)

    | None ->

Array.set

[<EntryPoint>]
let main argv =
    let input =
        "./input.txt"
        |> File.ReadAllLines
        |> List.ofArray
        |> List.map int
    
    printfn "%A" input
    System.Console.ReadKey |> ignore
    0 // return an integer exit code
