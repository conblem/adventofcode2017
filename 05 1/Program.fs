open System
open System.IO

let rec find index step list =
    match Array.tryItem index list with
    | Some item -> 
        Array.set list index (item + 1)
        find (index + item) (step + 1) list
    | None -> step

[<EntryPoint>]
let main argv =
    let input =
        "./5/input.txt"
        |> File.ReadAllLines
        |> Array.map int
        |> find 0 0
    
    printfn "%A" input
    System.Console.ReadKey () |> ignore
    0
