open System

let input = 325489 |> float

[<EntryPoint>]
let main argv =
    let size = input |> sqrt |> ceil |> int
    let ringMax = pown size 2
    printfn "%i %i" size ringMax
    System.Console.ReadKey () |> ignore
    0 // return an integer exit code
