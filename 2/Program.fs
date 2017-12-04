open System
open System.IO

let split (x: String) = 
    x.Split [|'\t'|]
    |> List.ofArray
    |> List.map int

let cheksum x = (List.max x) - (List.min x)

[<EntryPoint>]
let main argv =
    let result = 
        "./2/input.txt"
        |> File.ReadAllLines 
        |> List.ofArray
        |> List.map split
        |> List.sumBy cheksum

    printfn "%i" result
    System.Console.ReadKey() |> ignore
    0
