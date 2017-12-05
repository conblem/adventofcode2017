open System

let input = 325489 |> float
//let input = 12 |> float

let upperright x =
    x
    |> (fun y -> pown y 2)
    |> (*) 2.0
    |> (-) (2.0 * x)
    |> (+) 1.0

let computeLayer x =
        x
        |> sqrt
        |> (fun x -> x - 1.0)
        |> (fun x -> x / 2.0)
        |> ceil

[<EntryPoint>]
let main argv =
    let layer = computeLayer input

    let result =
        input
        |> computeLayer
        |> upperright
        |> (-) input
        |> (%) layer
        |> abs
        |> (+) layer
        |> int
    

    printfn "%i" result
    System.Console.ReadKey () |> ignore
    0 // return an integer exit code
