open System
open System.IO
open System.Collections.Generic

type Instruction = {
    Register: string;
    Mode: int -> int -> int;
    Value: int;
    CompareRegister: string;
    Operator: int -> int -> bool
    CompareValue: int;
}

let emptyInstruction () = {
    Register="";
    Mode=(+);
    Value=0;
    CompareRegister="";
    Operator=(<=)
    CompareValue=0
}

let mapOperator (_::_::_::_::_::operator::_) acc =
    match operator with
    | "<" -> {acc with Operator=(<)}
    | ">" -> {acc with Operator=(>)}
    | "<=" -> {acc with Operator=(<=)}
    | ">=" -> {acc with Operator=(>=)}
    | "==" -> {acc with Operator=(=)}
    | "!=" -> {acc with Operator=(<>)}
    | _ -> acc

let mapNumbers (_::_::value::_::_::_::compareValue::_) acc = {
    acc with
    Value=value |> int;
    CompareValue=compareValue |> int
}

let mapMode (_::mode::_) acc =
    match mode with
    | "inc" -> {acc with Mode=(+)}
    | "dec" -> {acc with Mode=(-)}
    | _ -> acc

let mapStrings (register::_::_::_::compareRegister::_) acc = {
    acc with
    Register=register;
    CompareRegister=compareRegister
}

let compose x =
    emptyInstruction ()
    |> mapOperator x
    |> mapNumbers x
    |> mapMode x
    |> mapStrings x

let split (elem: String) = elem.Split ' ' |> List.ofArray

let calculate (x: Dictionary<string, int>) elem =
    let { Register=register;
        Mode=mode; Value=value;
        CompareRegister=compareRegister;
        Operator=operator;
        CompareValue=compareValue } = elem
    
    if operator x.[compareRegister] compareValue
    then 
        let result = mode x.[register] value 
        x.[register] <- result
        result
    else 0

let fillDictionary (x: Dictionary<string, int>) {CompareRegister=compareRegister; Register=register} =
    x.[register] <- 0
    x.[compareRegister] <- 0

[<EntryPoint>]
let main argv =
    let registers = new Dictionary<string, int>()

    let input =
        "./input.txt"
        |> File.ReadAllLines
        |> List.ofArray
        |> List.map (split >> compose)

    List.iter (fillDictionary registers) input
    let result =
        input
        |> List.map (calculate registers)
        |> List.max
    
    printfn "%A" result
    Console.ReadKey () |> ignore
    0 // return an integer exit code
