open System
open System.Collections.Generic

exception NegativityError of string
//the entered string
let orginalStr =  "//[@]\n2@3,8\n5\n7,25\n50@100@800\n1000"

//split the given string to the data an the delimerter
let splitString (str:string) =
    if str.Contains("//") then
        str.Split([|"\n"|],2, StringSplitOptions.RemoveEmptyEntries)
    else
        [|str|]
//get the splitter, or ',' by default
let getSplitter (str:string []) = 
    if str.Length <> 1 then
        let splitter = str.[0].Split([|"//"|], StringSplitOptions.RemoveEmptyEntries).[0]
        splitter.Split('[', ']') |> Array.filter (fun x -> x <> "") |> Array.append [|","; "\n"|]
    else 
        [|","; "\n"|]
//get the data (numbers)
let getString (str:string []) =
    if str.Length <> 1 then 
        str.[1]
    else 
        str.[0]
//get the numbers from the data string
let split (splitBy:string[]) (str:string)  = 
    str.Split(splitBy, StringSplitOptions.RemoveEmptyEntries)

//get the first two numbers only
let sliceArr (start:int) (length:int) (arr:string[]) =
    if arr.Length > (start + length) then
        Array.sub arr start length
    else
        arr
//check for negative numbers
let checkNegativity (arr:int []) =
    let negatives = arr |> Array.filter (fun x -> x < 0)
    if (negatives.Length > 0) then
        let error = negatives |> Array.map string |> String.concat ", "
        raise(NegativityError("Negatives not allowed " + error))
    arr
//the add function
let add orginalStr =
    let str = orginalStr |> splitString |> getString
    let splitBy = orginalStr |> splitString |> getSplitter
    let mutable sum = 1
    try
        sum <- str
                |> split splitBy 
                |> Array.map int
                |> Array.filter (fun x -> x < 1000)
                |> checkNegativity
                |> Array.sum
    with 
    | NegativityError err -> failwith err
    sum


printfn "Sum is: %d" (add orginalStr)
