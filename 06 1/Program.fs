open System
open System.IO

let split (x: string) = x.Split [|'\t'|] |> List.ofSeq

let rec distribute index value list =
    match Array.tryItem index list with
    | _ when value = 0 -> list
    | Some item ->
        Array.set list index (item + 1)
        distribute (index + 1) (value - 1) list
    | None -> distribute 0 value list


let isSame = (=)

[<EntryPoint>]
let main argv =
    let input =
        "./input.txt"
        |> File.ReadAllText
        |> split
        |> List.sort

    printfn "%A" input
    0
