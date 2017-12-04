open System.IO

let charToInt char = char.ToString () |> int

let compute (last, total) elem =
    if elem = last
        then (elem, total + elem)
        else (elem, total)

[<EntryPoint>]
let main argv =
    let input =
        "./1/input.txt"
        |> File.ReadAllText
        |> List.ofSeq
        |> List.map charToInt

    let last = List.last input
    let (_, result) = List.fold compute (last, 0) input

    printfn "%i" result
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
