open System.IO

let charToInt char = char.ToString () |> int

let compute acc elem =
    let (last, total) = acc
    if elem = last
        then (elem, total + elem)
        else (elem, total)

[<EntryPoint>]
let main argv =
    let input = File.ReadAllText "./1/input.txt" |> List.ofSeq |> List.map charToInt
    let last = List.last input
    let (_, result) = List.fold compute (last, 0) input
    printfn "%i" result
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
