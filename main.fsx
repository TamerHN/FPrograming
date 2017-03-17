open System
open System.Collections.Generic

exception NegativityError of string
//the entered string
let orginalStr =  "//;\n9;-11;-8"
//split the given string to the data an the delimerter
let splitString (str:string) =
    str.Split('\n')
//get the splitter, or ',' by default
let getSplitter (str:string []) = 
    if str.Length <> 1 then
        str.[0].Split([|"//"|], StringSplitOptions.RemoveEmptyEntries).[0]
    else 
        ","
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
    let splitBy = [|orginalStr |> splitString |> getSplitter|]
    let mutable sum = 1
    try
        sum <- str
                |> split splitBy 
                |> Array.map int
                |> checkNegativity
                |> Array.sum
    with 
    | NegativityError err -> failwith err
    sum


printfn "Sum is: %d" (add orginalStr)
